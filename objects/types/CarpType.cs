﻿using System.Reflection;
using System.Text;
using Carp.interpreter;

namespace Carp.objects.types;

public abstract class CarpType : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpType>("type");
    public override CarpType GetCarpType() => Type;

    public CarpType BaseType => _baseType;
    public CarpObject DefaultValue => IsStruct ? Instantiate(Array.Empty<CarpObject>(), isImplicit: true) : CarpNull.Instance;
    
    protected readonly CarpType _baseType;
    private readonly CarpString _repr;
    public readonly bool IsStruct;
    protected CarpType(CarpType baseType, CarpString repr, bool isStruct = false)
    {
        this._baseType = baseType;
        this._repr = repr;
        this.IsStruct = isStruct;
    }

    public abstract CarpObject Instantiate(CarpObject[] args, bool isImplicit = false);

    public bool Extends(CarpType baseType) 
        => this == baseType // If we are that type
        || (!this.IsStruct && baseType == CarpNull.Type)
        || (this._baseType?.Extends(baseType) ?? false); // If our ancestors are that type
    public GenericCarpType With(params CarpType[] subTypes) => new(this, subTypes);

    // public static CarpType Of<T>(CarpString repr) where T : CarpObject => new(typeof(T), repr);
    public override CarpString String() => this._repr;
    public override CarpObject Property(string name)
    {
        return name switch {
            "name" => this.String(),
            "is_struct" => CarpBool.Of(this.IsStruct),
            _ => throw new CarpError.InvalidProperty(name),
        };
    }

    public static bool operator ==(CarpType left, CarpType right) => left!.Equals(right);
    public static bool operator !=(CarpType left, CarpType right) => !left!.Equals(right);
    
    public static CarpType HighestCommonType(CarpType[] arr)
    {
        if (arr.Length == 0) return CarpObject.Type;
        
        CarpType type = arr[0];
        while (arr.Any(x => !x.Extends(type))) type = type.BaseType;
        return type;
    }
}

public class GenericCarpType : CarpType
{
    private CarpType[] _subTypes;
    public CarpType[] SubTypes => this._subTypes;
    private static CarpString GenericfyName(CarpType baseType, CarpType[] subTypes)
    {
        if (baseType.Extends(CarpCollection.Type))
            return new(subTypes[0].String().Native + "*");
        
        if (baseType.Extends(CarpMap.Type))
            return new(subTypes[0].String().Native + ":" + subTypes[1].String().Native);

        StringBuilder sb = new();
        sb.Append(baseType.String().Native);
        sb.Append('<');
        sb.AppendJoin(", ", subTypes.Select(x => x.String().Native));
        sb.Append('>');
        return new(sb.ToString());
    }
    public GenericCarpType(CarpType baseType, CarpType[] subTypes) : base(baseType, GenericfyName(baseType, subTypes), baseType.IsStruct)
    {
        this._subTypes = subTypes;
    }

    public override bool Equals(object obj)
    {
        if (obj is GenericCarpType gct)
        {
            return gct._baseType.Equals(this._baseType)
                && gct._subTypes
                    .Zip(this._subTypes)
                    .Select(x => x.First == x.Second)
                    .All(x => x);
        }

        return base.Equals(obj);
    }

    public override CarpObject Instantiate(CarpObject[] args, bool isImplicit = false)
    {
        CarpObject[] newArr = new CarpObject[this._subTypes.Length + args.Length];
        this._subTypes.CopyTo(newArr, 0);
        args.CopyTo(newArr, this._subTypes.Length);
        
        return this._baseType.Instantiate(newArr, isImplicit);
    }
}

public class NativeType : CarpType
{
    private Type _t;
    private static Dictionary<string, NativeType> _nativeTypes = new();
    private NativeType(Type t, string displayName) : base(CarpObject.Type, new(displayName), t.GetCustomAttribute<CarpStructAttribute>() != null)
    {
        this._t = t;
    }

    private  NativeType(CarpType parent, Type t, string displayName) : base(parent, new(displayName),
        t.GetCustomAttribute<CarpStructAttribute>() != null)
    {
        this._t = t;
    }

    public static NativeType Of<T>(string name)
    {
        if (_nativeTypes.ContainsKey(name)) return _nativeTypes[name];

        NativeType nt = new(typeof(T), name);
        _nativeTypes[name] = nt;

        return nt;
    }
    
    public static NativeType Of<T>(CarpType parent, string name)
    {
        if (_nativeTypes.ContainsKey(name)) return _nativeTypes[name];

        NativeType nt = new(parent, typeof(T), name);
        _nativeTypes[name] = nt;

        return nt;
    }

    public override CarpObject Instantiate(CarpObject[] args, bool isImplicit = false)
    {
        CarpObject FinalInvoke(object[] objs)
        {
            MethodInfo of = this._t.GetMethod("Of", BindingFlags.Public | BindingFlags.Static,
                objs.Select(x => x.GetType()).ToArray());

            if (of == null)
                return (CarpObject)Activator.CreateInstance(this._t, objs);
            
            return (CarpObject)of.Invoke(null, objs);
        }
        
        if (isImplicit) // We are a struct and initializing it automatically
        {
            CarpStructAttribute csa = this._t.GetCustomAttribute<CarpStructAttribute>();
            if (csa == null)
                throw new InvalidOperationException("Cannot implicitly instantiate a non-struct type.");
            
            // Combine args + csa.args
            
            object[] newArgs = new object[csa.DefaultArgs.Length + args.Length];
            csa.DefaultArgs.CopyTo(newArgs, 0);
            args.CopyTo(newArgs, csa.DefaultArgs.Length);
            
            //return (CarpObject)Activator.CreateInstance(this._t, newArgs);
            // Call Of function
            return FinalInvoke(newArgs);
        }

        return FinalInvoke(args);
    }

    public override bool Equals(object obj)
    {
        if (obj is NativeType nt)
            return nt._t == this._t;

        return base.Equals(obj);
    }

    public static NativeType Find<T>() => Find(typeof(T));

    public static NativeType Find(Type t)
    {
        Func<KeyValuePair<string, NativeType>, bool> sel = x => x.Value._t == t;

        if (_nativeTypes.Any(sel))
            return _nativeTypes.First(sel).Value;

        return CarpObject.Type as NativeType;
    }
}

public class CarpClass : CarpType
{
    private List<CarpGrammarParser.Definition_with_attrContext> _staticDefinitions;
    private List<CarpGrammarParser.Definition_with_attrContext> _nonStaticDefinitions;
    private Scope _scope;
    public CarpClass(CarpString name, bool isStruct, IScope scope, List<CarpGrammarParser.Definition_with_attrContext> staticDefinitions, List<CarpGrammarParser.Definition_with_attrContext> nonStaticDefinitions) : base(CarpObject.Type, name, isStruct)
    {
        this._scope = new Scope(scope);
        this._staticDefinitions = staticDefinitions;
        this._nonStaticDefinitions = nonStaticDefinitions;
        
        // Create static definitions
        foreach (CarpGrammarParser.Definition_with_attrContext def in staticDefinitions)
            CarpInterpreter.Instance.Execute(this._scope, CarpInterpreter.Instance.GetDefinition(def).definitionContext);
    }

    public override CarpObject Instantiate(CarpObject[] args, bool isImplicit = false)
    {
        // Create instance
        Scope scope = new(this._scope);
        CarpObject obj = new CarpDynamic(this, scope);
        
        // Create non-static definitions
        foreach (CarpGrammarParser.Definition_with_attrContext def in this._nonStaticDefinitions)
            CarpInterpreter.Instance.Execute(scope, CarpInterpreter.Instance.GetDefinition(def).definitionContext);
        
        // Call constructor
        if (scope.Has("init"))
        {
            CarpObject init = scope.Get("init");
            if (init is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, init.GetCarpType());
            
            func.Call(args);
        }

        return obj;
    }

    public override CarpObject Property(string name)
    {
        return this._scope.Has(name) 
            ? this._scope.Get(name) 
            : base.Property(name);
    }
    
    public override CarpObject SetProperty(string name, CarpObject value)
    {
        this._scope.Set(name, value);
        return value;
    }
}

public class CarpDynamic : CarpObject
{
    private CarpClass _class;
    private Scope _scope;
    public CarpDynamic(CarpClass carpClass, Scope scope)
    {
        this._class = carpClass;
        this._scope = scope;
    }

    public override CarpString String()
    {
        if (this._scope.Has("string"))
        {
            CarpObject str = this._scope.Get("string");
            if (str is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, str.GetCarpType());

            return func.Call(Array.Empty<CarpObject>()).String();
        }

        return new($"instance of {this._class}");
    }

    public override CarpObject Property(string name)
    {
        if (this._scope.Has("property"))
        {
            CarpObject f = this._scope.Get("property");
            
        }
        else if (this._scope.Has(name))
            return this._scope.Get(name);
        
        throw new 
    }

    public override CarpType GetCarpType() => this._class;
}

public class AutoType : CarpType
{
    public static readonly AutoType Instance = new();
    public AutoType() : base(null, new("auto")) { }

    public override CarpObject Instantiate(CarpObject[] args, bool isImplicit = false) 
        => throw new InvalidOperationException("Cannot instantiate an auto type.");
}
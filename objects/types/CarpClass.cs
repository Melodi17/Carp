using Carp.interpreter;

namespace Carp.objects.types;

public class CarpClass : CarpType
{
    private readonly CarpInterpreter _interpreter;
    private List<CarpGrammarParser.Definition_with_attrContext> _staticDefinitions;
    private List<CarpGrammarParser.Definition_with_attrContext> _nonStaticDefinitions;
    private List<CarpMember> _members;
    private Scope _scope;
    private List<CarpType> _implementations;

    public CarpClass(CarpInterpreter interpreter, CarpString name, bool isStruct, IScope scope,
        CarpType parent, CarpType[] interfaces,
        List<CarpGrammarParser.Definition_with_attrContext> staticDefinitions,
        List<CarpGrammarParser.Definition_with_attrContext> nonStaticDefinitions) : base(parent, name,
        isStruct)
    {
        this._scope = new Scope(scope);

        // define our own type
        this._scope.Define(Signature.OfVariable(name.Native), this.GetCarpType(), this);

        this._interpreter = interpreter;
        this._staticDefinitions = staticDefinitions;
        this._nonStaticDefinitions = nonStaticDefinitions;
        this._members = new();

        // Create static definitions
        foreach (CarpGrammarParser.Definition_with_attrContext def in staticDefinitions)
        {
            (CarpObject[] attrs, CarpGrammarParser.DefinitionContext definitionContext) =
                this._interpreter.GetDefinition(scope, def);
            this._interpreter.Execute(this._scope, definitionContext);

            Signature sig = Signature.OfVariable(def.def.GetChild(1).GetText());

            CarpObject obj = this._scope.Get(sig);

            Signature fullSig = this._scope.GetSpecifications(sig).First();

            this._members.Add(new(fullSig, obj.GetCarpType(), obj, attrs));
        }
        
        _implementations = new();
        _implementations.Add(parent);
        _implementations.AddRange(interfaces);

        foreach (CarpType interfaceType in _implementations)
        {
            foreach (CarpMember? member in interfaceType.Members().Native.Cast<CarpMember>())
            {
                if (!member.IsStatic) // we only care about static members
                    continue;

                if (member.IsAbstract)
                {
                    if (!this._scope.Has(member.Name))
                        throw new CarpError.MissingImplementation(member.Name.ToString());
                }

                if (member.IsProtected)
                {
                    if (this._scope.Has(member.Name))
                        throw new CarpError.InvalidImplementation(member.Name.ToString());
                }

                CarpObject obj = member.Value;
                if (obj is CarpInternalFunc func) obj = func.Bind(this._scope);

                this._scope.Define(member.Name, member.ValueType, obj);
                this._members.Add(member);
            }
        }
    }

    public override CarpObject Instantiate(CarpObject[] args, bool isImplicit = false)
    {
        // Create instance
        Scope scope = new(this._scope);
        CarpObject obj = new CarpDynamic(this._interpreter, this, scope);

        // Create non-static definitions
        foreach (CarpGrammarParser.Definition_with_attrContext def in this._nonStaticDefinitions)
            this._interpreter.Execute(scope, this._interpreter.GetDefinition(this._scope, def).definitionContext);

        // Check implementations
        foreach (CarpType interfaceType in _implementations)
        foreach (CarpMember? member in interfaceType.Members().Native.Cast<CarpMember>())
        {
            if (member.IsStatic)
                continue;

            if (member.IsAbstract)
            {
                if (!scope.Has(member.Name))
                    throw new CarpError.MissingImplementation(member.Name.ToString());
            }

            if (member.IsProtected)
            {
                if (scope.Has(member.Name))
                    throw new CarpError.InvalidImplementation(member.Name.ToString());
            }

            CarpObject v = member.Value;
            if (v is CarpInternalFunc func) v = func.Bind(scope);

            scope.Define(member.Name, member.ValueType, v);
        }

        // Call constructor
        Signature sig = Signature.InitMethod.WithSpecific(CarpVoid.Type, args.Select(x => x.GetCarpType()).ToArray());
        if (scope.Has(sig))
        {
            CarpObject init = scope.Get(sig);
            if (init is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, init.GetCarpType());

            func.Call(args);
        }

        return obj;
    }

    public override CarpObject Property(Signature signature)
    {
        if (Equals(signature, Signature.NewCall))
            return new CarpExternalFunc(CarpObject.Type, (CarpObject[] args) => this.Instantiate(args),
                ignoreArgTypes: true);

        return this._scope.Has(signature)
            ? this._scope.Get(signature)
            : base.Property(signature);
    }

    public override CarpObject SetProperty(Signature signature, CarpObject value)
    {
        this._scope.Set(signature, value);
        return value;
    }

    public override CarpCollection Members()
    {
        // CarpCollection members = new(CarpMember.Type);
        // foreach (KeyValuePair<Signature, (CarpType type, CarpObject obj)> pair in this._scope)
        // {
        //     if (pair.Key.Equals(Signature.InitMethod))
        //         continue;
        //
        //     members.Add(new CarpMember(pair.Key, pair.Value.type, pair.Value.obj,
        // }

        return new(CarpMember.Type, this._members.ToArray());
    }
}
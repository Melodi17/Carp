using Carp.objects.types;

namespace Carp.interpreter;

public class Signature
{
    public static readonly Signature InitMethod = OfMethod("init");
    public static readonly Signature StringMethod = OfMethod("string", CarpString.Type);
    public static readonly Signature PropertyMethod = OfMethod("property");
    public static readonly Signature SetPropertyMethod = OfMethod("setproperty");
    public static readonly Signature CallMethod = OfMethod("call");
    public static readonly Signature IndexMethod = OfMethod("index");
    public static readonly Signature SetIndexMethod = OfMethod("setindex");
    public static readonly Signature AddMethod = OfMethod("add");
    public static readonly Signature SubtractMethod = OfMethod("subtract");
    public static readonly Signature MultiplyMethod = OfMethod("multiply");
    public static readonly Signature DivideMethod = OfMethod("divide");
    public static readonly Signature ModulusMethod = OfMethod("modulus");
    public static readonly Signature LessMethod = OfMethod("less", CarpBool.Type);
    public static readonly Signature GreaterMethod = OfMethod("greater", CarpBool.Type);
    public static readonly Signature PowMethod = OfMethod("pow");
    public static readonly Signature MatchMethod = OfMethod("match");
    public static readonly Signature StepMethod = OfMethod("step");
    public static readonly Signature NegateMethod = OfMethod("negate");
    public static readonly Signature IterateMethod = OfMethod("iterate");
    
    public static readonly Signature NewCall = OfMethod("new");
    
    public static readonly Signature ThisVariable = OfVariable("this");

    private Signature(string name, string? specific = null)
    {
        this.Name = name;
        this.Specific = specific;
    }

    public static Signature OfVariable(string name) => new(name);
    public static Signature OfMethod(string name, CarpFunc func) => OfMethod(name, func.ReturnType, func.ArgTypes);
    
    public static Signature OfMethod(string name, CarpType returnType, params CarpType[] argTypes) => new(name,
        $"{returnType};{string.Join(",", argTypes.Select(x => x.ToString()))}");
    
    public static Signature OfMethod(string name) => new(name);

    public string Name { get; }
    public string? Specific { get; }

    public override string ToString()
    {
        return this.Specific == null ? this.Name : $"{this.Name}::{this.Specific}";
    }

    public bool Includes(Signature other) =>
        this.Name == other.Name && (this.Specific == null || other.Specific == null || this.Specific == other.Specific || this.Specific.StartsWith(other.Specific));

    public Signature WithSpecific(string specific)
    {
        return new(this.Name, specific);
    }
    
    public Signature WithSpecific(CarpType returnType, params CarpType[] argTypes)
    {
        return OfMethod(this.Name, returnType, argTypes);
    }

    // comparisons
    public override bool Equals(object? obj)
    {
        if (obj is Signature sig)
            return this.Name == sig.Name && this.Specific == sig.Specific;
        return false;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + (this.Specific?.GetHashCode() ?? 0);
    }
}
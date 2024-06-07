using Carp.interpreter;

namespace Carp.objects.types;

public class CarpString : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpString>("str");
    public override CarpType GetCarpType() => Type;

    private readonly string _value;

    public string Native => this._value;

    public CarpString(string v)
    {
        this._value = v;
    }

    public override CarpObject Add(CarpObject other)
    {
        if (other is CarpString cs)
            return new CarpString(this._value + cs.Native);
        else
            return new CarpString(this._value + other.String().Native);
    }

    public override CarpObject Multiply(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, other.GetCarpType());

        return new CarpString(
            string.Join("", Enumerable.Repeat(this._value, ci.NativeInt)));
    }

    public override CarpObject Divide(CarpObject other)
    {
        // split it
        if (other is not CarpString or CarpChar)
            throw new CarpError.InvalidType(new List<CarpType>() { CarpChar.Type, CarpString.Type },
                other.GetCarpType());

        string[] chunks = this._value.Split(other.String().Native);
        return new CarpCollection(CarpString.Type, chunks.Select(x => new CarpString(x)).ToArray());
    }

    public override CarpObject Cast(CarpType t)
    {
        if (t == CarpInt.Type)
        {
            try
            {
                return new CarpInt(double.Parse(this._value));
            }
            catch (FormatException fe)
            {
                throw new CarpError.UnparseableInt(this._value);
            }
        }

        if (t == CarpChar.Type)
        {
            return new CarpChar(this._value.First());
        }

        if (t == CarpBool.Type)
        {
            if (this._value == "true")
                return CarpBool.True;
            else if (this._value == "false")
                return CarpBool.False;
            else
                throw new CarpError.InvalidCast(this, t);
        }

        return base.Cast(t);
    }

    public override CarpIterator Iterate()
    {
        IEnumerable<CarpObject> Iter()
        {
            foreach (char c in this._value)
                yield return new CarpChar(c);
        }

        return new CarpEnumerableIterator(CarpChar.Type, Iter());
    }

    public override CarpObject Index(CarpObject[] args)
    {
        if (args.Length != 1)
            throw new CarpError.InvalidParameterCount(1, args.Length);

        if (args[0] is CarpRange range && range.ItemType == CarpInt.Type)
        {
            if (range.Start is not CarpInt start)
                throw new CarpError.InvalidType(CarpInt.Type, range.Start.GetCarpType());
            if (range.Stop is not CarpInt end)
                throw new CarpError.InvalidType(CarpInt.Type, range.Stop.GetCarpType());

            return new CarpString(this._value.Substring(start.NativeInt, end.NativeInt - start.NativeInt));
        }

        if (args[0] is not CarpInt)
            args[0] = args[0].CastEx(CarpInt.Type);

        int index = (args[0] as CarpInt)!.NativeInt;
        if (index < 0 || index >= this._value.Length)
            throw new CarpError.IndexOutOfRange(index);

        return new CarpChar(this._value[index]);
    }

    private CarpBool Contains(CarpString inner) => CarpBool.Of(this._value.Contains(inner._value));

    private CarpCollection Split(CarpString delim)
    {
        string[] chunks = this._value.Split(delim._value);
        return new(CarpString.Type, chunks.Select(x => new CarpString(x)).ToArray());
    }

    private CarpString Replace(CarpString source, CarpString replacement)
    {
        return new(this._value.Replace(source._value, replacement._value));
    }

    private CarpBool StartsWith(CarpString prefix) => CarpBool.Of(this._value.StartsWith(prefix._value));
    private CarpBool EndsWith(CarpString suffix) => CarpBool.Of(this._value.EndsWith(suffix._value));

    public override CarpObject Property(Signature signature)
    {
        return signature.Name switch
        {
            "length" => new CarpInt(this._value.Length),
            "lower" => new CarpString(this._value.ToLower()),
            "upper" => new CarpString(this._value.ToUpper()),
            "clean" => new CarpString(this._value.Trim()),
            "split" => new CarpExternalFunc(CarpCollection.Type, this.Split),
            "contains" => new CarpExternalFunc(CarpBool.Type, this.Contains),
            "replace" => new CarpExternalFunc(CarpString.Type, this.Replace),
            "startswith" => new CarpExternalFunc(CarpBool.Type, this.StartsWith),
            "endswith" => new CarpExternalFunc(CarpBool.Type, this.EndsWith),
            _ => throw new CarpError.InvalidProperty(signature),
        };
    }

    public override CarpString String() => new(this._value);
    public override string Repr() => $"'{this._value}'";

    public override CarpBool Match(CarpObject other)
    {
        if (other is not CarpString cs)
            throw new CarpError.InvalidType(CarpString.Type, other.GetCarpType());

        return CarpBool.Of(this._value == cs._value);
    }
}
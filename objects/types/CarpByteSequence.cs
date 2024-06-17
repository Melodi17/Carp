using System.Text;
using Carp.interpreter;

namespace Carp.objects.types;

public class CarpByteSequence : CarpObject
{
    public static CarpType Type = NativeType.Of<CarpByteSequence>("byte_sequence");
    public override CarpType GetCarpType() => Type;

    private readonly byte[] _value;

    public byte[] Native => this._value;
    
    public CarpByteSequence(byte[] v)
    {
        this._value = v;
    }

    public override CarpString String() => new($"byte_sequence({this._value.Length})");

    public override CarpObject Index(CarpObject[] args)
    {
        // allow int, or range
        if (args.Length != 1)
            throw new CarpError.InvalidParameterCount(1, args.Length);

        if (args[0] is CarpRange range && range.ItemType == CarpInt.Type)
        {
            int start = (range.Start as CarpInt)!.NativeInt;
            int end = (range.Stop as CarpInt)!.NativeInt;
            
            if (start < 0 || end >= this._value.Length)
                throw new CarpError.IndexOutOfRange(end);
            
            return new CarpByteSequence(this._value[start..end]);
        }
        
        if (args[0] is not CarpInt)
            args[0] = args[0].CastEx(CarpInt.Type);
        
        int index = (args[0] as CarpInt)!.NativeInt;
        if (index < 0 || index >= this._value.Length)
            throw new CarpError.IndexOutOfRange(index);
        
        return new CarpInt(this._value[index]);
    }

    public override CarpObject Property(Signature signature)
    {
        return signature.Name switch
        {
            "length" => new CarpInt(this._value.Length),
            "decode" => new CarpExternalFunc(CarpString.Type, this.Decode),
            _ => throw new CarpError.InvalidProperty(signature),
        };
    }

    private CarpString Decode(CarpString format)
    {
        Encoding enc = EncodingFromName(format);

        return new(enc.GetString(this._value));
    }

    public static Encoding EncodingFromName(CarpString format)
    {
        Encoding enc = format.Native switch
        {
            "utf8" => Encoding.UTF8,
            "utf32" => Encoding.UTF32,
            "unicode" => Encoding.Unicode,
            "bigendianunicode" => Encoding.BigEndianUnicode,
            "latin" => Encoding.Latin1,
            "ascii" => Encoding.ASCII
        };
        return enc;
    }
    
    public override CarpBool Match(CarpObject other)
    {
        if (other is not CarpByteSequence cbs)
            throw new CarpError.InvalidType(CarpByteSequence.Type, other.GetCarpType());

        return CarpBool.Of(this._value.SequenceEqual(cbs._value));
    }
}
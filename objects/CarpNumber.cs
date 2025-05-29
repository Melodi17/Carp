using System.Numerics;
using Carp.exceptions;
using Carp.exceptions.impl;
using Carp.objects.typing;
using Carp.scoping;

namespace Carp.objects;

public abstract class CarpNumber(CarpType type) : CarpObject(type)
{
    public override abstract CarpType GetCarpType();
    public override abstract CarpString String();

    // i8, i16, i32, i64, i128, u8, u16, u32, u64, u128, f32, f64, arb
    protected static Dictionary<string, (CarpType Type, Func<object, CarpNumber> Creator)>? _creators;
    public static void ConstructAllTypes()
    {
        _creators = new();

        ConstructType<sbyte>("i8");
        ConstructType<short>("i16");
        ConstructType<int>("i32");
        ConstructType<long>("i64");
        ConstructType<byte>("u8");
        ConstructType<ushort>("u16");
        ConstructType<uint>("u32");
        ConstructType<ulong>("u64");
        ConstructType<float>("f32");
        ConstructType<double>("f64");
        ConstructType<BigInteger>("arb");
    }

    public static CarpType[] AllTypes
    {
        get
        {
            if (_creators == null)
                ConstructAllTypes();

            return _creators.Values.Select(c => c.Type).ToArray();
        }
    }

    private static void ConstructType<T>(string name) where T : struct, IComparable<T>, IEquatable<T>, IAdditionOperators<T, T, T>,
        ISubtractionOperators<T, T, T>, IMultiplyOperators<T, T, T>, IDivisionOperators<T, T, T>,
        IModulusOperators<T, T, T>, IComparisonOperators<T, T, bool>, IUnaryNegationOperators<T, T>,
        IParsable<T>, IFormattable
    {
        CarpType carpType = CarpType.Create(name, CarpObject.Type);
        carpType.Group = "number";
        _creators[name] = (
            carpType,
            value =>
            {
                try
                {
                    return CarpNumber<T>.CreateDirect((T)ConvertTo<T>(value), carpType);
                }
                catch (OverflowException)
                {
                    throw new NumericDataOverflowException(value.ToString(), carpType);
                }
            }
        );
    }

    private static object ConvertTo<T>(object value)
    {
        if (typeof(T) == typeof(BigInteger))
        {
            return value switch 
            {
                int i => new BigInteger(i),
                long l => new BigInteger(l),
                double d => new BigInteger(d),
                float f => new BigInteger(f),
                sbyte sb => new BigInteger(sb),
                short sh => new BigInteger(sh),
                byte b => new BigInteger(b),
                ushort us => new BigInteger(us),
                uint ui => new BigInteger(ui),
                ulong ul => new BigInteger(ul),
                BigInteger bi => bi,
                _ => throw new InvalidCastException($"Cannot convert {value.GetType()} to {typeof(T)}")
            };
        }

        // Use Convert.ChangeType for other numeric types
        return Convert.ChangeType(value, typeof(T));
    }


    public static CarpNumber Create(string typeName, object value)
    {
        if (_creators == null)
            ConstructAllTypes();

        if (_creators.TryGetValue(typeName, out var creator))
        {
            return creator.Creator(value);
        }
        throw new InterpreterException($"Unknown number type: {typeName}");
    }

    public static CarpNumber Create(int value)
        => Create("i32", value); // Default to i32 if no type is specified

    public static CarpNumber Create(double value)
        => Create("f64", value); // Default to f64 if no type is specified

    public T Coerce<T>(CarpType newType) where T : CarpNumber
    {
        return ((T)this.Coerce(newType));
    }
}

public class CarpNumber<T> : CarpNumber
    where T : struct, IComparable<T>, IEquatable<T>, IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>,
    IMultiplyOperators<T, T, T>, IDivisionOperators<T, T, T>, IModulusOperators<T, T, T>,
    IComparisonOperators<T, T, bool>, IUnaryNegationOperators<T, T>, IParsable<T>, IFormattable
{
    private readonly CarpType _type;
    public override CarpType GetCarpType() => this._type;
    public T Value { get; }

    private static readonly Dictionary<T, CarpNumber<T>> Cache = new();

    private CarpNumber(T value, CarpType type) : base(type)
    {
        this._type = type;
        this.Value = value;
    }

    public static CarpNumber<T> CreateDirect(T value, CarpType type)
    {
        if (Cache.TryGetValue(value, out CarpNumber<T>? cached))
            return cached;

        CarpNumber<T> number = new(value, type);
        Cache[value] = number;
        return number;
    }

    private T CoerceValue(CarpNumber number)
    {
        return number.Coerce<CarpNumber<T>>(this._type).Value;
    }

    public override CarpObject Add(CarpObject right) => right is CarpNumber number
        ? CarpNumber<T>.CreateDirect(this.Value + CoerceValue(number), this._type)
        : base.Add(right);
    public override CarpObject Subtract(CarpObject right) => right is CarpNumber number
        ? CarpNumber<T>.CreateDirect(this.Value - this.CoerceValue(number), this._type)
        : base.Subtract(right);
    public override CarpObject Multiply(CarpObject right) => right is CarpNumber number
        ? CarpNumber<T>.CreateDirect(this.Value * this.CoerceValue(number), this._type)
        : base.Multiply(right);
    public override CarpObject Divide(CarpObject right) => right is CarpNumber number
        ? CarpNumber<T>.CreateDirect(this.Value / this.CoerceValue(number), this._type)
        : base.Divide(right);
    public override CarpObject Power(CarpObject right)
    {
        if (right is not CarpNumber number) throw new PrimitiveIncompatibleException("Power", this);
        
        if (Value is BigInteger bigInt && right is CarpNumber<BigInteger> bigIntNumber)
            return CarpNumber<BigInteger>.CreateDirect(BigInteger.Pow(bigInt, (int)bigIntNumber.Value), this._type);

        if (Value is double dbl && right is CarpNumber<double> dblNumber)
            return CarpNumber<double>.CreateDirect(Math.Pow(dbl, dblNumber.Value), this._type);

        if (Value is float flt && right is CarpNumber<float> fltNumber)
            return CarpNumber<float>.CreateDirect(MathF.Pow(flt, fltNumber.Value), this._type);

        if (Value is int integer && right is CarpNumber<int> intNumber)
            return CarpNumber<int>.CreateDirect((int)Math.Pow(integer, intNumber.Value), this._type);

        if (Value is long lng && right is CarpNumber<long> longNumber)
            return CarpNumber<long>.CreateDirect((long)Math.Pow(lng, longNumber.Value), this._type);

        throw new PrimitiveIncompatibleException("Power", this);
    }
    public override CarpObject Modulus(CarpObject right) => right is CarpNumber<T> number
        ? CarpNumber<T>.CreateDirect(this.Value % number.Value, this._type)
        : base.Modulus(right);

    public override CarpObject Less(CarpObject right) => right is CarpNumber<T> number
        ? CarpBoolean.Create(this.Value < number.Value)
        : base.Less(right);

    public override CarpObject Greater(CarpObject right) => right is CarpNumber<T> number
        ? CarpBoolean.Create(this.Value > number.Value)
        : base.Greater(right);

    public override CarpObject LeftShift(CarpObject right)
    {
        if (right is CarpNumber<T> number)
        {
            if (Value is int intValue && number.Value is int intShift)
                return CarpNumber<int>.CreateDirect(intValue << intShift, this._type);
            if (Value is byte byteValue && number.Value is byte byteShift)
                return CarpNumber<byte>.CreateDirect((byte)(byteValue << byteShift), this._type);
            if (Value is short shortValue && number.Value is short shortShift)
                return CarpNumber<short>.CreateDirect((short)(shortValue << shortShift), this._type);
            if (Value is ushort ushortValue && number.Value is ushort ushortShift)
                return CarpNumber<ushort>.CreateDirect((ushort)(ushortValue << ushortShift), this._type);
            if (Value is BigInteger bigIntValue && number.Value is BigInteger bigIntShift)
                return CarpNumber<BigInteger>.CreateDirect(bigIntValue << (int)bigIntShift, this._type);
        }
        throw new PrimitiveIncompatibleException("LeftShift", this);
    }

    public override CarpObject RightShift(CarpObject right)
    {
        if (right is CarpNumber<T> number)
        {
            if (Value is int intValue && number.Value is int intShift)
                return CarpNumber<int>.CreateDirect(intValue >> intShift, this._type);
            if (Value is byte byteValue && number.Value is byte byteShift)
                return CarpNumber<byte>.CreateDirect((byte)(byteValue >> byteShift), this._type);
            if (Value is short shortValue && number.Value is short shortShift)
                return CarpNumber<short>.CreateDirect((short)(shortValue >> shortShift), this._type);
            if (Value is ushort ushortValue && number.Value is ushort ushortShift)
                return CarpNumber<ushort>.CreateDirect((ushort)(ushortValue >> ushortShift), this._type);
            if (Value is BigInteger bigIntValue && number.Value is BigInteger bigIntShift)
                return CarpNumber<BigInteger>.CreateDirect(bigIntValue >> (int)bigIntShift, this._type);
        }
        throw new PrimitiveIncompatibleException("RightShift", this);
    }

    public override CarpObject Negate() => CarpNumber<T>.CreateDirect(-this.Value, this._type);
    public override CarpString String() => CarpString.Create(this.Value.ToString());
    public override CarpObject Equal(CarpObject right)
    {
        // try to coerce CarpNumber to CarpNumber<T>
        if (right is CarpNumber<T> number)
            return CarpBoolean.Create(this.Value.Equals(number.Value));
        if (right is CarpNumber numberObj)
        {
            CarpNumber<T>? coerced = numberObj.Coerce(this.GetCarpType()) as CarpNumber<T>;
            if (coerced != null)
                return CarpBoolean.Create(this.Value.Equals(coerced.Value));
        }

        return CarpBoolean.False;
    }

    // All numbers can be coerced to any other number type
    public override CarpObject Coerce(CarpType type)
    {
        if (_creators.TryGetValue(type.Name, out var creator))
            return creator.Creator(this.Value);

        return base.Coerce(type);
    }
}
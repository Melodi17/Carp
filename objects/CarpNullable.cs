// namespace Carp.objects;
//
// using exceptions.impl;
// using scoping;
// using typing;
//
// public class CarpNullable : CarpObject
// {
//     public new static readonly CarpType Type = CarpType.Create("nullable", CarpObject.Type);
//     private readonly CarpType _valueType;
//     public CarpObject Value;
//     public CarpNullable(CarpType valueType, CarpObject value) : base(CarpType.CreateGeneric(CarpNullable.Type, valueType))
//     {
//         this._valueType = valueType;
//         
//         // Avoid coercing CarpNull to a specific type, since this will throw an exception
//         if (value is CarpNull n)
//             this.Value = n;
//         else
//             this.Value = value.Coerce(valueType);
//     }
//     public override CarpType GetCarpType() => CarpType.CreateGeneric(CarpNullable.Type, this._valueType);
//     public override CarpString String() => this.Value.String();
//
//     public override CarpObject Coerce(CarpType type)
//     {
//         if (type.Extends(this._valueType))
//         {
//             // This will throw an exception if value is null, which is the intended behavior
//             return this.Value.Coerce(type);
//         }
//
//         return base.Coerce(type);
//     }
// }


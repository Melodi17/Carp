using System.Text;
using Carp.objects.typing;

namespace Carp.objects;

// public class CarpCollection : CarpObject
// {
//     private readonly CarpType _itemType;
//     public List<CarpObject> Items { get; }
//     public CarpCollection(CarpType itemType, List<CarpObject> items)
//     {
//         this._itemType = itemType;
//         this.Items = items;
//     }
//     public override CarpString String()
//     {
//         return CarpString.Create($"[" +
//                                  $"{string.Join(", ", this.Items.Select(i => i.Repr()))}" +
//                                  $"]");
//     }
// }
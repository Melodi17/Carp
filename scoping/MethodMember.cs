using Carp.objects;

namespace Carp.scoping;

// public class MethodMember : Member
// {
//     private readonly List<CarpFunc> _overloads;
//
//     public MethodMember(Visibility visibility, params CarpFunc[] overloads)
//         : base(visibility)
//     {
//         _overloads = overloads.ToList();
//     }
//
//     public override CarpObject Get(CarpObject self)
//     {
//         // Wrap dispatch into a new external func that selects the right overload
//         return new CarpExternalFunc(ResolveReturnType(), args => Dispatch(self, args));
//     }
//
//     private CarpObject Dispatch(CarpObject self, CarpObject[] args)
//     {
//         foreach (var overload in _overloads)
//         {
//             if (overload.Accepts(args))
//                 return overload.Invoke(self, args);
//         }
//
//         throw new CarpError.NoMatchingOverload(args.Length);
//     }
//
//     private CarpType ResolveReturnType()
//     {
//         // Optional: union of return types, or just first
//         return _overloads[0].ReturnType;
//     }
// }
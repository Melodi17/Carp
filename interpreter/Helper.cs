using Carp.objects.types;

namespace Carp.interpreter;

public static class Helper
{
    public static CarpObject CastEx(this CarpObject source, CarpType dest, bool isImplicit = true)
    {
        // This is already done by the one below.
        //if (source.GetCarpType() == dest)
        //    return source;

        if (dest == AutoType.Instance)
            throw new CarpError.VagueTypeSpecificationError(source);
        
        // if source derives from dest, then we can cast.
        if (source.GetCarpType().Extends(dest))
            return source;
        
        // If Flags.Instance.ImplicitCasting is false, then we don't allow implicit casting.
        if (!Flags.Instance.ImplicitCasting && isImplicit)
            throw new CarpError.InvalidType(dest, source.GetCarpType());

        if (source == CarpNull.Instance)
        {
            if (dest.IsStruct) throw new CarpError.CastNullToStruct(dest);

            return source;
        }
        
        // Else cast!
        return source.Cast(dest);
    }
}

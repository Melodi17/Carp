namespace Carp.objects.types;

public abstract class CarpFunc<T> : CarpObject
    where T : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpFunc<T>>(
        new($"func<{CarpType.GetType<T>()
            .String().Native}>"));

    public override abstract CarpObject Call(CarpObject[] args);

    public override CarpString String() 
        => new($"func<{CarpType.GetType<T>()
            .String().Native}>");
}
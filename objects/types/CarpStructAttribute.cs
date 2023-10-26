namespace Carp.objects.types;

public class CarpStructAttribute : Attribute
{
    public object[] DefaultArgs;
    
    public CarpStructAttribute(params object[] defaultArgs)
    {
        this.DefaultArgs = defaultArgs;
    }
}

public class CarpGenericConstructorAttribute : Attribute
{
    
}
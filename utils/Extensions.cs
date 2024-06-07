using System.IO.Compression;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Carp;

public static class Extensions
{
    /// <summary>
    /// Returns the type name. If this is a generic type, appends
    /// the list of generic type arguments between angle brackets.
    /// (Does not account for embedded / inner generic arguments.)
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>System.String.</returns>
    public static string GetFormattedName(this Type type)
    {
        if(type.IsGenericType)
        {
            string genericArguments = type.GetGenericArguments()
                .Select(x => x.Name)
                .Aggregate((x1, x2) => $"{x1}, {x2}");
            return $"{type.Name[..type.Name.IndexOf('`')]}"
                + $"<{genericArguments}>";
        }
        return type.Name;
    }

    public static bool ContainsKeySlow<TK, TV>(this Dictionary<TK, TV> source, TK key) => source.Keys.Any(x => x.Equals(key));
    public static TV GetValueSlow<TK, TV>(this Dictionary<TK, TV> source, TK key) => source[source.Keys.First(x => x.Equals(key))];
    public static void SetValueSlow<TK, TV>(this Dictionary<TK, TV> source, TK key, TV value) => source[source.Keys.First(x => x.Equals(key))] = value;
    public static bool RemoveSlow<TK, TV>(this Dictionary<TK, TV> source, TK key) => source.Remove(source.Keys.First(x => x.Equals(key)));

    public static TDecendant FirstOf<TDecendant, TParent>(this IEnumerable<TParent> col)
        where TDecendant : class, TParent
        => col.First(x => x is TDecendant) as TDecendant;
    
    public static IEnumerable<TDecendant> WhereOf<TDecendant, TParent>(this IEnumerable<TParent> col)
        where TDecendant : class, TParent
        => col.Where(x => x is TDecendant).Select(x => x as TDecendant);

    public static T With<T>(this T obj, Action<T> act)
    {
        act(obj);
        return obj;
    }

    public static T Sync<T>(this Task<T> task)
    {
        return task.GetAwaiter().GetResult();
    }
    
    public static Delegate CreateDelegate(this MethodInfo methodInfo, object? target)
    {
        var parmTypes = methodInfo.GetParameters().Select(parm => parm.ParameterType);
        var parmAndReturnTypes = parmTypes.Append(methodInfo.ReturnType).ToArray();
        var delegateType = Expression.GetDelegateType(parmAndReturnTypes);

        if (methodInfo.IsStatic)
            return methodInfo.CreateDelegate(delegateType);
        return methodInfo.CreateDelegate(delegateType, target);
    }
    
    public static string GetFileDataString(this ZipArchiveEntry entry)
    {
        using StreamReader reader = new(entry.Open());
        return reader.ReadToEnd();
    }
    
    public static byte[] GetFileDataBytes(this ZipArchiveEntry entry)
    {
        using MemoryStream stream = new();
        entry.Open().CopyTo(stream);
        return stream.ToArray();
    }
}
using System.IO.Compression;

namespace Carp.utils;

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
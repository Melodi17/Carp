namespace Carp.toolkit;

using System.Reflection;
using utils;

public class NativeLibrary(Assembly asm, string startPath) : ILibrary
{
    public string Name => asm.GetName().Name;
    
    public IEnumerable<IModule> GetModules()
    {
        return asm
            .GetTypes()
            .Where(x => x.Namespace?.StartsWith(startPath) ?? false)
            .Select(x=> (ns: Formatting.FormatNamespace(x.Namespace![startPath.Length..]).TrimStart('.'), type: x))
            .Select(x => new NativeTypeModule(this, x.ns, x.type));
    }
}
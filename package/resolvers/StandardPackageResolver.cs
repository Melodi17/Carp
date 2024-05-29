using System.IO.Compression;
using System.Net;
using Carp.interpreter;
using Carp.objects.types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Carp.package.resolvers;

public class StandardPackageResolver : IPackageResolver
{
    private Package CreatePackage(string name, params (Signature, CarpObject)[] exports)
    {
        CarpStatic cs = new(name);
        foreach ((Signature key, CarpObject value) in exports)
            cs.DefineProperty(key, value.GetCarpType(), value);
        return new(this, this, name, export: i => cs);
    }

    private (Signature, CarpObject) Export(string key, CarpObject value)
    {
        return value is CarpFunc func
            ? (Signature.OfMethod(key, func), func)
            : (Signature.OfVariable(key), value);
    }

    private CarpStatic Sub(string name, params (Signature, CarpObject)[] exports)
    {
        CarpStatic cs = new(name);
        foreach ((Signature key, CarpObject value) in exports)
            cs.DefineProperty(key, value.GetCarpType(), value);
        return cs;
    }

    public Package GetPackage(string[] fullPath, string[] path, string version = "latest")
    {
        string j = string.Join(".", path);
        return j switch
        {
            "io" => this.IO(version),
            "fs" => this.FS(version),
            "math" => this.Math(version),
            "net" => this.Net(version),
            _ => throw new CarpError.PackageNotFound(fullPath, version),
        };
    }

    public Package IO(string version)
    {
        return this.CreatePackage("IO",
            this.Export("println",
                new CarpExternalFunc(CarpVoid.Type, (CarpObject str) => { Console.WriteLine(str.String().Native); })),
            this.Export("printw",
                new CarpExternalFunc(CarpVoid.Type, (CarpObject str) => { Console.Write(str.String().Native); })),
            this.Export("readln",
                new CarpExternalFunc(CarpString.Type, (CarpObject str) =>
                {
                    Console.Write(str.String().Native);
                    return new CarpString(Console.ReadLine());
                })),
            this.Export("readw",
                new CarpExternalFunc(CarpChar.Type, (CarpBool hideKeyStrokes)
                    => new CarpChar(Console.ReadKey(hideKeyStrokes.Native).KeyChar))),
            this.Export("clear",
                new CarpExternalFunc(CarpVoid.Type, ()
                    => Console.Clear())),
            this.Export("move",
                new CarpExternalFunc(CarpVoid.Type, (CarpInt x, CarpInt y)
                    => Console.SetCursorPosition(x.NativeInt, y.NativeInt)))
        );
    }

    public Package FS(string version)
    {
        return this.CreatePackage("FS",
            this.Export("readfile",
                new CarpExternalFunc(CarpString.Type, (CarpObject path)
                    => new CarpString(File.ReadAllText(path.String().Native)))),
            this.Export("readfilelines", new CarpExternalFunc(CarpCollection.Type.With(CarpString.Type),
                (CarpObject path)
                    => new CarpCollection(CarpString.Type, File.ReadAllLines(path.String().Native)
                        .Select(x => new CarpString(x)).ToArray()))),
            this.Export("writefile",
                new CarpExternalFunc(CarpVoid.Type,
                    (CarpObject path, CarpObject cont)
                        => File.WriteAllText(path.String().Native, cont.String().Native))),
            this.Export("writefilelines",
                new CarpExternalFunc(CarpVoid.Type, (CarpObject path, CarpCollection cont)
                    => File.WriteAllLines(path.String().Native,
                        cont.Native.Select(x => x.String().Native).ToArray()))),
            this.Export("exists", new CarpExternalFunc(CarpBool.Type, (CarpObject path)
                => CarpBool.Of(File.Exists(path.String().Native)))),
            this.Export("delete", new CarpExternalFunc(CarpVoid.Type, (CarpObject path)
                => File.Delete(path.String().Native)))
        );
    }

    public Package Math(string version)
    {
        return this.CreatePackage("Math",
            this.Export("random",
                new CarpExternalFunc(CarpInt.Type, (CarpInt min, CarpInt max)
                    => new CarpInt(new Random().Next(min.NativeInt, max.NativeInt)))),
            this.Export("chance",
                new CarpExternalFunc(CarpBool.Type, (CarpInt chance)
                    => new CarpInt(new Random().Next(0, 100)).Greater(chance))),
            this.Export("wait",
                new CarpExternalFunc(CarpVoid.Type, (CarpInt ms)
                    => Thread.Sleep(ms.NativeInt)))
        );
    }

    public Package Net(string version)
    {
        return this.CreatePackage("Net",
            this.Export("http",
                this.Sub("http",
                    this.Export("get",
                        new CarpExternalFunc(CarpString.Type, (CarpObject url) =>
                        {
                            using WebClient wc = new();
                            return new CarpString(wc.DownloadString(url.String().Native));
                        })))
            )
        );
    }
}
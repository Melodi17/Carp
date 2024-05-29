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
        void Println(CarpObject str) => Console.WriteLine(str.String().Native);

        void Printw(CarpObject str) => Console.Write(str.String().Native);

        CarpString Readln(CarpObject str)
        {
            Console.Write(str.String().Native);
            return new CarpString(Console.ReadLine());
        }

        CarpChar Readw(CarpBool hideKeyStrokes) => new(Console.ReadKey(hideKeyStrokes.Native).KeyChar);

        void Clear() => Console.Clear();

        void Move(CarpInt x, CarpInt y) => Console.SetCursorPosition(x.NativeInt, y.NativeInt);

        return this.CreatePackage("IO",
            this.Export("println", new CarpExternalFunc(CarpVoid.Type, Println)),
            this.Export("printw", new CarpExternalFunc(CarpVoid.Type, Printw)),
            this.Export("readln", new CarpExternalFunc(CarpString.Type, Readln)),
            this.Export("readw", new CarpExternalFunc(CarpChar.Type, Readw)),
            this.Export("clear", new CarpExternalFunc(CarpVoid.Type, Clear)),
            this.Export("move", new CarpExternalFunc(CarpVoid.Type, Move))
        );
    }

    public Package FS(string version)
    {
        CarpString ReadFile(CarpObject path) => new(File.ReadAllText(path.String().Native));

        CarpCollection ReadFileLines(CarpObject path) =>
            new(CarpString.Type, File.ReadAllLines(path.String().Native)
                .Select(x => new CarpString(x)).ToArray());

        void WriteFile(CarpObject path, CarpObject cont) =>
            File.WriteAllText(path.String().Native, cont.String().Native);

        void WriteFileLines(CarpObject path, CarpCollection cont) => File.WriteAllLines(path.String().Native,
            cont.Native.Select(x => x.String().Native).ToArray());

        CarpBool Exists(CarpObject path) => CarpBool.Of(File.Exists(path.String().Native));

        void Delete(CarpObject path) => File.Delete(path.String().Native);

        void CreateDir(CarpObject path) => Directory.CreateDirectory(path.String().Native);

        void DeleteDir(CarpObject path) => Directory.Delete(path.String().Native, true);

        CarpCollection ListDir(CarpObject path) => new(CarpString.Type,
            Directory.GetFiles(path.String().Native).Select(x => new CarpString(x)).ToArray());

        CarpCollection ListDirs(CarpObject path) => new(CarpString.Type,
            Directory.GetDirectories(path.String().Native).Select(x => new CarpString(x)).ToArray());

        return this.CreatePackage("FS",
            this.Export("readfile", new CarpExternalFunc(CarpString.Type, ReadFile)),
            this.Export("readfilelines",
                new CarpExternalFunc(CarpCollection.Type.With(CarpString.Type), ReadFileLines)),
            this.Export("writefile", new CarpExternalFunc(CarpVoid.Type, WriteFile)),
            this.Export("writefilelines", new CarpExternalFunc(CarpVoid.Type, WriteFileLines)),
            this.Export("exists", new CarpExternalFunc(CarpBool.Type, Exists)),
            this.Export("delete", new CarpExternalFunc(CarpVoid.Type, Delete)),
            this.Export("createdir", new CarpExternalFunc(CarpVoid.Type, CreateDir)),
            this.Export("deletedir", new CarpExternalFunc(CarpVoid.Type, DeleteDir)),
            this.Export("listdir", new CarpExternalFunc(CarpCollection.Type.With(CarpString.Type), ListDir)),
            this.Export("listdirs", new CarpExternalFunc(CarpCollection.Type.With(CarpString.Type), ListDirs))
        );
    }

    public Package Math(string version)
    {
        CarpInt Random(CarpInt min, CarpInt max) => new(new Random().Next(min.NativeInt, max.NativeInt));

        CarpBool Chance(CarpInt chance) => new CarpInt(new Random().Next(0, 100)).Greater(chance);

        void Wait(CarpInt ms) => Thread.Sleep(ms.NativeInt);

        CarpInt Abs(CarpInt num) => new(System.Math.Abs(num.Native));

        CarpInt Ceil(CarpInt num) => new(System.Math.Ceiling(num.Native));

        CarpInt Floor(CarpInt num) => new(System.Math.Floor(num.Native));

        CarpInt Round(CarpInt num) => new(System.Math.Round(num.Native));

        CarpInt Max(CarpInt a, CarpInt b) => new(System.Math.Max(a.Native, b.Native));

        CarpInt Min(CarpInt a, CarpInt b) => new(System.Math.Min(a.Native, b.Native));

        CarpInt Clamp(CarpInt num, CarpInt min, CarpInt max) =>
            new(System.Math.Clamp(num.Native, min.Native, max.Native));

        CarpInt Sqrt(CarpInt num) => new((int)System.Math.Sqrt(num.Native));

        CarpInt Pow(CarpInt num, CarpInt pow) => new((int)System.Math.Pow(num.Native, pow.Native));


        return this.CreatePackage("Math",
            this.Export("random", new CarpExternalFunc(CarpInt.Type, Random)),
            this.Export("chance", new CarpExternalFunc(CarpBool.Type, Chance)),
            this.Export("wait", new CarpExternalFunc(CarpVoid.Type, Wait)),
            this.Export("abs", new CarpExternalFunc(CarpInt.Type, Abs)),
            this.Export("ceil", new CarpExternalFunc(CarpInt.Type, Ceil)),
            this.Export("floor", new CarpExternalFunc(CarpInt.Type, Floor)),
            this.Export("round", new CarpExternalFunc(CarpInt.Type, Round)),
            this.Export("max", new CarpExternalFunc(CarpInt.Type, Max)),
            this.Export("min", new CarpExternalFunc(CarpInt.Type, Min)),
            this.Export("clamp", new CarpExternalFunc(CarpInt.Type, Clamp)),
            this.Export("sqrt", new CarpExternalFunc(CarpInt.Type, Sqrt)),
            this.Export("pow", new CarpExternalFunc(CarpInt.Type, Pow))
        );
    }

    public Package Net(string version)
    {
        CarpString Get(CarpObject url)
        {
            using WebClient wc = new();
            return new(wc.DownloadString(url.String().Native));
        }

        return this.CreatePackage("Net",
            this.Export("http",
                this.Sub("http",
                    this.Export("get", new CarpExternalFunc(CarpString.Type, Get))
                )
            )
        );
    }
}
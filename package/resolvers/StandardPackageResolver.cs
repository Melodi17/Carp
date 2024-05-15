using System.IO.Compression;
using System.Net;
using Carp.objects.types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Carp.package.resolvers;

public class StandardPackageResolver : IPackageResolver
{
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
        return new Package(this, this, "IO", export: i =>
        {
            CarpStatic cs = new("IO");
            
            cs.DefineProperty("println", CarpFunc.Type, new CarpExternalFunc(CarpVoid.Type, (CarpObject str) =>
            {
                Console.WriteLine(str.String().Native);
            }));

            cs.DefineProperty("printw", CarpFunc.Type, new CarpExternalFunc(CarpVoid.Type, (CarpObject str) =>
            {
                Console.Write(str.String().Native);
            }));
        
            cs.DefineProperty("readln", CarpFunc.Type, new CarpExternalFunc(CarpString.Type, (CarpObject str) =>
            {
                Console.Write(str.String().Native);
                return new CarpString(Console.ReadLine());
            }));
        
            cs.DefineProperty("readw", CarpFunc.Type, new CarpExternalFunc(CarpChar.Type, (CarpBool hideKeyStrokes) 
                => new CarpChar(Console.ReadKey(hideKeyStrokes.Native).KeyChar)));
            
            cs.DefineProperty("clear", CarpFunc.Type, new CarpExternalFunc(CarpVoid.Type, () 
                => Console.Clear()));
            
            cs.DefineProperty("move", CarpFunc.Type, new CarpExternalFunc(CarpVoid.Type, (CarpInt x, CarpInt y) 
                            => Console.SetCursorPosition(x.NativeInt, y.NativeInt)));

            return cs;
        });
    }
    
    public Package FS(string version)
    {
        return new Package(this, this, "FS", export: i =>
        {
            CarpStatic cs = new("FS");
            
            cs.DefineProperty("readfile", CarpFunc.Type, new CarpExternalFunc(CarpString.Type, (CarpObject path) 
                => new CarpString(File.ReadAllText(path.String().Native))));
            
            cs.DefineProperty("readfilelines", CarpFunc.Type, new CarpExternalFunc(CarpCollection.Type.With(CarpString.Type), (CarpObject path) 
                => new CarpCollection(CarpString.Type, File.ReadAllLines(path.String().Native)
                    .Select(x => new CarpString(x)).ToArray())));
            
            cs.DefineProperty("writefile", CarpFunc.Type, new CarpExternalFunc(CarpVoid.Type, (CarpObject path, CarpObject cont) 
                => File.WriteAllText(path.String().Native, cont.String().Native)));
            
            cs.DefineProperty("writefilelines", CarpFunc.Type, new CarpExternalFunc(CarpVoid.Type, (CarpObject path, CarpCollection cont) 
                => File.WriteAllLines(path.String().Native, cont.Native.Select(x => x.String().Native).ToArray())));
            
            cs.DefineProperty("exists", CarpFunc.Type, new CarpExternalFunc(CarpBool.Type, (CarpObject path) 
                => CarpBool.Of(File.Exists(path.String().Native))));
            
            cs.DefineProperty("delete", CarpFunc.Type, new CarpExternalFunc(CarpVoid.Type, (CarpObject path)
                => File.Delete(path.String().Native)));
            
            return cs;
        });
    }
    
    public Package Math(string version)
    {
        return new Package(this, this, "Math", export: i =>
        {
            CarpStatic cs = new("Math");
            
            cs.DefineProperty("random", CarpFunc.Type, new CarpExternalFunc(CarpInt.Type, (CarpInt min, CarpInt max) 
                => new CarpInt(new Random().Next(min.NativeInt, max.NativeInt))));
            
            // make sure to use CarpInt#Greater/Less
            cs.DefineProperty("chance", CarpFunc.Type, new CarpExternalFunc(CarpBool.Type, (CarpInt chance) 
                => new CarpInt(new Random().Next(0, 100)).Greater(chance)));
            
            cs.DefineProperty("wait", CarpFunc.Type, new CarpExternalFunc(CarpVoid.Type, (CarpInt ms) 
                => Thread.Sleep(ms.NativeInt)));

            return cs;
        });
    }
    
    public Package Net(string version)
    {
        return new Package(this, this, "Net", export: i =>
        {
            CarpStatic cs = new("Net");

            CarpStatic httpCs = new("http");
            
            cs.DefineProperty("http", CarpStatic.Type, httpCs);
            
            httpCs.DefineProperty("get", CarpFunc.Type, new CarpExternalFunc(CarpString.Type, (CarpObject url) =>
            {
                using WebClient wc = new();
                return new CarpString(wc.DownloadString(url.String().Native));
            }));

            return cs;
        });
    }
}
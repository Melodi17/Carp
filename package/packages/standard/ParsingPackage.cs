using Carp.objects.types;
using Newtonsoft.Json;

namespace Carp.package.packages.standard;

public class ParsingPackage(IPackageResolver source) : EmbeddedPackage(source, "Parse")
{
   [PackageMember("ds.json.")]
   public CarpObject LoadJson(CarpString json)
   {
      throw new NotImplementedException();
   }
   
   [PackageMember("ds.json.")]
   public CarpObject LoadJsonStructure(CarpString json, CarpType structure)
   {
      throw new NotImplementedException();
   }
   
   [PackageMember("ds.json.")]
   public CarpObject StoreJson(CarpObject ds)
   {
      throw new NotImplementedException();
   }
   
   [PackageMember("ds.json.")]
   public CarpObject StoreJsonStructure(CarpObject ds)
   {
      throw new NotImplementedException();
   }
   
   
}
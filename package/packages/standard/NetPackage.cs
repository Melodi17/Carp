using System.Net.Http;
using Carp.objects.types;

namespace Carp.package.packages.standard;

public class NetPackage(IPackageResolver source) : EmbeddedPackage(source, "Net")
{
    private readonly HttpClient _httpClient = new();

    [PackageMember("http.")]
    public CarpString Get(CarpString url)
    {
        string response = this._httpClient.GetStringAsync(url.Native).Result;
        return new(response);
    }
}
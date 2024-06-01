using System.Net.Http;
using Carp.objects.types;

namespace Carp.package.packages.standard;

public class NetPackage(IPackageResolver source) : EmbeddedPackage(source, "Net")
{
    private readonly HttpClient _httpClient = new();

    /// <summary>
    /// Makes a GET request to the specified URL.
    /// </summary>
    /// <param name="url">The URL to make the request to</param>
    /// <returns>The response from the server</returns>
    [PackageMember("Http.")]
    public CarpString Get(CarpString url)
    {
        string response = this._httpClient.GetStringAsync(url.Native).Result;
        return new(response);
    }
    
    /// <summary>
    /// Makes a POST request to the specified URL with the specified content.
    /// </summary>
    /// <param name="url">The URL to make the request to</param>
    /// <param name="content">The content to send</param>
    /// <returns>The response from the server</returns>
    [PackageMember("http.")]
    public CarpString Post(CarpString url, CarpString content)
    {
        StringContent stringContent = new(content.Native);
        HttpResponseMessage response = this._httpClient.PostAsync(url.Native, stringContent).Result;
        return new(response.Content.ReadAsStringAsync().Result);
    }
}
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
        try
        {
            string response = this._httpClient.GetStringAsync(url.Native).Result;
            return new(response);
        }
        catch (HttpRequestException e)
        {
            throw new HttpErrorResponse(url.Native, (int)e.StatusCode, e.Message);
        }
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
        try
        {
            StringContent stringContent = new(content.Native);
            HttpResponseMessage response = this._httpClient.PostAsync(url.Native, stringContent).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpErrorResponse(url.Native, (int)response.StatusCode, response.ReasonPhrase);
            }

            return new(response.Content.ReadAsStringAsync().Result);
        }
        catch (HttpRequestException e)
        {
            throw new ConnectionFailed(url.Native);
        }
    }

    public class ConnectionFailed(string host) : CarpError($"Failed to connect to {host}");

    public class HttpErrorResponse(string host, int code, string response)
        : CarpError($"Failed to connect to {host} with code {code}: {response}");
}
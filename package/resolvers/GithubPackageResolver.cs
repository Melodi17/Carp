using System.IO.Compression;
using System.Net;
using Carp.package.packages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Carp.package.resolvers;

public class GithubPackageResolver : IPackageResolver
{
    public static string BaseUrl = "https://api.github.com";
    public static string GetReleaseUrl = $"{BaseUrl}/repos/{{owner}}/{{repo}}/releases/tags/{{tag}}";
    public static string GetLatestReleaseUrl = $"{BaseUrl}/repos/{{owner}}/{{repo}}/releases/latest";
    public Package GetPackage(string[] fullPath, string[] path, string version = "latest")
    {
        string username = path[0];
        string repo = string.Join(".", path[1]);

        HttpClient client = new();
        string downloadUrl = null;
        bool isArchive = false;
        if (version == "latest")
        {
            string result = client.GetStringAsync(GetLatestReleaseUrl
                .Replace("{owner}", username)
                .Replace("{repo}", repo)).Sync();

            dynamic response = JsonConvert.DeserializeObject(result)!;
            foreach (dynamic asset in response.assets)
            {
                string name = asset.name;
                string assetDownloadUrl = asset.browser_download_url;

                if (name.EndsWith(".caaarp"))
                    isArchive = true;
                
                if (name.EndsWith(".caaarp") || name.EndsWith(".carp"))
                {
                    downloadUrl = assetDownloadUrl;
                    break;
                }
            }
        }

        if (downloadUrl == null)
            throw new CarpError.PackageNotFound(fullPath, version);
        
        // now caaarp and carp files are handled differently
        if (isArchive)
        {
            byte[] data = client.GetByteArrayAsync(downloadUrl).Sync();
            return new PackedPackage(this, this, repo, data);
        }
        else
        {
            string download = client.GetStringAsync(downloadUrl).Sync();
            return new SourcePackage(this, this, repo, download);
        }

        throw new NotImplementedException();
    }
}
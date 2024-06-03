using System.IO.Compression;
using System.Net;
using System.Text;
using Carp.package.packages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Carp.package.resolvers;

public class GithubPackageResolver : IPackageResolver
{
    public static string BaseUrl = "https://api.github.com";
    public static string GetReleaseUrl = $"{BaseUrl}/repos/{{owner}}/{{repo}}/releases/tags/{{tag}}";
    public static string GetLatestReleaseUrl = $"{BaseUrl}/repos/{{owner}}/{{repo}}/releases/latest";
    public Package GetPackage(CarpInterpreter interpreter, string[] fullPath, string[] path, string version = "latest")
    {
        string username = path[0];
        string repo = string.Join(".", path[1]);

        HttpClient client = new();
        byte[] downloadedPackage = DownloadPackage(client, fullPath, version, username, repo, out bool isArchive);

        string cachePath = Path.Join(LocalPackageResolver.CachePackagesPath, string.Join(".", fullPath));
        cachePath = Path.ChangeExtension(cachePath, isArchive ? ".caaarp" : ".carp");
        File.WriteAllBytes(cachePath, downloadedPackage);
        
        // now caaarp and carp files are handled differently
        return isArchive
            ? new PackedPackage(this, this, repo, downloadedPackage)
            : new SourcePackage(this, this, repo, Encoding.UTF8.GetString(downloadedPackage));
    }

    private static byte[] DownloadPackage(HttpClient client, string[] fullPath, string version, string username,
        string repo, out bool isArchive)
    {
        string downloadUrl = null;
        isArchive = false;
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
        
        return client.GetByteArrayAsync(downloadUrl).Sync();
    }
}
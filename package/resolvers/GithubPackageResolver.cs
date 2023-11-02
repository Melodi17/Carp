using System.IO.Compression;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Carp.package.resolvers;

public class GithubPackageResolver : IPackageResolver
{
    public static string BaseUrl = "https://api.github.com";
    public static string GetReleaseUrl = $"{BaseUrl}/repos/{{owner}}/{{repo}}/releases/tags/{{tag}}";
    public static string GetLatestReleaseUrl = $"{BaseUrl}/repos/{{owner}}/{{repo}}/releases/latest";
    public Package GetPackage(string[] path, string version = "latest")
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
            throw new CarpError.PackageNotFound(path, version);
        
        // now caaarp and carp files are handled differently
        if (isArchive)
        {
            byte[] download = client.GetByteArrayAsync(downloadUrl).Sync();
            // extract to Zip
            using MemoryStream stream = new(download);
            using ZipArchive archive = new(stream);
            
            ZipArchiveEntry reelEntry = archive.GetEntry("reel.json")!;
            using StreamReader reelReader = new(reelEntry.Open());
            string reelJson = reelReader.ReadToEnd();
            JObject reel = JObject.Parse(reelJson);
            string mainFile = reel["main"]!.ToString();
            
            ZipArchiveEntry mainEntry = archive.GetEntry(mainFile)!;
            using StreamReader mainReader = new(mainEntry.Open());
            string main = mainReader.ReadToEnd();
            
            // TODO: change this
            
            Package pkg = new(this, Program.DefaultPackageResolver, repo, sourceCode: main);
            return pkg;
        }
        else
        {
            string download = client.GetStringAsync(downloadUrl).Sync();
            Package pkg = new(this, Program.DefaultPackageResolver, repo, sourceCode: download);
            return pkg;
        }
    }
}
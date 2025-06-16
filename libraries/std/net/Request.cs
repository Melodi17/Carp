namespace Carp.libraries.std.net;

using System.Net;
using utils;

// public class Request
// {
//     [Doc("Returns a response from the given URL using a GET request.")]
//     public static Response Get(string url)
//     {
//         return Request.Generic(url, req => req.Method = "GET");
//     }
//
//     [Doc("Returns a response from the given URL using a POST request with the provided body.")]
//     public static Response Post(string url, string body)
//     {
//         return Request.Generic(url, req =>
//         {
//             req.Method = "POST";
//             req.ContentType = "application/x-www-form-urlencoded";
//             using StreamWriter writer = new(req.GetRequestStream());
//             writer.Write(body);
//         });
//     }
//     private static Response Generic(string url, Action<HttpWebRequest> req)
//     {
//         HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
//         using HttpWebResponse response = (HttpWebResponse) request.GetResponse();
//         Response resp = new()
//         {
//             StatusCode = (int) response.StatusCode,
//             StatusMessage = response.StatusDescription
//         };
//
//         using Stream stream = response.GetResponseStream();
//         using (StreamReader? reader = new(stream))
//             resp.Body = reader.ReadToEnd();
//
//         if (response.ContentLength > 0)
//         {
//             using MemoryStream memoryStream = new();
//             stream.CopyTo(memoryStream);
//             resp.Data = memoryStream.ToArray();
//         }
//         else
//             resp.Data = [];
//
//         return resp;
//     }
// }
//
// public class Response
// {
//     public string Body { get; set; }
//     public byte[] Data { get; set; }
//     public int StatusCode { get; set; }
//     public string StatusMessage { get; set; }
// }
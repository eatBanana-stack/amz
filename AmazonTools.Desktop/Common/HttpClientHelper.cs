using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AmazonTools.Desktop.Common
{
    public class HttpClientHelper
    {

        public static string Auth = "";
        public static string account = "";
        //public static string BaseUrl = "http://175.178.159.66:80/api/";
        public static string BaseUrl = "http://192.168.1.213:80/api/";

        //public static string BaseUrl = "http://localhost:5000/api/";
        public static T PostResponse<T>(string url, string postData) where T : class, new()
        {
            T result = default(T);

            HttpContent httpContent = new StringContent(postData, encoding: Encoding.UTF8, "application/json");
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                if (!Auth.Equals(""))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Auth);
                }
                HttpResponseMessage response = httpClient.PostAsync(BaseUrl + url, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;
                    //Newtonsoft.Json
                    string json = JsonConvert.DeserializeObject(s).ToString();
                    result = JsonConvert.DeserializeObject<T>(json);
                }
            }
            return result;
        }

        public static string PostResponse(string url, string postData)
        {

            HttpContent httpContent = new StringContent(postData, encoding: Encoding.UTF8, "application/json");
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                if (!Auth.Equals(""))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Auth);
                }
                HttpResponseMessage response = httpClient.PostAsync(BaseUrl + url, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;
                    return s;
                }
                return "0";

            }
        }

        public static AmzImge FileResponse(string url, string filePath)
        {

            using var httpClient = new HttpClient();
            // 设置认证头
            if (!string.IsNullOrEmpty(Auth))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Auth);
            }
            var content = new MultipartFormDataContent();
            var fileBytes = File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(filePath);
            var fileContent = new ByteArrayContent(fileBytes);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            content.Add(fileContent, "file", fileName);
            // 4. 发送 POST 请求
            var response =  httpClient.PostAsync(BaseUrl+url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<AmzImge>(json);
            }
            else
            {
                return null;
            }


        }
        public static void DownloadFile(string url, string filePath)
        {
            using var httpClient = new HttpClient();
            // 设置认证头
            if (!string.IsNullOrEmpty(Auth))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Auth);
            }
            var response = httpClient.GetAsync(BaseUrl + url).Result;
            if (response.IsSuccessStatusCode)
            {
                var fileBytes = response.Content.ReadAsByteArrayAsync().Result;
                File.WriteAllBytes(filePath, fileBytes);
            }
        }
        public async Task DownloadFileAsync(string url, string filePath)
        {
            using var httpClient = new HttpClient();

            // 创建目录（如果不存在）
            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // 使用FileShare.None防止其他进程访问
            await using var fileStream = new FileStream(
        filePath,
        FileMode.Create,
        FileAccess.Write,
        FileShare.None, // 关键参数
        8192,
        FileOptions.Asynchronous);

            using var response = await httpClient.GetAsync(BaseUrl+ url);
            response.EnsureSuccessStatusCode();

            await using var contentStream = await response.Content.ReadAsStreamAsync();
            await contentStream.CopyToAsync(fileStream);
        }

    }
    public class AmzImge
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

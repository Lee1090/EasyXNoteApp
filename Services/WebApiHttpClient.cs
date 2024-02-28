using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EasyXNoteApp.Services
{
    public class WebApiHttpClient : IDisposable
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        public WebApiHttpClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
        }

        public string Get(string endpoint)
        {
            string apiUrl = $"{_baseUrl}/{endpoint}";

            // Start synchronous GET request
            HttpResponseMessage response = _httpClient.GetAsync(apiUrl).Result;

            // Ensure request success
            response.EnsureSuccessStatusCode();

            // Read response content and return
            return response.Content.ReadAsStringAsync().Result;
        }

        public HttpResponseMessage Get(string endpoint, string userName, string password)
        {
            try
            {
                string apiUrl = $"{_baseUrl}/{endpoint}";

                // 创建一个凭据对象，用于包含用户名和密码 Create a credential object to hold the username and password
                var credentials = new NetworkCredential(userName, password);

                // 创建一个 HTTP 请求消息对象 Create an HTTP request message object
                var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);

                // 将凭据添加到请求标头中 Add the credentials to the request header
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{credentials.UserName}:{credentials.Password}")));

                // 发送 HTTP 请求并获取响应 Send the HTTP request and retrieve the response
                HttpResponseMessage response = _httpClient.SendAsync(request).Result;

                // 此处不处理返回状态，直接提交 Submit without handling the return status here
                // response.EnsureSuccessStatusCode();

                return response;
            }
            catch (HttpRequestException ex)
            {
                // 处理 HTTP 请求异常，记录日志 Handling HTTP request exception, logging
                throw new Exception("HTTP request exception", ex);
            }
            catch (Exception ex)
            {
                // 处理其他异常，记录日志 Handling other exceptions, logging
                throw new Exception("Unknown exception occurred", ex);
            }
        }


        public async Task<string> GetAsync(string endpoint)
        {
            string apiUrl = $"{_baseUrl}/{endpoint}";

            // Start asynchronous GET request
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            // Ensure request success
            response.EnsureSuccessStatusCode();

            // Read response content and return
            return await response.Content.ReadAsStringAsync();
        }

        public HttpResponseMessage Insert(string endpoint, string jsonData)
        {
            try
            {
                string apiUrl = $"{_baseUrl}/{endpoint}";

                // Create a StringContent object from JSON data
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Start synchronous POST request to insert data
                HttpResponseMessage response = _httpClient.PostAsync(apiUrl, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    // 处理错误状态码，例如抛出异常或者记录日志
                    // 这里仅仅是简单地将响应返回，具体处理方式根据需求而定
                    return response;
                }

                // 如果需要，可以在这里对响应进行进一步处理，比如将响应内容反序列化为对象

                return response;
            }
            catch (HttpRequestException ex)
            {
                // 处理 HTTP 请求异常，例如抛出异常或者记录日志 Handling HTTP request exception, logging
                throw new Exception("HTTP request exception", ex);
            }
            catch (Exception ex)
            {
                // 处理其他异常，例如抛出异常或者记录日志 Handling other exceptions, logging
                throw new Exception("Unknown exception occurred", ex);
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}

/*
using System;
using System.Net;
using System.Net.Http;

namespace EasyXNoteApp.Services
{
    public class WebApiHttpClient
    {
        private readonly string _baseUrl;

        public WebApiHttpClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public string Get(string endpoint)
        {
            using (var client = new WebClient())
            {
                // 
                return client.DownloadString($"{_baseUrl}/{endpoint}");
            }
        }
        public string Insert(string endpoint, string jsonData)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                return client.UploadString($"{_baseUrl}/{endpoint}", "POST", jsonData);
            }
        }
    }
}
*/


/*
{
    "success": true,
  "data": [
    { "UserID":1,"UserName":"test01","Email":"test@gmail.com","PasswordHash":"Hash01","PasswordSalt":"Slat01","CreatedDate":"2022-01-08T12:34:56"},
    { "UserID":2,"UserName":"test02","Email":"test02@gmail.com","PasswordHash":"Hash02","PasswordSalt":"Slat02","CreatedDate":"2022-01-08T13:01:01"}
  ]
}
{
    "success": false,
  "error": {
        "code": 500,
    "message": "Internal Server Error"
  }
}

using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main()
    {
        // 从 Web API 获取的 JSON 数据
        string jsonData = "[{\"UserID\":1,\"UserName\":\"test01\",\"Email\":\"test@gmail.com\",\"PasswordHash\":\"Hash01\",\"PasswordSalt\":\"Slat01\",\"CreatedDate\":\"2022-01-08T12:34:56\"},{\"UserID\":2,\"UserName\":\"test02\",\"Email\":\"test02@gmail.com\",\"PasswordHash\":\"Hash02\",\"PasswordSalt\":\"Slat02\",\"CreatedDate\":\"2022-01-08T13:01:01\"}]";

        // 使用 System.Text.Json 库解析 JSON 数据
        List<User> users = JsonSerializer.Deserialize<List<User>>(jsonData);

        // 在应用中继续使用解析后的用户数据
        foreach (var user in users)
        {
            Console.WriteLine($"UserID: {user.UserID}, UserName: {user.UserName}, Email: {user.Email}, PasswordHash: {user.PasswordHash}, PasswordSalt: {user.PasswordSalt}, CreatedDate: {user.CreatedDate}");
        }

        // 在这里可以继续使用 users，比如将它们显示在界面上或进行其他操作
    }
}

*/
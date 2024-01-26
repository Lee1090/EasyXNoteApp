using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

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
                return client.DownloadString($"{_baseUrl}/{endpoint}");
            }
        }
    }
}
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
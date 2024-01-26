using System;
using System.Collections.Generic;
using System.Configuration;
using EasyXNoteApp.Models;

namespace EasyXNoteApp.Services
{
    public class WebApiDataService : IDataService
    {
        private readonly WebApiHttpClient _webApiHttpClient;

        public WebApiDataService()
        {
            string baseUrl = ConfigurationManager.AppSettings["DataAccessApiBaseUrl"];
            // 实例化 HTTP 请求帮助类，并将基础URL传递给构造函数
            _webApiHttpClient = new WebApiHttpClient(baseUrl);
        }

        public string GetUsers()
        {
            // 实际的数据获取逻辑，这里仅为示例使用一个字符串数组
            var data = _webApiHttpClient.Get("api/user");
            // 解析 data 并返回
            //return ParseData(data);
            return data;
        }
        public string GetUserProfiles()
        {
            // 实际的数据获取逻辑，这里仅为示例使用一个字符串数组
            var data = _webApiHttpClient.Get("api/userProfile");
            // 解析 data 并返回
            //return ParseData(data);
            return data;
        }

        private IEnumerable<string> ParseData(string data)
        {
            // 实现解析逻辑
            // 例如，将 JSON 数据解析为 IEnumerable<string>
            // 可以使用 Newtonsoft.Json 库进行 JSON 解析
            // 示例：return JsonConvert.DeserializeObject<IEnumerable<string>>(data);
            return new List<string>(); // 示例，实际实现根据你的数据格式进行
        }
    }
}
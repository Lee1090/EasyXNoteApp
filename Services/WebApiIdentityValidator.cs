using System.Configuration;
using System.Net;
using System.Net.Http;
using EasyXNoteApp.Services;

namespace EasyXNoteApp.Services
{
    public class WebApiIdentityValidator:IIdentityValidator
    {
        private readonly WebApiHttpClient _webApiHttpClient;

        public WebApiIdentityValidator()
        {
            string baseUrl = ConfigurationManager.AppSettings["DataAccessApiBaseUrl"];
            _webApiHttpClient = new WebApiHttpClient(baseUrl);
        }

        public bool IsValidUser(string userName, string password)
        {
            HttpResponseMessage response = _webApiHttpClient.Get("api/login", userName, password);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                // 包括401未授权，以及各种400-500请求错误，后面再详细处理
                return false;
            }
        }
    }
}
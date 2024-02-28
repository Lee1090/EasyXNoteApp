using System;
using System.Configuration;
using EasyXNoteApp.Services;
using System.Net.Http;
using EasyXNoteApp.Models;
using System.Net;

namespace EasyXNoteApp.Services
{
    public class WebApiDataService : IDataService, IDisposable
    {
        private readonly WebApiHttpClient _webApiHttpClient;

        public WebApiDataService()
        {
            string baseUrl = ConfigurationManager.AppSettings["DataAccessApiBaseUrl"];
            _webApiHttpClient = new WebApiHttpClient(baseUrl);
        }
        public string GetUsers()
        {
            var data = _webApiHttpClient.Get("api/user");
            return data;
        }
        public OperationResult InsertUser(string jsonData)
        {
            try
            {
                HttpResponseMessage response = _webApiHttpClient.Insert("api/user", jsonData);

                if (response.IsSuccessStatusCode)
                {
                    return new OperationResult(true, response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    return new OperationResult(false, response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (HttpRequestException ex)
            {
                return new OperationResult(false, ex.Message);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }

        public string GetUserProfiles()
        {
            var data = _webApiHttpClient.Get("api/userProfile");

            return data;
        }
        public string GetNoteBooks()
        {
            var data = _webApiHttpClient.Get("api/noteBook");
            return data;
        }
        public string GetNotes()
        {
            var data = _webApiHttpClient.Get("api/note");
            return data;
        }
        public void Dispose()
        {
            _webApiHttpClient.Dispose();
        }
        
    }
}


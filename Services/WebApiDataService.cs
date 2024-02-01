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
            _webApiHttpClient = new WebApiHttpClient(baseUrl);
        }

        public string GetUsers()
        {
            var data = _webApiHttpClient.Get("api/user");
            return data;
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
    }
}
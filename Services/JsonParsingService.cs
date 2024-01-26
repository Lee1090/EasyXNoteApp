using EasyXNoteApp.Models;
using Newtonsoft.Json;
using System;


namespace EasyXNoteApp.Services
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class JsonParsingService
    {
        public ApiResponse<T> ParseApiResponse<T>(string json)
        {
            try
            {
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(json);

                if (apiResponse == null)
                {
                    // Code for logging

                    return new ApiResponse<T>
                    {
                        Success = false,
                        ErrorMessage = "Returned object is null."
                    };
                }

                else 
                {
                    if (!apiResponse.Success)
                    {
                        // Code for logging

                    }

                    return apiResponse;
                }
               
            }
            catch (JsonException ex)
            {
                // 处理 JSON 解析异常
                return new ApiResponse<T>
                {
                    Success = false,
                    ErrorMessage = "JSON parsing exception:" + ex.Message
                };
            }
        }
    }

    /*
    public class JsonParseException : Exception
    {
        public JsonParseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    */
}




using EasyXNoteApp.Models;
using EasyXNoteApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyXNoteApp.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IDataService _dataService;
        private readonly JsonParsingService _jsonParsingService;

        public UserProfileController()
        {
            _dataService = new WebApiDataService();
            _jsonParsingService = new JsonParsingService();
        }

        //public UserController(IDataService dataService)
        //{
        //    _dataService = dataService;
        //}

        public ActionResult Index()
        {
            var userData = _dataService.GetUserProfiles();
            ViewBag.Message = userData;
            // ViewBag.Message = "User page.";
            // return View(userData);
            var apiResponse = _jsonParsingService.ParseApiResponse<List<UserProfile>>(userData);
            if (apiResponse.Success == true)
            {
                List<UserProfile> users = apiResponse.Data;
                // ViewBag.test = users[0].UserName;
                return View(users); // 将用户数据传递给视图
            }
            else
            {
                ViewBag.ErrorMessage = apiResponse.ErrorMessage;
                return View(); // 如果发生错误，仍然返回视图，但没有用户数据
            }
        }
    }
}

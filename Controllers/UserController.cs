using EasyXNoteApp.Models;
using EasyXNoteApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyXNoteApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IDataService _dataService;
        private readonly JsonParsingService _jsonParsingService;

        public UserController()
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
            var userData = _dataService.GetUsers();
            ViewBag.Message = userData;
            // ViewBag.Message = "User page.";
            // return View(userData);
            var apiResponse = _jsonParsingService.ParseApiResponse<List<User>>(userData);
            if(apiResponse.Success == true)
            {
                List<User> users = apiResponse.Data;
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
/*
public class YourService
{
    private readonly JsonParsingService _jsonParsingService;

    public YourService(JsonParsingService jsonParsingService)
    {
        _jsonParsingService = jsonParsingService;
    }

    public void ProcessApiResponse(string jsonData)
    {
        var apiResponse = _jsonParsingService.ParseApiResponse<List<User>>(jsonData);

        if (apiResponse.Success)
        {
            var userList = apiResponse.Data;
            // 处理成功情况的业务逻辑...
        }
        else
        {
            var errorMessage = apiResponse.ErrorMessage;
            // 处理失败情况的业务逻辑...
        }
    }
}
public class YourController : Controller
{
    private readonly YourBusinessService _yourBusinessService;

    public YourController(YourBusinessService yourBusinessService)
    {
        _yourBusinessService = yourBusinessService;
    }

    public ActionResult YourAction(string jsonData)
    {
        _yourBusinessService.ProcessApiResponse(jsonData);

        // 可能返回一个视图或其他操作...
        return View();
    }
}

public class UserController : Controller
{
    private readonly IDataService _dataService;
    private readonly JsonParsingService _jsonParsingService;

    public UserController()
    {
        _dataService = new WebApiDataService();
        _jsonParsingService = new JsonParsingService();
    }

    public ActionResult Index()
    {
        var jsonUserData = _dataService.GetUserJsonData(); // 假设有一个获取 JSON 数据的方法
        var users = _jsonParsingService.ParseApiResponse<List<User>>(jsonUserData);

        // 如果需要将数据传递给视图，可以使用 View 方法的重载
        return View(users);
    }
}
*/
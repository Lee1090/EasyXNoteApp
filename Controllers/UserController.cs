using EasyXNoteApp.Models;
using EasyXNoteApp.Services;
using Newtonsoft.Json;
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
                List<User> reData = apiResponse.Data;
                // ViewBag.test = users[0].UserName;
                return View(reData); // 将用户数据传递给视图
            }
            else
            {
                ViewBag.ErrorMessage = apiResponse.ErrorMessage;
                return View(); // 如果发生错误，仍然返回视图，但没有用户数据
            }
        }
        public ActionResult Create()
        {
            return View();
        }

            private string GenerateSalt()
        {
            // Generate a random salt using a secure random number generator
            byte[] saltBytes = new byte[16];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            // Convert the byte array to a base64-encoded string for storage
            return Convert.ToBase64String(saltBytes);
        }
        private string HashPassword(string password, string salt)
        {
            // Combine the password and salt, then hash the result
            string combinedPassword = password + salt;

            // Add password hashing logic here (e.g., using a library like BCrypt)
            // Example using BCrypt: return BCrypt.Net.BCrypt.HashPassword(combinedPassword);
            return combinedPassword; // Placeholder, replace with actual hashing logic
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Generate a random salt for this user
                user.PasswordSalt = GenerateSalt();

                // Hash the password with the generated salt before saving to the database
                user.PasswordHash = HashPassword(user.Password, user.PasswordSalt);

                // Additional logic can be added here
                user.CreatedDate = DateTime.Now;

                string jsonData = JsonConvert.SerializeObject(user);

                string reStr = _dataService.InsertUser(jsonData);

                // Need to handle return string

                return RedirectToAction("Index"); // Redirect to Home
            }

            return View(user);
        }

        public ActionResult Login()
        {
            return View();
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
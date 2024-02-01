using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyXNoteApp.Models;
using EasyXNoteApp.Services;

namespace EasyXNoteApp.Controllers
{
    public class NoteBookController : Controller
    {
        private readonly IDataService _dataService;
        private readonly JsonParsingService _jsonParsingService;
        public NoteBookController() 
        {
            _dataService = new WebApiDataService();
            _jsonParsingService = new JsonParsingService();
        }
        // GET: NoteBook
        public ActionResult Index()
        {
            var noteBookData = _dataService.GetNoteBooks();
            var apiResponse = _jsonParsingService.ParseApiResponse<List<NoteBook>>(noteBookData);
            if(apiResponse.Success == true)
            {
                List<NoteBook> reData = apiResponse.Data;
                return View(reData);
            }
            else
            {
                ViewBag.ErrorMessange = apiResponse.ErrorMessage;
                return View();
            }
        }
    }
}
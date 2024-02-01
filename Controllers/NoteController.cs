using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyXNoteApp.Models;
using EasyXNoteApp.Services;

namespace EasyXNoteApp.Controllers
{
    public class NoteController : Controller
    {
        private readonly IDataService _dataService;
        private readonly JsonParsingService _jsonPraseService;
        public NoteController()
        {
            _dataService = new WebApiDataService();
            _jsonPraseService = new JsonParsingService();
        }
        // GET: Note
        public ActionResult Index()
        {
            var noteData = _dataService.GetNotes();
            var apiResponse = _jsonPraseService.ParseApiResponse<List<Note>>(noteData);
            if(apiResponse.Success == true)
            {
                List<Note> reData = apiResponse.Data;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyXNoteApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "This is a simple online note-taking system, offering a convenient and swift note-taking experience. Easily create, edit, and organize notes, accessible anytime, anywhere. User-friendly and concise, it aids in efficiently managing tasks for learning and work. Currently available as a DEMO version.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a simple online note-taking system, offering a convenient and swift note-taking experience. Easily create, edit, and organize notes, accessible anytime, anywhere. User-friendly and concise, it aids in efficiently managing tasks for learning and work. Currently available as a DEMO version.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
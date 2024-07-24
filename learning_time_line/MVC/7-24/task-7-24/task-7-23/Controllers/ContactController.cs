using System.Web.Mvc;

namespace task_7_23.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Display(FormCollection form)
        {
            ViewBag.Name = form["Name"];
            ViewBag.PhoneNumber = form["PhoneNumber"];
            ViewBag.Gender = form["Gender"];
            ViewBag.Degree = form["Degree"];
            ViewBag.Interests = form.GetValues("Interests");

            return View("Contact"); 
        }
    }
}

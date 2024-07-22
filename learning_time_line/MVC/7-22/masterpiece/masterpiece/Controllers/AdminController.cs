using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace masterpiece.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin
        public ActionResult Create_event()
        {
            return View();
        }

        public ActionResult Manege_event()
        {
            return View();
        }
        public ActionResult CreateTickets_event()
        {
            return View();
        }

        public ActionResult profile()
        {
            return View();
        }

    }
}

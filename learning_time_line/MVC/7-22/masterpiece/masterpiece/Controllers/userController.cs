using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace masterpiece.Controllers
{
    public class userController : Controller
    {
        // GET: user
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult Buy_tickets()
        {
            return View();
        }
        public ActionResult explore_events()
        {
            return View();
        }



    }

}
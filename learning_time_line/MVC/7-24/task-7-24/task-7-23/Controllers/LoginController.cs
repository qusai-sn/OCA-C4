using System.Linq;
using System.Web.Mvc;

namespace task_7_23.Controllers
{
    public class LoginController : Controller
    {
        private static readonly (string Username, string Password)[] validCredentials =
        {
            ("user1", "password1"),
            ("user2", "password2"),
        };

        // GET: Login/LoginPage
        public ActionResult LoginPage()
        {
            return View();
        }

        // POST: Login/LoginPage
        [HttpPost]
         public ActionResult LoginPage(string username, string password)
        {
            bool isValidUser = validCredentials.Any(c => c.Username == username && c.Password == password);

            if (isValidUser)
            {
                 Session["User"] = username;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }

        // GET: Login/Logout
        public ActionResult Logout()
        {
             Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}

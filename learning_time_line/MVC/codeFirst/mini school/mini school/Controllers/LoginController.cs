using mini_school.Models;

using System.Linq;
using System.Web.Mvc;

namespace MiniSchool.Controllers
{
    public class LoginController : Controller
    {
        private readonly SchoolDbContext _context = new SchoolDbContext();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User userModel)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.Email == userModel.Email && u.Password == userModel.Password);

                if (user != null)
                {
                    // Store user info in session
                    Session["UserId"] = user.Id;
                    Session["UserEmail"] = user.Email;

                    // Redirect to a secure page (e.g., Classes or Home)
                    return RedirectToAction("Index", "Classes");
                }

                // If user credentials are incorrect
                ModelState.AddModelError("", "Invalid email or password.");
            }

            return View(userModel);
        }

        // GET: Logout
        public ActionResult Logout()
        {
            // Clear the session
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login", "Login");
        }
    }
}

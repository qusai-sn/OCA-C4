using login_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;


namespace login_app.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        // POST: Login
        [HttpPost]
        public ActionResult Login(user user)
        {
             using (Login_appEntities1 db = new Login_appEntities1())
            {
                var logged_user = db.users.FirstOrDefault(record => record.email == user.email);


                //foreach (var item in db.users)
                //{
                //    if (item.email == user.email)
                //    {
                //        logged_user = item;
                //    }
                //}

                if (logged_user != null && user.password == logged_user.password)
                {
                    HttpCookie auth = new HttpCookie("AuthCookie", user.email);

                    auth.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Add(auth);

                     return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid email or password";
                    return View();
                }

            }
        }



            // GET: Login/Create
            public ActionResult Register()
        {
            return View();
        }


        // POST: Login/Create
        [HttpPost]
       public ActionResult Register(user user)
        {
            Login_appEntities1 db = new Login_appEntities1();

            db.users.Add(user);
            db.SaveChanges();
 
            return RedirectToAction("Login","Login");

        }

      



     

        // GET: Login/Logout
        public ActionResult Logout()
        {
             HttpCookie authCookie = Request.Cookies["AuthCookie"];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-1); 
                Response.Cookies.Add(authCookie);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile()
        {
             HttpCookie authCookie = Request.Cookies["AuthCookie"];
            if (authCookie == null)
            {
                 return RedirectToAction("Login");
            }

            string email = authCookie.Value;

            using (Login_appEntities1 db = new Login_appEntities1())
            {
                var user = db.users.FirstOrDefault(u => u.email == email);
                if (user == null)
                {
                     return RedirectToAction("Login");
                }

                return View(user);
            }
        }
        

        // GET: Login/ResetPassword
        public ActionResult ResetPassword()
        {
             if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

             var model = new ResetPasswordViewModel();
            return View(model);
        }

        // POST: Login/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (Login_appEntities1 db = new Login_appEntities1())
                {
                     HttpCookie authCookie = Request.Cookies["AuthCookie"];
                    if (authCookie == null)
                    {
                        return RedirectToAction("Login");
                    }

                    string email = authCookie.Value;

                     var user = db.users.FirstOrDefault(u => u.email == email);
                    if (user != null)
                    {
                        user.password = model.NewPassword;
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();

                        ViewBag.SuccessMessage = "Password has been reset successfully.";
                        return View();
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "User not found.";
                        return View();
                    }
                }
            }

            return View(model);
        }


        // GET: Login/EditProfile
        public ActionResult EditProfile()
        {
             if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            string email = Request.Cookies["AuthCookie"].Value;
            using (Login_appEntities1 db = new Login_appEntities1())
            {
                var user = db.users.FirstOrDefault(u => u.email == email);
                if (user == null)
                {
                    return HttpNotFound();
                }

                var model = new UserProfileViewModel
                {
                    Email = user.email,
                    Name = user.name,
                    ProfileImagePath = user.img  
                };

                return View(model);
            }
        }

        // POST: Login/EditProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (Login_appEntities1 db = new Login_appEntities1())
                {
                    var user = db.users.FirstOrDefault(u => u.email == model.Email);
                    if (user != null)
                    {
                        user.name = model.Name;

                        if (!string.IsNullOrWhiteSpace(model.NewPassword))
                        {
                            user.password = model.NewPassword;
                        }

                         if (model.ProfileImage != null && model.ProfileImage.ContentLength > 0)
                        {
                            var fileName = System.IO.Path.GetFileName(model.ProfileImage.FileName);
                            var path = System.IO.Path.Combine(Server.MapPath("~/Images/ProfileImages"), fileName);
                            model.ProfileImage.SaveAs(path);

                             user.img = "/Images/ProfileImages/" + fileName;
                        }

                        db.SaveChanges();
                        return RedirectToAction("Profile", "Login");
                    }

                    return HttpNotFound();
                }
            }

            return View(model);
        }

    }
}

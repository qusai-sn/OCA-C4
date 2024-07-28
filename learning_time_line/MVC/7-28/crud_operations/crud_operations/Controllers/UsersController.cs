using crud_operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud_operations.Controllers
{
    public class UsersController : Controller
    {


        private readonly crudEntities _context;

        crudEntities db = new crudEntities();
        public UsersController()
        {
            _context = new crudEntities();
        }

        // GET: Users
        public ActionResult Index()
        {
            crudEntities db = new crudEntities();
            var list = db.Users.ToList();
            return View(list);
         }


        public ActionResult Create()
        {
              return View();
        }


        [HttpPost]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                    Image = model.Image
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);

        }



        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();  
            }

            return View(user);  
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             var user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();  
            }

            _context.Users.Remove(user); 
            _context.SaveChanges();  

            return RedirectToAction("Index"); 
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            // Retrieve the user by ID
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound(); 
            }

            return View(user); 
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound(); 
            }

             
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                 var existingUser = _context.Users.Find(user.Id);
                if (existingUser == null)
                {
                    return HttpNotFound();  
                }

                existingUser.Email = user.Email;
                existingUser.Name = user.Name;
                existingUser.Password = user.Password; 
                existingUser.Image = user.Image;

                 _context.SaveChanges();

                 return RedirectToAction("Index");
            }

             return View(user);
        }



    }
}
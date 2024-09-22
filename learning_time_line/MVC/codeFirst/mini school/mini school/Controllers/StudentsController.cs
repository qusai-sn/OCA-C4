using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mini_school.Models;
 
namespace MiniSchool.Controllers
{
    public class StudentsController : Controller
    {
        private SchoolDbContext db = new SchoolDbContext();

        // GET: Students (View all students)
        public ActionResult Index(int? classId)
        {
            var students = db.Students.Include(s => s.Class);

            if (classId.HasValue)
            {
                students = students.Where(s => s.ClassId == classId.Value);
            }

            return View(students.ToList());
        }

        // GET: Students/Details/5 (View details for a specific student)
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create (Show form to create a new student)
        public ActionResult Create(int? classId)
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", classId);
            return View();
        }

        // POST: Students/Create (Save the new student)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index", new { classId = student.ClassId });
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", student.ClassId);
            return View(student);
        }

        // GET: Students/Edit/5 (Show form to edit an existing student)
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", student.ClassId);
            return View(student);
        }

        // POST: Students/Edit/5 (Save the edited student)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Age,Email,ClassId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", student.ClassId);
            return View(student);
        }

        // GET: Students/Delete/5 (Show confirmation to delete a student)
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5 (Confirm and delete the student)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Dispose to free resources
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

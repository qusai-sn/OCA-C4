using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mini_school.Models;   
using System.Data.Entity;

namespace mini_school.Controllers
{
    public class AssignmentsController : Controller
    {
        private SchoolDbContext db = new SchoolDbContext();   

        // GET: Assignments (Read all)
        public ActionResult Index(int? classId)
        {
            var assignments = db.Assignments.Include(a => a.Class);

            if (classId.HasValue)
            {
                assignments = assignments.Where(a => a.ClassId == classId.Value);
            }

            return View(assignments.ToList());
        }

        // GET: Assignments/Details/5 (Read a specific assignment)
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // GET: Assignments/Create (Show form to create a new assignment)
        public ActionResult Create(int? classId)
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", classId);
            return View();
        }

        // POST: Assignments/Create (Save the new assignment)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,DueDate,ClassId")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("Index", new { classId = assignment.ClassId });
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", assignment.ClassId);
            return View(assignment);
        }

        // GET: Assignments/Edit/5 (Show form to edit an existing assignment)
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", assignment.ClassId);
            return View(assignment);
        }

        // POST: Assignments/Edit/5 (Save the edited assignment)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,DueDate,ClassId")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", assignment.ClassId);
            return View(assignment);
        }

        // GET: Assignments/Delete/5 (Show confirmation page to delete an assignment)
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Delete/5 (Delete an assignment after confirmation)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            db.Assignments.Remove(assignment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Dispose method to free up resources
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

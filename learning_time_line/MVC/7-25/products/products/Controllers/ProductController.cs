using products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace products.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
           

            using (ProductEntities1 products = new ProductEntities1())
            {
                var p = products.products.ToList();
                return View(p);
            }
           
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using (ProductEntities1 db = new ProductEntities1())
            {
                var product = db.products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
        }


        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(product product)
        {
            if (ModelState.IsValid)
            {
                using (ProductEntities1 db = new ProductEntities1())
                {
                    db.products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }




        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            using (ProductEntities1 db = new ProductEntities1())
            {
                var product = db.products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(product product)
        {
            if (ModelState.IsValid)
            {
                using (ProductEntities1 db = new ProductEntities1())
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }








        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (ProductEntities1 db = new ProductEntities1())
            {
                var product = db.products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (ProductEntities1 db = new ProductEntities1())
            {
                var product = db.products.Find(id);
                if (product != null)
                {
                    db.products.Remove(product);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

    }
}

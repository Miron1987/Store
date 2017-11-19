using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternetStore.Models;

namespace InternetStore.Controllers
{
    public class ProductsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Products
        public ActionResult Index()
        {
            //ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            //Product product = db.Products.Include(t => t.Category);
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "Name", "Name");
            return View();
        }

        // POST: Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            Product product = db.Products.Find(id);
            Buyer buyer = new Buyer();
            buyer.ProductId = product.Id;
            buyer.ProductName = product.Name;
            return View("~/Views/Buyers/Create.cshtml", buyer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy([Bind(Include = "Id,Name,Address,ProductId,ProductName")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                db.Buyers.Add(buyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Buyers/Index.cshtml");
        }



        [HttpPost]
        public JsonResult CreateAjax(string name)
        {
            //var product = new Product { Name = name };
            var product = db.Products.Find(name);
            //db.Products.Add(product);
            //db.SaveChanges();
            return new JsonResult { Data = product.Id };
        }

        public JsonResult Search(string searchName)
        {
            var products = db.Products.Where(x => x.Name.Contains(searchName)).ToList();
            return new JsonResult { Data = products };
        }

        public JsonResult CategorySearch(string searchName)
        {
            var products = db.Products.Where(x => x.Category.Contains(searchName)).ToList();
            return new JsonResult { Data = products };
        }


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

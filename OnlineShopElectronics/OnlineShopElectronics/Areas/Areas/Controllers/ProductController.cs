using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShopElectronics.Models;

namespace OnlineShopElectronics.Areas.Areas.Controllers
{
    public class ProductController : Controller
    {
        private OnlineShopElectronicsEntities db = new OnlineShopElectronicsEntities();

        // GET: Areas/Product
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductCategory).Include(p => p.Supplierss);
            return View(products.ToList());
        }

        // GET: Areas/Product/Details/5
        public ActionResult Details(long? id)
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

        // GET: Areas/Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name");
            ViewBag.SupplierID = new SelectList(db.Suppliersses, "ID", "SupplierName");
            return View();
        }

        // POST: Areas/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Product product)
        {
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmfff") + extension;
            product.Image = "/image/" + fileName;
            fileName = Path.Combine(Server.MapPath("/image/"), fileName);
            product.ImageFile.SaveAs(fileName);
            using (OnlineShopElectronicsEntities db = new OnlineShopElectronicsEntities())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            ModelState.Clear();

            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliersses, "ID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // GET: Areas/Product/Edit/5
        public ActionResult Edit(long? id)
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
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliersses, "ID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // POST: Areas/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Product product)
        {
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmfff") + extension;
            product.Image = "/image/" + fileName;
            fileName = Path.Combine(Server.MapPath("/image/"), fileName);
           product.ImageFile.SaveAs(fileName);
            
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliersses, "ID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // GET: Areas/Product/Delete/5
        public ActionResult Delete(long? id)
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

        // POST: Areas/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShopElectronics.Models;

namespace OnlineShopElectronics.Areas.Areas.Controllers
{
    public class SuppliersseController : Controller
    {
        private OnlineShopElectronicsEntities db = new OnlineShopElectronicsEntities();

        // GET: Areas/Suppliersse
        public ActionResult Index()
        {
            return View(db.Suppliersses.ToList());
        }

        // GET: Areas/Suppliersse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplierss supplierss = db.Suppliersses.Find(id);
            if (supplierss == null)
            {
                return HttpNotFound();
            }
            return View(supplierss);
        }

        // GET: Areas/Suppliersse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Areas/Suppliersse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SupplierName,Address1,Address2,City,Zip_Code,Country,Email,ContactPerson,PhoneContactPerson,EmailContactPerson")] Supplierss supplierss)
        {
            if (ModelState.IsValid)
            {
                db.Suppliersses.Add(supplierss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplierss);
        }

        // GET: Areas/Suppliersse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplierss supplierss = db.Suppliersses.Find(id);
            if (supplierss == null)
            {
                return HttpNotFound();
            }
            return View(supplierss);
        }

        // POST: Areas/Suppliersse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SupplierName,Address1,Address2,City,Zip_Code,Country,Email,ContactPerson,PhoneContactPerson,EmailContactPerson")] Supplierss supplierss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplierss);
        }

        // GET: Areas/Suppliersse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplierss supplierss = db.Suppliersses.Find(id);
            if (supplierss == null)
            {
                return HttpNotFound();
            }
            return View(supplierss);
        }

        // POST: Areas/Suppliersse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplierss supplierss = db.Suppliersses.Find(id);
            db.Suppliersses.Remove(supplierss);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace WebAppOnlineShop.Areas.Administrator.Controllers
{
    public class SupplierssesController : BaseController
    {
        private OnlineShopElectronicsDbContext db = new OnlineShopElectronicsDbContext();

        // GET: Administrator/Suppliersses
        public ActionResult Index()
        {
            var model = db.Suppliersses.Where(x => x.IsDelete == false).ToList();
            return View(model);
        }

        // GET: Administrator/Suppliersses/Details/5
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

        // GET: Administrator/Suppliersses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Suppliersses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
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

        // GET: Administrator/Suppliersses/Edit/5
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

        // POST: Administrator/Suppliersses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
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

        // GET: Administrator/Suppliersses/Delete/5
        public ActionResult Delete(int? id)
        {
            Supplierss supplierss = db.Suppliersses.Find(id);
            int count = db.Products.Where(x=> x.SupplierID == supplierss.ID).Count();
            if(count > 0)
            {
                //return new ContentResult() {
                //    Content = "<script language='javascript' type='text/javascript'>alert('In us');</script>" }; 
                TempData["deleteMSG"] = "In using !!!";
                return RedirectToAction("Index");
            }
            else
            {
                supplierss.IsDelete = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }

        // POST: Administrator/Suppliersses/Delete/5
        [HttpPost]
        [HttpDelete]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //new UserDao().Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

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
    public class SaleReportDetailController : Controller
    {
        private OnlineShopElectronicsEntities db = new OnlineShopElectronicsEntities();

        // GET: Areas/SaleReportDetail
        public ActionResult Index()
        {
            var saleReportDetails = db.SaleReportDetails.Include(s => s.Order);
            return View(saleReportDetails.ToList());
        }

        // GET: Areas/SaleReportDetail/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleReportDetail saleReportDetail = db.SaleReportDetails.Find(id);
            if (saleReportDetail == null)
            {
                return HttpNotFound();
            }
            return View(saleReportDetail);
        }

        // GET: Areas/SaleReportDetail/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "NOTE");
            return View();
        }

        // POST: Areas/SaleReportDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleReportID,OrderID")] SaleReportDetail saleReportDetail)
        {
            if (ModelState.IsValid)
            {
                db.SaleReportDetails.Add(saleReportDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Orders, "ID", "NOTE", saleReportDetail.OrderID);
            return View(saleReportDetail);
        }

        // GET: Areas/SaleReportDetail/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleReportDetail saleReportDetail = db.SaleReportDetails.Find(id);
            if (saleReportDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "NOTE", saleReportDetail.OrderID);
            return View(saleReportDetail);
        }

        // POST: Areas/SaleReportDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleReportID,OrderID")] SaleReportDetail saleReportDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleReportDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "NOTE", saleReportDetail.OrderID);
            return View(saleReportDetail);
        }

        // GET: Areas/SaleReportDetail/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleReportDetail saleReportDetail = db.SaleReportDetails.Find(id);
            if (saleReportDetail == null)
            {
                return HttpNotFound();
            }
            return View(saleReportDetail);
        }

        // POST: Areas/SaleReportDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SaleReportDetail saleReportDetail = db.SaleReportDetails.Find(id);
            db.SaleReportDetails.Remove(saleReportDetail);
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

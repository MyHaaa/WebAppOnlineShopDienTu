using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using PagedList;

namespace WebAppOnlineShop.Areas.Administrator.Controllers
{
    public class OrdersController : BaseController
    {
        private OnlineShopElectronicsDbContext db = new OnlineShopElectronicsDbContext();

        // GET: Administrator/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer);
            return View(orders.OrderByDescending(x => x.CreatedDate).ToList());
        }
        public ActionResult ViewAll()
        {
            var orders = db.Orders.Include(o => o.Customer);
            return View(orders.OrderByDescending(x => x.CreatedDate).ToList());
        }
        public ActionResult ViewPending()
        {
            var orders = db.Orders.Include(o => o.Customer).Where(x=> x.StatusCategoryID== false);
            return View(orders.OrderByDescending(x => x.CreatedDate).ToList());
        }
        public ActionResult ViewApproval()
        {
            var orders = db.Orders.Include(o => o.Customer).Where(x => x.StatusCategoryID == true);
            return View(orders.OrderByDescending(x => x.CreatedDate).ToList());
        }

        // GET: Administrator/Orders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Administrator/Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Username");
            return View();
        }

        // POST: Administrator/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerID,NOTE,Amount,CreatedDate,Expries,PaymentMethod,StatusCategoryID")] Order order)
        {
            if (ModelState.IsValid)
            {
                //order.Expries = order.CreatedDate.AddDays(6);
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Username", order.CustomerID);
            return View(order);
        }

        // GET: Administrator/Orders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Username", order.CustomerID);
            return View(order);
        }

        // POST: Administrator/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,NOTE,Amount,CreatedDate,Expries,PaymentMethod,StatusCategoryID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Username", order.CustomerID);
            return View(order);
        }

        // GET: Administrator/Orders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Administrator/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Approve(long? id)
        {
            Order order = db.Orders.Find(id);
            order.StatusCategoryID = true;
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

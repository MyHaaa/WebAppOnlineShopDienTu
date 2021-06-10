using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppOnlineShop.Commons;

namespace WebAppOnlineShop.Controllers
{
    public class ProfileController : Controller
    {
        OnlineShopElectronicsDbContext db = new OnlineShopElectronicsDbContext();
        // GET: Profile
        public ActionResult Index()
        {
            string customerName = Session["CustomerName"].ToString();
            return View(db.Customers.SingleOrDefault(x=> x.Username == customerName));
        }

        [HttpGet]
        public ActionResult Edit()
        {
            string customerName = Session["CustomerName"].ToString();
            return View(db.Customers.SingleOrDefault(x => x.Username == customerName));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            string customerName = Session["CustomerName"].ToString();
            
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult OrderView()
        {
            string customerName = Session["CustomerName"].ToString();
            Customer customer = db.Customers.SingleOrDefault(x => x.Username == customerName);
            long id = customer.ID;
            var orders = db.Orders.Where(x => x.CustomerID == id).OrderByDescending(x => x.CreatedDate).ToList();

            return View(orders);
        }

        public ActionResult OrderPending()
        {
            string customerName = Session["CustomerName"].ToString();
            Customer customer = db.Customers.SingleOrDefault(x => x.Username == customerName);
            long id = customer.ID;
            var orders = db.Orders.Where(x => x.CustomerID == id && x.StatusCategoryID == false).OrderByDescending(x => x.CreatedDate).ToList();

            return View(orders);
        }
        public ActionResult OrderApproval()
        {
            string customerName = Session["CustomerName"].ToString();
            Customer customer = db.Customers.SingleOrDefault(x => x.Username == customerName);
            long id = customer.ID;
            var orders = db.Orders.Where(x => x.CustomerID == id && x.StatusCategoryID == true).OrderByDescending(x => x.CreatedDate).ToList();

            return View(orders);
        }

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
    }
}
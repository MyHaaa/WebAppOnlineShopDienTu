using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopDienTu.Controllers
{
    public class ProfileController : Controller
    {
        OnlineShopElectronicsDbContext db = new OnlineShopElectronicsDbContext();
        // GET: Profile
        public ActionResult Index()
        {
            string customerName = Session["CustomerName"].ToString();
            return View(db.Customers.SingleOrDefault(x => x.Username == customerName));
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
    }
}
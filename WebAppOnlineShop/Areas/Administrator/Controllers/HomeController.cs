using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOnlineShop.Areas.Administrator.Controllers
{
    public class HomeController : BaseController
    {
        private OnlineShopElectronicsDbContext db = new OnlineShopElectronicsDbContext();

        // GET: Administrator/Home
        public ActionResult Index()
        {
            var customerCount = new CustomerDao().Count();
            TempData["userCount"] = customerCount;

            var productCount = db.Products.Count();
            TempData["productCount"] = productCount;

            var supplierCount = db.Suppliersses.Count();
            TempData["supplierCount"] = supplierCount;

            var orderCount = db.Orders.Count();
            TempData["orderCount"] = orderCount;


            return View();

        }
    }
}
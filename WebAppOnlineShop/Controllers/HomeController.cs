using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDao = new ProductDAO();
            ViewBag.OurProducts = productDao.ListOurProduct(3);
            ViewBag.HotSales = productDao.ListHotSales(3);
            ViewBag.NewProduct = productDao.NewProduct(1);
            return View();
        }
    }
}
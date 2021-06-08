using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopElectronics.Models;

namespace OnlineShopElectronics.Controllers
{
    public class ProductsController : Controller
    {
        OnlineShopElectronicsEntities db = new OnlineShopElectronicsEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult SearchName(string searchString)
        {
            return View(db.Products.Where(s => s.ProductName.Contains(searchString) || searchString == null).ToList());
        }
    }
}
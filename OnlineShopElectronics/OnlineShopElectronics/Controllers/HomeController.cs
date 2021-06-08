using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopElectronics.Models;

namespace OnlineShopElectronics.Controllers
{
    public class HomeController : Controller
    {
        OnlineShopElectronicsEntities db = new OnlineShopElectronicsEntities();
        public ActionResult Index()
        {
            ViewBag.NewProduct = db.Products.OrderByDescending(x => x.HomeFlag).Take(3).ToList();
            ViewBag.HotProduct = db.Products.OrderByDescending(x => x.HotFlag).Take(3).ToList();
            return View();
        }
        public ActionResult Details(long? id)
        {
            //Tìm sản phẩm có mã sản phẩm = id
            Product product = db.Products.SingleOrDefault(x => x.ID == id);
            //Nếu không tìm thấy
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        //public ActionResult ListProductPartial(int? MaLoaiSP, int? MaTH)
        //{

        //    //var lstSP = db.SanPhams.Where(n => n.MaLoaiSP == MaLoaiSP && n.MaNSX == MaTH);
        //    var lstSP = db.Products.Where(n => n.CategoryID == MaLoaiSP && n.SupplierID == MaTH);
        //    //taophantrangsp
            
        //    //so trang hien tai
           
        //    ViewBag.MaLoaiSP = MaLoaiSP;
        //    ViewBag.MaTH = MaTH;
        //    return View(lstSP.OrderBy(n => n.ID));
        //}
        public ActionResult MenuPartial()
        {
            //truyvan lay ve 1 list cac san pham
            var lstSP = db.Products;
            return PartialView(lstSP);
        }
        public ActionResult ListProductPartialLSP(int? MaLoaiSP)
        {

           
            var lstSP = db.Products.Where(n => n.CategoryID == MaLoaiSP);

            //taophantrangsp
            
            //so trang hien tai
            ViewBag.MaLoaiSP = MaLoaiSP;
            
            return View(lstSP.OrderBy(n => n.ID));
        }

        public ActionResult NewProduct()
        {
            ViewBag.NewProductPage = db.Products.OrderByDescending(x => x.HomeFlag==true).Take(5).ToList();
            return View();
        }
        public ActionResult HotProduct()
        {
            ViewBag.HotProductPage = db.Products.OrderByDescending(x => x.HotFlag== true).Take(5).ToList();
            return View();
        }
        public ActionResult Prfile(long? idkh)
        {
            Customer kh = db.Customers.Where(n => n.ID == idkh).SingleOrDefault();

            return View();
        }

    }
}
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppOnlineShop.Commons;

namespace WebAppOnlineShop.Areas.Administrator.Controllers
{
    public class ProductCategoriesController : Controller
    {
        // GET: Administrator/ProductCategories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View(GetAllPC());
        }

        IEnumerable<ProductCategory> GetAllPC()
        {
            using (OnlineShopElectronicsDbContext db = new OnlineShopElectronicsDbContext())
            {
                return db.ProductCategories.ToList<ProductCategory>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            ProductCategory emp = new ProductCategory();
            if (id != 0)
            {
                using (OnlineShopElectronicsDbContext db = new OnlineShopElectronicsDbContext())
                {
                    emp = db.ProductCategories.Where(x => x.ID == id).FirstOrDefault<ProductCategory>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(ProductCategory pc)
        {
            try
            {
                
                using (OnlineShopElectronicsDbContext db = new OnlineShopElectronicsDbContext())
                {
                    if (pc.ID == 0)
                    {
                  
                        db.ProductCategories.Add(pc);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(pc).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllPC()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (OnlineShopElectronicsDbContext db = new OnlineShopElectronicsDbContext())
                {
                    ProductCategory emp = db.ProductCategories.Where(x => x.ID == id).FirstOrDefault<ProductCategory>();
                    db.ProductCategories.Remove(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllPC()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
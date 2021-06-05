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
using PagedList;

namespace WebAppOnlineShop.Areas.Administrator.Controllers
{
    public class ProductsController : BaseController
    {
        private OnlineShopElectronicsDbContext db = new OnlineShopElectronicsDbContext();

        // GET: Administrator/Products
        public ActionResult Index(string cate, bool? status, int page = 1, int pageSize = 5)
        {
            var products = db.Products.Include(p => p.ProductCategory).Include(p => p.Supplierss);
            ViewBag.Category = (from c in db.ProductCategories
                                select c.Name).Distinct();
            ViewBag.Status = (from c in db.Products
                               select c.Status).Distinct();
            var category = db.ProductCategories.SingleOrDefault(x => x.Name == cate);

            if (!string.IsNullOrEmpty(cate) )
            {
                products = from c in db.ProductCategories
                           join p in db.Products on c.ID equals p.CategoryID
                           where p.CategoryID == category.ID
                           select p;
            }
            else if (status != null)
            {
                products = from c in db.ProductCategories
                           join p in db.Products on c.ID equals p.CategoryID
                           where p.Status == status
                           select p;
            }
            else if(!string.IsNullOrEmpty(cate) && (status != null))
            {
                products = from c in db.ProductCategories
                           join p in db.Products on c.ID equals p.CategoryID
                           where p.CategoryID == category.ID
                           where p.Status == status
                           select p;
            }

            return View(products.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize));
        }

        // GET: Administrator/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Administrator/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name");
            ViewBag.SupplierID = new SelectList(db.Suppliersses, "ID", "SupplierName");
          
            return View();
        }

        // POST: Administrator/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,Alias,CategoryID,SupplierID,Quantity,Image,Price,Description,MetaKeyword,CreatedDate,Status,HomeFlag,HotFlag")] Product product)
        {
            if (ModelState.IsValid )
            {
                int num = db.Products.Count();
                product.ID = num + 1;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliersses, "ID", "SupplierName", product.SupplierID);
            return View(product);
            //try
            //{
            //    if (pro.UploadImage != null)
            //    {
            //        string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
            //        string extent = Path.GetExtension(pro.UploadImage.FileName);
            //        filename = filename + extent;
            //        pro.ImagePro = "~/Content/images/" + filename;
            //        pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
            //    }
            //    db.Products.Add(pro);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Administrator/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliersses, "ID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // POST: Administrator/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,Alias,CategoryID,SupplierID,Quantity,Image,Price,Description,MetaKeyword,CreatedDate,Status,HomeFlag,HotFlag")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliersses, "ID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // GET: Administrator/Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Administrator/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
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

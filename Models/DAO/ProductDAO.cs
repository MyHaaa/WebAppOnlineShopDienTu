using Models.EF;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDAO
    {
        OnlineShopElectronicsDbContext db = null;
        public ProductDAO()
        {
            db = new OnlineShopElectronicsDbContext();
        }
        public bool ChangeStatus(long id)
        {
            var pro = db.Products.Find(id);
            pro.Status = !pro.Status;
            db.SaveChanges();
            return pro.Status;
        }

        public List<Product> ListOurProduct (int top)
        {
            return db.Products.Where(x=> x.HomeFlag == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListHotSales (int top)
        {
            return db.Products.Where(x => x.HotFlag == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> NewProduct (int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListRelatedProduct(long productId, int top)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != product.ID && x.CategoryID == product.CategoryID).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }


        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.ProductName == keyword).Count();
            var model = (from a in db.Products
                         join b in db.ProductCategories
                         on a.CategoryID equals b.ID
                         where a.ProductName.Contains(keyword)
                         select new
                         {
                             CateMetakeyword = b.MetaKeyword,
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.ProductName,
                             Metakeyword = a.MetaKeyword,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetakeyword = x.Metakeyword,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             Metakeyword = x.Metakeyword,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        /// <summary>
        /// Get list product by category id
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public List<Product> ListByCategoryId(int categoryID, ref int totalRecord, int pageIndex = 1 , int pagesize = 3)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = db.Products.Where(x => x.CategoryID == categoryID).OrderByDescending(x=> x.CreatedDate).Skip((pageIndex - 1) * pagesize).Take(pagesize).ToList();
            return model;
        }
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.ProductName.Contains(keyword)).Select(x => x.ProductName).ToList();
        }
    }
}

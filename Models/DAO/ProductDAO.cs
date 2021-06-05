using Models.EF;
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
    }
}

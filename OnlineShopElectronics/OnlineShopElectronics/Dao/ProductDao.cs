using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopElectronics.Models; 

namespace OnlineShopElectronics.Dao
{
    
    public class ProductDao
    {
        OnlineShopElectronicsEntities db = null;
        public ProductDao()
        {
            db = new OnlineShopElectronicsEntities();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

    }
}
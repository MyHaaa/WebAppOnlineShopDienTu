using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopElectronics.Models;

namespace OnlineShopElectronics.Dao
{
    public class OrderDetailDao
    {
        OnlineShopElectronicsEntities db = null;
        public OrderDetailDao()
        {
            db = new OnlineShopElectronicsEntities();
        }
        public long Insert(OrderDetail orderdetail)
        {
            db.OrderDetails.Add(orderdetail);
            db.SaveChanges();
            return orderdetail.OrderID;
        }
    }
}
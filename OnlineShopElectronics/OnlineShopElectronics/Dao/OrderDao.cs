using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopElectronics.Models;

namespace OnlineShopElectronics.Dao
{
    public class OrderDao
    {
        OnlineShopElectronicsEntities db = null;
        public OrderDao()
        {
            db = new OnlineShopElectronicsEntities();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}
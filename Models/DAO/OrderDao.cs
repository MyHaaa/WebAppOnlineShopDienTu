using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDao
    {
        OnlineShopElectronicsDbContext db = null;
        public OrderDao()
        {
            db = new OnlineShopElectronicsDbContext();
        }
        public long Insert(Order order)
        {
            int count = db.Orders.Count();
            order.ID = count + 1;
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}

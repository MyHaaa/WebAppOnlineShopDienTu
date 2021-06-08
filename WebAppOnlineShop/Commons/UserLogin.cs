using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppOnlineShop.Commons
{
    [Serializable]
    public class UserLogin
    {
        public long CustomerID { set; get; }
        public string CustomerName { set; get; }
      
    }
}
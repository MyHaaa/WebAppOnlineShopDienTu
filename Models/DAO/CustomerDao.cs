using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CustomerDao
    {
        OnlineShopElectronicsDbContext db = null;
        public CustomerDao()
        {
            db = new OnlineShopElectronicsDbContext();
        }

        public long Insert(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Customer GetById(string userName)
        {
            return db.Customers.SingleOrDefault(x => x.Username == userName);
        }


        public int Count()
        {
            var customers = db.Customers.Count();
            return customers;
        }


        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.Customers.SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.IsAdmin == true)
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -1;
                    }
                    else
                    {
                        return -2;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

        public bool ChangeStatus(long id)
        {
            var customer = db.Customers.Find(id);
            customer.Status = !customer.Status;
            db.SaveChanges();
            return customer.Status;
        }


        public bool CheckUserName(string userName)
        {
            return db.Customers.Count(x => x.Username == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Customers.Count(x => x.EmailContactPerson == email) > 0;
        }
    }
}
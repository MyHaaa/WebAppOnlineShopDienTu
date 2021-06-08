using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppOnlineShop.Commons;
using WebAppOnlineShop.Models;

namespace WebAppOnlineShop.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var result = dao.Login(model.UserName, model.Password, false);
                if (result == 1)
                {
                    var customer = dao.GetById(model.UserName);
                    var customerSession = new UserLogin();
                    customerSession.CustomerName = customer.Username;
                    customerSession.CustomerID = customer.ID;

                    Session.Add(CommonConstants.CUSTOMER_SESSION, customerSession);
                    Session["CustomerName"] = customerSession.CustomerName;
                    return Redirect("/");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Your Account was blocked.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", " Your password is wrong, please check again!");
                }
            }
            return View(model);
        }


        public ActionResult Logout()
        {
            Session[CommonConstants.CUSTOMER_SESSION] = null;
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var customer = new Customer();
                    customer.CustomerName = model.Name;
                    customer.Password = model.Password;
                    customer.MobileContactPerson = model.Phone;
                    customer.EmailContactPerson = model.Email;
                    customer.Address = model.Address;
                    customer.CreatedDate = DateTime.Now;
                    customer.Status = true;
                    

                    var result = dao.Insert(customer);
                    if (result > 0)
                    {
                        ViewBag.Success = "register Success";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", " Register no success");
                    }
                }
            }
            return View(model);
        }

    }
}
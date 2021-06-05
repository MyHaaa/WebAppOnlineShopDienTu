using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppOnlineShop.Areas.Administrator.ModelsAdmin;
using WebAppOnlineShop.Commons;

namespace WebAppOnlineShop.Areas.Administrator.Controllers
{
    public class LoginController : Controller
    {
        // GET: Administrator/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var result = dao.Login(model.Username, model.Password);
                if (result == 1)
                {
                    var customer = dao.GetById(model.Username);
                    var customerSession = new UserLogin();
                    customerSession.CustomerName = customer.Username;
                    customerSession.CustomerID = customer.ID;
                    
                    Session.Add(CommonConstants.CUSTOMER_SESSION, customerSession);
                    Session["CustomerName"] = customerSession.CustomerName;
                    return RedirectToAction("Index", "Home");
                }               
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu or tài khoản không đúng.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "  của bạn không có quyền đăng nhập.");
                }
            }
            return View("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAppOnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
     new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

           

            routes.MapRoute(
              name: "Product Category",
              url: "product/{metakeyword}-{cateId}",
              defaults: new { controller = "Product", action = "Categories", id = UrlParameter.Optional },
              namespaces: new[] { "WebAppOnlineShop.Controllers" }
          );

            routes.MapRoute(
             name: "Product Detail",
             url: "details/{metakeyword}-{id}",
             defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional },
             namespaces: new[] { "WebAppOnlineShop.Controllers" }
         );

            routes.MapRoute(
             name: "Cart",
             url: "my-cart",
             defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "WebAppOnlineShop.Controllers" }
         );

            routes.MapRoute(
            name: "Add to Cart",
            url: "add-to-cart",
            defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
            namespaces: new[] { "WebAppOnlineShop.Controllers" }
        );

            routes.MapRoute(
           name: "Login",
           url: "login",
           defaults: new { controller = "Customer", action = "Login", id = UrlParameter.Optional },
           namespaces: new[] { "WebAppOnlineShop.Controllers" }
       );

            routes.MapRoute(
         name: "Search",
         url: "search",
         defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
         namespaces: new[] { "WebAppOnlineShop.Controllers" }
     );

            routes.MapRoute(
           name: "Register",
           url: "register",
           defaults: new { controller = "Customer", action = "Register", id = UrlParameter.Optional },
           namespaces: new[] { "WebAppOnlineShop.Controllers" }
       );

            routes.MapRoute(
              name: "Check Out",
              url: "checkout",
              defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
              namespaces: new[] { "WebAppOnlineShop.Controllers" }
          );

            routes.MapRoute(
            name: "Check Out Success",
            url: "success",
            defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
            namespaces: new[] { "WebAppOnlineShop.Controllers" }
        );


            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "WebAppOnlineShop.Controllers" }
          );
        }
    }
}

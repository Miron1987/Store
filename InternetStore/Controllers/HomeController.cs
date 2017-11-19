using InternetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetStore.Controllers
{
    public class HomeController : Controller
    {
        StoreContext db = new StoreContext();
        //PurchaseContext db_p = new PurchaseContext();

        public ActionResult Index()
        {
            return View();
        }

        












        //    public ActionResult About()
        //    {
        //        ViewBag.Message = "Your application description page.";

        //        return View();
        //    }

        //    public ActionResult Contact()
        //    {
        //        ViewBag.Message = "Your contact page.";

        //        return View();
        //    }
        //}

    }
}
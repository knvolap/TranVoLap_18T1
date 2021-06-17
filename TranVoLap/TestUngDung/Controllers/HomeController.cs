using ModelEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var hienthiSPDao = new HienThiSPDao();
            ViewBag.ProductsSP = hienthiSPDao.ListALLProduct();
            return View();
        }

        //[ChildActionOnly]
        //public PartialViewResult Index()
        //{
        //    var model = new HienThiSPDao().ListALLProduct();
        //    return PartialView(model);
        //}


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
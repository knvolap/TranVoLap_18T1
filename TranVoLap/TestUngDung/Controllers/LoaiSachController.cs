using ModelEF.DAO;
using ModelEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class LoaiSachController : Controller
    {
        // GET: LoaiSach
        public ActionResult Index()
        {
            ViewBag.Categories = new LeftMainMenuDao().ListAllLLeftMenu();
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult LeftMainMenu()
        {
            var model = new LeftMainMenuDao().ListAllLLeftMenu();
            return PartialView(model);
        }

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
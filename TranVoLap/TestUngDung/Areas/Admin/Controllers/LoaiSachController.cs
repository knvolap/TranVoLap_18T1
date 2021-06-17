using ModelEF.DAO;
using ModelEF.Funtion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoaiSachController : Controller
    {
        // GET: Admin/LoaiSach
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var donhang = new LoaiSachFuntion();
            var model = donhang.ListAllPagingLSP(searchString, page, pageSize);
            ViewBag.ChuoiTimKiemLSP = searchString;
            return View(model);
        }
    }

}
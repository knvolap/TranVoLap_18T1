using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var donhang = new UserDao();
            var model = donhang.ListAllPagingDH(searchString, page, pageSize);
            ViewBag.ChuoiTimKiemDH = searchString;
            return View(model);
        }

    }
}
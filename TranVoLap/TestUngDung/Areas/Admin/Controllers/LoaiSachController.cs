using ModelEF.DAO;
using ModelEF.Funtion;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoaiSachController : BaseController
    {
        LoaiSachFuntion _LoaiSach = new LoaiSachFuntion();
        // GET: Admin/LoaiSach
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var donhang = new LoaiSachFuntion();
            var model = donhang.ListAllPagingLSP(searchString, page, pageSize);
            ViewBag.ChuoiTimKiemLSP = searchString;
            return View(model);
        }

        public ActionResult ThemLoaiSach()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemLoaiSach(Category loaisach)
        {
            if (ModelState.IsValid)
            {
                _LoaiSach.ThemLS(loaisach);
                SetAlert("Thêm thành công", "success");
                return RedirectToAction("Index");
            }
            return View(loaisach);
        }
        public ActionResult Xoa(string id)
        {
            _LoaiSach.XoaLS(id);
            SetAlert("Xóa thành công", "success");
            return RedirectToAction("Index");
        }
    }

}
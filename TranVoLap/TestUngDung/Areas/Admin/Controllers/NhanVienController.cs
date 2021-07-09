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
    public class NhanVienController : BaseController
    {
        NhanVienFunction _NhanVien = new NhanVienFunction();
        // GET: Admin/NhanVien
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var user = new UserDao();
            var model = user.ListAllPaging(searchString, page, pageSize);
            ViewBag.ChuoiTimKiem = searchString;
            return View(model);
        }


        public ActionResult ThemNhanVien()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemNhanVien(UserAccount nhanvien)
        {
            if (ModelState.IsValid)
            {
                _NhanVien.ThemNV(nhanvien);
                SetAlert("Thêm thành công", "success");
                return RedirectToAction("Index");
            }
            return View(nhanvien);
        }
        public ActionResult Xoa(string id)
        {
            _NhanVien.XoaNV(id);
            SetAlert("Xóa thành công", "success");
            return RedirectToAction("Index");
        }


        public ActionResult ChiTietNhanVien(string id)
        {
            var model = _NhanVien.GetNhanVienById(id);
            return View(model);
        }
        public ActionResult SuaNhanVien(string id)
        {
            return View(_NhanVien.GetNhanVienById(id));
        }

        [HttpPost]
        public ActionResult SuaNhanVien(UserAccount nguoidung)
        {
            _NhanVien.SuaNV(nguoidung);
            SetAlert("Sửa thành công", "success");
            return RedirectToAction("Index");
        }

        //[HttpPost]
        // public JsonResult ChangeStatus(long id)
        //{
        //    var result = new UserDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
    }
}
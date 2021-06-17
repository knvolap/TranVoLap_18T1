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
    public class NguoiDungController : BaseController
    {
        NguoiDungFunction _NguoiDung = new NguoiDungFunction();
        // GET: Admin/NhanVien
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var user = new UserDao();
            var model = user.ListAllPaging(searchString, page, pageSize);
            ViewBag.ChuoiTimKiem = searchString;
            return View(model);
        }


        public ActionResult ThemNguoiDung()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemNguoiDung(UserAccount nguoidung)
        {
            if (ModelState.IsValid)
            {
                _NguoiDung.ThemND(nguoidung);
                SetAlert("Thêm thành công", "success");
                return RedirectToAction("Index");
            }
            return View(nguoidung);
        }
        public ActionResult Xoa(string id)
        {
            _NguoiDung.XoaND(id);
            SetAlert("Xóa thành công", "success");
            return RedirectToAction("Index");
        }



        //public ActionResult Create(UserAccount user)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var dao = new UserDao();
        //        long id = dao.Insert(user);
        //        if(id>0)
        //        {
        //            return RedirectToAction("Index", "User");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Thêm người dùng thất bại");
        //        }
        //    }
        //    return View("Create");
        //}

    }
}
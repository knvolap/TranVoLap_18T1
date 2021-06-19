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
    public class SanPhamController : BaseController
    {
        SanPhamFunction _SanPham = new SanPhamFunction();
        // GET: Admin/SanPham
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var sanpham = new SanPhamFunction();
            var model = sanpham.GetListSanPham(searchString,page, pageSize);
            ViewBag.ChuoiTimKiemSP = searchString;
            return View(model);
        }

        public ActionResult ThemSanPham()
        {
            ViewBag.IDCategory = new SelectList(_SanPham.GetCategories(), "IDCategory", "NameCategory");
            return View();
        }

        [HttpPost]
        public ActionResult ThemSanPham(Product sanpham)
        {
            if (ModelState.IsValid)
            {
                _SanPham.ThemSP(sanpham);
                SetAlert("Thêm thành công", "success");
                return RedirectToAction("Index");
            }
            return View(sanpham);
        }

        //sửa sản phẩm
        public ActionResult Sua(string id)
        {
            ViewBag.IDCategory = new SelectList(_SanPham.GetCategories(), "IDCategory", "NameCategory");
            return View(_SanPham.GetSanPhamById(id));
        }

        [HttpPost]
        public ActionResult Sua(Product sanpham)
        {
            _SanPham.SuaSP(sanpham);
            SetAlert("Sửa thành công", "success");
            return RedirectToAction("Index");
        }

        public ActionResult ChiTietSanPham(string id)
        {
            var model = _SanPham.GetSanPhamById(id);
            return View(model);
        }
       
        //Xóa sản phẩm
        public ActionResult XoaSP(string id)
        {
            _SanPham.XoaSP(id);
            SetAlert("Xóa thành công", "success");
            return RedirectToAction("Index");
        }
    }
}
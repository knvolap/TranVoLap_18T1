using ModelEF;
using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestUngDung.Areas.Admin.Data;
using TestUngDung.Extensions;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDao();

                var result = user.login(login.Accounts, Common.EncryptMD5(login.Password));
                if (result == 0)
                {
                    this.AddNotification("Tài khoản không tồn tại", NotificationType.ERROR);
                }
                else if (result == 1)//đăng nhập thành công
                {
          
                    //kiểm tra khi đăng nhập -> trả về tên người dùng
                    Session.Add(Constants.USER_SESSION, login);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == -1)
                {
                    this.AddNotification("Tài khoản chưa được kích hoạt", NotificationType.ERROR);
                }
                else if (result == -2)
                {
                    this.AddNotification("Sai mật khẩu", NotificationType.ERROR);
                }
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;        
            return RedirectToAction("Index", "Login");
        }
    }
}

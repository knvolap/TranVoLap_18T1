﻿using TestUngDung.Controllers;
using ModelEF;
using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestUngDung.Areas.Admin.Data;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        /*check đăng nhập thì phải login*/
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (LoginModel)Session[Constants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Areas = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }

        // GET: Admin/CheckErro
        protected void SetAlert(String message, String type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else
            if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else
            if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}
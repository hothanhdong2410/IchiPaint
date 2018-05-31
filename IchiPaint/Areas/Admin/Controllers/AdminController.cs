using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IchiPaint.Common;
using IchiPaint.DataAccess;
using IchiPaint.Models;
using NaviCommon;

namespace IchiPaint.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private UsersDA _usersDa = new UsersDA();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString());
                throw;
            }
        }
        [HttpPost]
        public ActionResult Login(User request)
        {
            try
            {
                DataSet ds = new DataSet();
                _usersDa.CheckLogin(request, ref ds);

                if (!_usersDa.CheckLogin(request, ref ds))
                    return Json(new
                    {
                        Status = false,
                        Message = "Sai tên đăng nhập hoặc mật khẩu"
                    });

                var user = (User)CBO.FillObjectFromDataSet(ds, typeof(User));
                DataMemory.CurrentUser = user;
                return Json(new
                {
                    Status = true,
                    Message = "Đăng nhập thành công"
                });
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString());
                throw;
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                var httpSession = System.Web.HttpContext.Current.Session;
                if (httpSession.Count > 0)
                {
                    Response.Cookies.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString());
                throw;
            }
            return RedirectToAction("Login");
        }


        [HttpGet]
        public ActionResult Setting()
        {
            try
            {
                var httpSession = System.Web.HttpContext.Current.Session;
                if (httpSession.Count > 0)
                {
                    Response.Cookies.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString());
                throw;
            }
            return View();
        }
    }
}
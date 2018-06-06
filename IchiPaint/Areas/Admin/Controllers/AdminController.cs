using System;
using System.Data;
using System.Web.Mvc;
using IchiPaint.Common;
using IchiPaint.DataAccess;
using IchiPaint.Models;

namespace IchiPaint.Areas.Admin.Controllers
{
    [RoutePrefix("admin")]
    public class AdminController : Controller
    {
        private readonly UsersDA _usersDa = new UsersDA();

        [Route("dang-nhap")]
        [HttpGet]
        public ActionResult Login()
        {
            try
            {
                return View("~/Areas/Admin/Views/Admin/Login.cshtml");
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
                var ds = new DataSet();
                _usersDa.CheckLogin(request, ref ds);

                if (!_usersDa.CheckLogin(request, ref ds))
                    return Json(new
                    {
                        Status = false,
                        Message = "Sai tên đăng nhập hoặc mật khẩu"
                    });

                var user = (User) CBO.FillObjectFromDataSet(ds, typeof(User));
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

        [Route("dang-xuat")]
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
            return Redirect("/admin/dang-nhap");
        }
    }
}
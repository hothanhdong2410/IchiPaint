using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IchiPaint.Common;
using IchiPaint.DataAccess;
using IchiPaint.Helpers;
using IchiPaint.Models;
using NaviCommon;

namespace IchiPaint.Areas.Admin.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectDa _projectDa = new ProjectDa();
        [HttpGet]
        public ActionResult List()
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            var request = new SearchProjectRequest
            {
                CurrentPage = 1,
                Start = 1,
                End = ConfigInfo.RecordOnPage
            };

            return View(SearchProject(request));
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectRequest request)
        {
            var result = _projectDa.Create(request);
            if (result > 0)
                return Json(new
                {
                    Status = true,
                    Message = "Tạo công trình thành công"
                });
            return Json(new
            {
                Status = false,
                Message = "Tạo công trình thất bại"
            });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            var project =
                (Project)CBO.FillObjectFromDataSet(_projectDa.GetById(id), typeof(Project));

            return View("~/Areas/Admin/Views/Project/Edit.cshtml", project);
        }

        [HttpPost]
        public ActionResult Edit(Project request)
        {
            var result = _projectDa.Edit(request);
            if (result > 0)
                return Json(new
                {
                    Status = true,
                    Message = "Sửa công trình thành công"
                });
            return Json(new
            {
                Status = false,
                Message = "Sửa công trình thất bại"
            });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = _projectDa.Delete(id);
            if (result > 0)
                return Json(new
                {
                    Status = true,
                    Message = "Xóa thành công"
                });
            return Json(new
            {
                Status = false,
                Message = "Xóa thất bại"
            });
        }

        [HttpPost]
        public ActionResult Search(SearchProjectRequest request)
        {
            return PartialView("~/Areas/Admin/Views/Project/_listProject.cshtml", SearchProject(request));
        }

        private ListProject SearchProject(SearchProjectRequest request)
        {
            var total = 0;
            var ds = _projectDa.Search(request, ref total);
            var lstNew = CBO.Fill2ListFromDataSet<Project>(ds, typeof(Project));
            var totalPage = Math.Ceiling(((decimal)total / ConfigInfo.RecordOnPage));
            var paging = HtmlControllHelpers.WritePaging(totalPage, request.CurrentPage, total, ConfigInfo.RecordOnPage, "Công trình");
            var listNews = new ListProject()
            {
                Start = request.Start,
                Collection = lstNew,
                Paging = paging,
                TotalRecord = total,
                TotalPage = totalPage,
                CurrentPage = request.CurrentPage
            };
            return listNews;
        }
    }
}
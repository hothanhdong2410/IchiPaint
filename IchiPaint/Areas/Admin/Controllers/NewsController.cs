using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using IchiPaint.Common;
using IchiPaint.DataAccess;
using IchiPaint.Helpers;
using IchiPaint.Models;
using NaviCommon;

namespace IchiPaint.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsDA _newsDa = new NewsDA();

        [HttpGet]
        public ActionResult List()
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            var request = new SearchNewsRequest
            {
                CurrentPage = 1,
                Start = 1,
                End = ConfigInfo.RecordOnPage,
                OrderBy = "CreateDate",
                OrderByType = "DESC"
            };

            return View(SearchNews(request));
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsRequest model)
        {
            var ketqua = _newsDa.Create(model);
            if (ketqua > 0)
                return Json(new
                {
                    Status = true,
                    Message = "Tạo tin mới thành công"
                });
            return Json(new
            {
                Status = false,
                Message = "Tạo tin mới thất bại"
            });
        }

        [HttpPost]
        public ActionResult Search(SearchNewsRequest request)
        {
            return PartialView("~/Areas/Admin/Views/News/_listNews.cshtml", SearchNews(request));
        }

        [HttpGet]
        public ActionResult EditNews(int id)
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            var news = (News)CBO.FillObjectFromDataSet(_newsDa.GetById(id), typeof(News));

            return View("~/Areas/Admin/Views/News/Edit.cshtml", news);
        }

        [HttpPost]
        public ActionResult Edit(News request)
        {
            var result = _newsDa.Edit(request);
            if (result > 0)
                return Json(new
                {
                    Status = true,
                    Message = "Sửa bài viết thành công"
                });
            return Json(new
            {
                Status = false,
                Message = "Sửa bài viết thất bại"
            });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = _newsDa.Delete(id);
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

        private ListNews SearchNews(SearchNewsRequest request)
        {
            var total = 0;
            var ds = _newsDa.Search(request, ref total);
            var lstNew = CBO.Fill2ListFromDataSet<News>(ds, typeof(News));
            decimal totalPage = Math.Ceiling(((decimal)total / (decimal)ConfigInfo.RecordOnPage));
            var paging = HtmlControllHelpers.WritePaging(totalPage, request.CurrentPage, total, ConfigInfo.RecordOnPage, "Tin tức");
            var listNews = new ListNews
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
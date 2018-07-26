using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IchiPaint.Common;
using IchiPaint.DataAccess;
using IchiPaint.Models;

namespace IchiPaint.Areas.Admin.Controllers
{
    public class PageController : Controller
    {
        private PageDA _pageDa = new PageDA();
        public ActionResult AboutUs()
        {
            var model = GetById(1);
            return View(model);
        }

        public ActionResult AgencyPolicy()
        {
            var model = GetById(2);
            return View(model);
        }


        public ActionResult Recruitment()
        {
            var model = GetById(4);
            return View(model);
        }
        public ActionResult ContactUs()
        {
            var model = GetById(3);
            return View(model);
        }

        private Page GetById(int id)
        {
            try
            {
                var ds = _pageDa.GetById(id);
                var page = (Page)CBO.FillObjectFromDataSet(ds, typeof(Page));
                return page;
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString());
                return new Page();
            }
        }

        public ActionResult Edit(Page request)
        {
            try
            {
                var result = _pageDa.Edit(request);
                DataMemory.LoadPage();
                return Json(new
                {
                    Status = result > 0
                });
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString());
            }
            return Json(new
            {
                Status = false
            });
        }
    }
}
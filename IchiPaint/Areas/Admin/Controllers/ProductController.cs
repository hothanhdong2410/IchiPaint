using System;
using System.Collections.Generic;
using System.Data;
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
    public class ProductController : Controller
    {
        private readonly ProductDA _productDa = new ProductDA();

        #region Group

        [HttpGet]
        public ActionResult GroupList()
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            var request = new SearchGroupProductRequest
            {
                CurrentPage = 1,
                Start = 1,
                End = ConfigInfo.RecordOnPage,
                OrderBy = "GroupName",
                OrderByType = "Asc"
            };

            return View(SearchGroupProduct(request));
        }

        [HttpGet]
        public ActionResult CreateGroup()
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            return View();
        }

        [HttpPost]
        public ActionResult CreateGroup(GroupProductsRequest request)
        {
            var result = _productDa.CreateGroup(request);
            if (result > 0)
                return Json(new
                {
                    Status = true,
                    Message = "Tạo nhóm thành công"
                });
            return Json(new
            {
                Status = false,
                Message = "Tạo nhóm thất bại"
            });
        }

        [HttpGet]
        public ActionResult EditGroup(int id)
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            var groupProduct =
                (GroupProducts) CBO.FillObjectFromDataSet(_productDa.GetGroupById(id), typeof(GroupProducts));

            return View("~/Areas/Admin/Views/Product/EditGroup.cshtml", groupProduct);
        }

        [HttpPost]
        public ActionResult EditGroup(GroupProducts request)
        {
            var result = _productDa.EditGroup(request);
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
        public ActionResult DeleteGroup(int id)
        {
            var result = _productDa.DeleteGroup(id);
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
        public ActionResult SearchGroup(SearchGroupProductRequest request)
        {
            return PartialView("~/Areas/Admin/Views/Product/_listGroupProduct.cshtml", SearchGroupProduct(request));
        }

        private ListGroupProducts SearchGroupProduct(SearchGroupProductRequest request)
        {
            var total = 0;
            var ds = _productDa.SearchGroup(request, ref total);
            var lstGroupProduct = CBO.Fill2ListFromDataSet<GroupProducts>(ds, typeof(GroupProducts));
            decimal totalPage = Math.Ceiling(((decimal) total / ConfigInfo.RecordOnPage));
            var paging = HtmlControllHelpers.WritePaging(totalPage, request.CurrentPage, total, ConfigInfo.RecordOnPage,
                "nhóm sản phẩm");
            var listGroupProducts = new ListGroupProducts
            {
                Start = request.Start,
                Collection = lstGroupProduct,
                Paging = paging,
                TotalRecord = total,
                TotalPage = totalPage,
                CurrentPage = request.CurrentPage
            };
            return listGroupProducts;
        }

        #endregion

        #region Product

        [HttpGet]
        public ActionResult ListProduct()
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            var request = new SearchProductRequest()
            {
                CurrentPage = 1,
                Start = 1,
                End = ConfigInfo.RecordOnPage,
                OrderBy = "ShortName",
                OrderByType = "Asc"
            };

            return View(FindProduct(request));
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            ViewBag.GroupProduct = GetGroupProduct();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductsRequest request)
        {
            var result = _productDa.CreateProduct(request);
            if (result > 0)
                return Json(new
                {
                    Status = true,
                    Message = "Tạo sản phẩm thành công"
                });
            return Json(new
            {
                Status = false,
                Message = "Tạo sản phẩm thất bại"
            });
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            if (DataMemory.CurrentUser == null)
                return RedirectToAction("Logout", "Admin");
            var product = (Products) CBO.FillObjectFromDataSet(_productDa.GetProductById(id), typeof(Products));
            ViewBag.GroupProduct = GetGroupProduct();
            return View("~/Areas/Admin/Views/Product/EditProduct.cshtml", product);
        }

        [HttpPost]
        public ActionResult EditProduct(Products request)
        {
            var result = _productDa.EditProduct(request);
            if (result > 0)
                return Json(new
                {
                    Status = true,
                    Message = "Sửa sản phẩm thành công"
                });
            return Json(new
            {
                Status = false,
                Message = "Sửa sản phẩm thất bại"
            });
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            var result = _productDa.DeleteProduct(id);
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
        public ActionResult SearchProduct(SearchProductRequest request)
        {
            return PartialView("~/Areas/Admin/Views/Product/_listProduct.cshtml", FindProduct(request));
        }

        private ListProducts FindProduct(SearchProductRequest request)
        {
            var total = 0;
            var ds = _productDa.SearchProduct(request, ref total);
            var lstGroupProduct = CBO.Fill2ListFromDataSet<Products>(ds, typeof(Products));
            var totalPage = Math.Ceiling(((decimal) total / ConfigInfo.RecordOnPage));
            var paging = HtmlControllHelpers.WritePaging(totalPage, request.CurrentPage, total, ConfigInfo.RecordOnPage,
                "nhóm sản phẩm");
            var listGroupProducts = new ListProducts()
            {
                Start = request.Start,
                Collection = lstGroupProduct,
                Paging = paging,
                TotalRecord = total,
                TotalPage = totalPage,
                CurrentPage = request.CurrentPage
            };
            return listGroupProducts;
        }

        #endregion

        private List<GroupProducts> GetGroupProduct()
        {
            var groupProductses = new List<GroupProducts>();
            DataSet ds = _productDa.GetAllGroup();
            groupProductses = CBO.Fill2ListFromDataSet<GroupProducts>(ds, typeof(GroupProducts));
            return groupProductses;
        }
    }
}

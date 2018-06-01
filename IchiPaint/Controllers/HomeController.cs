﻿using System;
using System.Data;
using System.Web.Mvc;
using IchiPaint.Common;
using IchiPaint.DataAccess;
using IchiPaint.Helpers;
using IchiPaint.Models;
using NaviCommon;

namespace IchiPaint.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsDA _newsDa = new NewsDA();
        private readonly ProductDA _productDa = new ProductDA();
        private readonly ProjectDa _projectDa = new ProjectDa();
        private readonly PageDA _pageDa = new PageDA();
        public ActionResult Index()
        {
            var portalSearchNews = new PortalSearchNewsIndex
            {
                Start = 1,
                End = 4,
                Id = 0
            };
            var pTotal = 0;
            var ds = _newsDa.GetForPortalDetail(portalSearchNews, ref pTotal);

            var list = CBO.Fill2ListFromDataSet<News>(ds, typeof(News));
            var listView = new ListNews
            {
                Collection = list
            };


            ds = _projectDa.GetSpecial();
            var listProject = CBO.Fill2ListFromDataSet<Project>(ds, typeof(Project));

            var indexPortal = new IndexPortal()
            {
                LstNews = new ListNews()
                {
                    Collection = list
                },
                LstProject = new ListProject()
                {
                    Collection = listProject
                }
            };
            return View(indexPortal);
        }

        [HttpGet]
        [Route("tin-tuc/{id}/{title}")]
        public ActionResult NewsDetail(string id, string title)
        {
            var ds = _newsDa.GetById(Convert.ToInt32(id));
            var news = (News)CBO.FillObjectFromDataSet(ds, typeof(News));

            return View(news);
        }

        [HttpPost]
        [Route("get-suggest-news")]
        public ActionResult GetSuggestNews(int id)
        {
            var portalSearchNews = new PortalSearchNewsIndex
            {
                Start = 1,
                End = 3,
                Id = id
            };
            var pTotal = 0;
            var ds = _newsDa.GetForPortalDetail(portalSearchNews, ref pTotal);

            var list = CBO.Fill2ListFromDataSet<News>(ds, typeof(News));
            var listView = new ListNews
            {
                Collection = list
            };
            return PartialView("_newsSuggest", listView);
        }

        [HttpGet]
        [Route("tin-tuc.htm")]
        public ActionResult ListNews()
        {
            var portalSearchNews = new PortalSearchNews
            {
                CurrentPage = 1,
                Start = 1,
                End = ConfigInfo.RecordOnPageIndex
            };
            News news;
            var listNews = SearchNewsForPortal(portalSearchNews, out news);
            ViewBag.SpecialNews = news;
            return View(listNews);
        }

        [HttpGet]
        [Route("tin-tuc/page={index}")]
        public ActionResult SearchNewsPortal(int index)
        {
            if (index <= 0) return View("ListNews", new ListNews());
            var portalSearchNews = new PortalSearchNews
            {
                CurrentPage = index,
                Start = (index - 1) * ConfigInfo.RecordOnPageIndex + 1,
                End = index * ConfigInfo.RecordOnPageIndex
            };
            News news;
            var listNews = SearchNewsForPortal(portalSearchNews, out news);
            ViewBag.SpecialNews = news;
            return View("ListNews", listNews);
        }


        [HttpGet]
        [Route("san-pham.htm")]
        public ActionResult ListProduct()
        {
            var portalSearchNews = new PortalSearchNews
            {
                CurrentPage = 1,
                Start = 1,
                End = ConfigInfo.RecordOnPageIndex
            };
            News news;
            var listNews = SearchNewsForPortal(portalSearchNews, out news);
            ViewBag.SpecialNews = news;
            return View(listNews);
        }

        [HttpGet]
        [Route("bang-mau.htm")]
        public ActionResult ColorBoard()
        {
            return View();
        }

        private ListNews SearchNewsForPortal(PortalSearchNews portalSearchNews, out News news)
        {
            news = new News();
            var total = 0;
            var ds = _newsDa.GetForPortalIndex(portalSearchNews, ref total);
            var list = CBO.Fill2ListFromDataSet<News>(ds, typeof(News));
            var totalPage = Math.Ceiling((decimal)total / ConfigInfo.RecordOnPageIndex);
            var paging = HtmlControllHelpers.WritePagingPortal(totalPage, portalSearchNews.CurrentPage, total,
                ConfigInfo.RecordOnPageIndex);
            var listNews = new ListNews
            {
                Start = portalSearchNews.Start,
                Collection = list,
                Paging = paging,
                TotalRecord = total,
                TotalPage = totalPage,
                CurrentPage = portalSearchNews.CurrentPage
            };

            ds = _newsDa.GetSpecialNews();

            news = (News)CBO.FillObjectFromDataSet(ds, typeof(News));
            return listNews;
        }

        #region Sản phẩm
        [HttpGet]
        [Route("san-pham/son-trang-tri.htm")]
        public ActionResult DecorativePaint()
        {
            var key = 6;
            var request = new SearchProductPortalRequest()
            {
                CurrentPage = 1,
                Start = 1,
                End = ConfigInfo.RecordOnPageIndex,
                GroupId = key,
                OrderBy = "Id",
                OrderByType = "Desc",
                GroupName = "Sơn trang trí"
            };

            var list = GetProductPortal(request);
            list.Router = "son-trang-tri";
            return View("Products", list);
        }

        [HttpGet]
        [Route("san-pham/son-bao-ve.htm")]
        public ActionResult ProtectivePaint()
        {
            var key = 7;
            var request = new SearchProductPortalRequest()
            {
                CurrentPage = 1,
                Start = 1,
                End = ConfigInfo.RecordOnPageIndex,
                GroupId = key,
                OrderBy = "Id",
                OrderByType = "Desc",
                GroupName = "Sơn bảo vệ"
            };

            var list = GetProductPortal(request);
            list.Router = "son-bao-ve";
            return View("Products", list);
        }

        [HttpGet]
        [Route("san-pham/son-tau-bien.htm")]
        public ActionResult PaintingShip()
        {
            var key = 9;
            var request = new SearchProductPortalRequest()
            {
                CurrentPage = 1,
                Start = 1,
                End = ConfigInfo.RecordOnPageIndex,
                GroupId = key,
                OrderBy = "Id",
                OrderByType = "Desc",
                GroupName = "Sơn tàu biển"
            };

            var list = GetProductPortal(request);
            list.Router = "son-tau-bien";
            return View("Products", list);
        }

        [HttpGet]
        [Route("san-pham/san-pham-khac.htm")]
        public ActionResult OthersPaint()
        {
            var key = 8;
            var request = new SearchProductPortalRequest()
            {
                CurrentPage = 1,
                Start = 1,
                End = ConfigInfo.RecordOnPageIndex,
                GroupId = key,
                OrderBy = "Id",
                OrderByType = "Desc",
                GroupName = "Sản phẩm khác"
            };

            var list = GetProductPortal(request);
            list.Router = "san-pham-khac";
            return View("Products", list);
        }

        [HttpGet]
        [Route("san-pham/{type}/page={index}")]
        public ActionResult SearchProducts(string type, int index)
        {
            var key = 0;
            var groupName = "";
            switch (type)
            {
                case "son-trang-tri":
                    key = 6;
                    groupName = "Sơn trang trí";
                    break;
                case "son-bao-ve":
                    key = 7;
                    groupName = "Sơn bảo vệ";
                    break;
                case "san-pham-khac":
                    key = 8;
                    groupName = "Sản phẩm khác";
                    break;
                default:
                    key = 0;
                    break;
            }

            var request = new SearchProductPortalRequest()
            {
                CurrentPage = index,
                Start = (index - 1) * ConfigInfo.RecordOnPageIndex + 1,
                End = index * ConfigInfo.RecordOnPageIndex,
                GroupId = key,
                OrderBy = "Id",
                OrderByType = "Desc",
                GroupName = groupName
            };

            var list = GetProductPortal(request);
            list.Router = type;
            return View("Products", list);
        }

        ///san-pham-chi-tiet/{0}/{1}


        [HttpGet]
        [Route("san-pham-chi-tiet/{id}/{htm}")]
        public ActionResult ProductDetail(int id, string index)
        {
            DataSet ds = _productDa.GetProductById(id);
            Products products = (Products)CBO.FillObjectFromDataSet(ds, typeof(Products));
            return View(products);
        }

        private ListProductsPortal GetProductPortal(SearchProductPortalRequest productPortalRequest)
        {
            var total = 0;
            var ds = _productDa.GetProductPortal(productPortalRequest, ref total);
            var list = CBO.Fill2ListFromDataSet<Products>(ds, typeof(Products));
            var totalPage = Math.Ceiling((decimal)total / ConfigInfo.RecordOnPageIndex);
            var paging = HtmlControllHelpers.WritePagingPortal(totalPage, productPortalRequest.CurrentPage, total,
                ConfigInfo.RecordOnPageIndex);
            var listNews = new ListProductsPortal
            {
                Start = productPortalRequest.Start,
                Collection = list,
                Paging = paging,
                TotalRecord = total,
                TotalPage = totalPage,
                CurrentPage = productPortalRequest.CurrentPage,
                PageName = productPortalRequest.GroupName
            };
            return listNews;
        }
        #endregion

        #region Công trình tiêu biểu

        [HttpGet]
        [Route("cong-trinh-tieu-bieu.htm")]
        public ActionResult OutstandingProject()
        {
            var request = new SearchProjectRequest
            {
                Start = 1,
                End = 1000
            };

            var total = 0;
            var ds = _projectDa.Search(request, ref total);
            var lst = CBO.Fill2ListFromDataSet<Project>(ds, typeof(Project));
            var listProject = new ListProject()
            {
                Collection = lst
            };
            return View(listProject);
        }
        #endregion

        #region Phong thủy


        [HttpGet]
        [Route("dich-vu/xem-mau-phong-thuy.htm")]
        public ActionResult PhongThuy()
        {
            return View();
        }

        [HttpPost]
        [Route("tinh-toan-phong-thuy")]
        public ActionResult PhongThuy(int year)
        {
            int canChi = (year - 3) / 60;

            if (DataMemory.PhongThuy.PhongThuyDictionary.ContainsKey(canChi))
            {
                return Json(new
                {
                    Status = true,
                    Menh = DataMemory.PhongThuy.PhongThuyDictionary[canChi]
                });
            }
            return Json(new
            {
                Status = false
            });
        }
        #endregion

        [HttpGet]
        [Route("dang-ky-tu-van.htm")]
        public ActionResult RegisterAdvisory()
        {
            return View();
        }

        [HttpPost]
        [Route("register-advisory")]
        public ActionResult RegisterAdvisory(RegisterAdvisory request)
        {
            var emailInfo = DataMemory.EmailOriginal;

            emailInfo.Content = string.Format(ConfigInfo.EmailTemplate, request.FullName, request.Phone, request.Email,
                request.AppointmentDate, request.Content);

            emailInfo.MailTo = request.Email;
            var result =  EmailHelper.SendMail(emailInfo, out var oMsg);

            return Json(new
            {
                Status = result
            });
        }

        //dich-vu/cong-cu-tinh-luong-son.htm

        [HttpGet]
        [Route("dich-vu/cong-cu-tinh-luong-son.htm")]
        public ActionResult CalculatorPaint()
        {
            return View();
        }

        [HttpGet]
        [Route("chung-nhan-san-pham.htm")]
        public ActionResult ProductCertification()
        {
            return View();
        }

        [HttpGet]
        [Route("chinh-sach-dai-ly.htm")]
        public ActionResult AgencyPolicy()
        {
            var model = GetById(2);
            return View(model);
        }

        [HttpGet]
        [Route("gioi-thieu.htm")]
        public ActionResult AboutUs()
        {
            var model = GetById(1);
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
    }
}
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using IchiPaint.Common;
using IchiPaint.DataAccess;
using IchiPaint.Helpers;
using IchiPaint.Models;
using System.Linq;

namespace IchiPaint.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsDA _newsDa = new NewsDA();
        private readonly ProductDA _productDa = new ProductDA();
        private readonly ProjectDa _projectDa = new ProjectDa();
        private readonly PageDA _pageDa = new PageDA();
        private readonly ColorWarehouseDA _colorWarehouseDa = new ColorWarehouseDA();

        public ActionResult Index()
        {
            List<News> list = DataMemory.c_lstNew.OrderByDescending(i => i.Special).ThenByDescending(i => i.Id).Take(4).ToList();
            List<Project> listProject = DataMemory.c_lstProject.FindAll(i => i.Special == "Y").ToList();

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

            List<News> list = CBO<News>.FillCollectionFromDataSet(ds);
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
        [Route("bang-mau-noi-that.htm")]
        public ActionResult ColorBoard()
        {
            return View();
        }

        [HttpGet]
        [Route("bang-mau-ngoai-that.htm")]
        public ActionResult ColorBoard_Out()
        {
            return View();
        }

        [HttpGet]
        [Route("quat-mau.htm")]
        public ActionResult ColorBoard_QuatMau()
        {
            return View();
        }

        private ListNews SearchNewsForPortal(PortalSearchNews portalSearchNews, out News news)
        {
            news = new News();
            var total = 0;
            var ds = _newsDa.GetForPortalIndex(portalSearchNews, ref total);
            //var list = CBO.Fill2ListFromDataSet<News>(ds, typeof(News));
            List<News> list = CBO<News>.FillCollectionFromDataSet(ds);
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
        [Route("san-pham/son-noi-that.htm")]
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
                GroupName = "Sơn trang trí nội thất"
            };

            var list = GetProductPortal(request);
            list.Router = "son-noi-that";
            return View("Products", list);
        }

        [HttpGet]
        [Route("san-pham/son-ngoai-that.htm")]
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
                GroupName = "Sơn trang trí ngoại thất"
            };

            var list = GetProductPortal(request);
            list.Router = "son-ngoai-that";
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
                GroupName = "Hệ sản phẩm khác"
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
                case "son-noi-that":
                    key = 6;
                    groupName = "Sơn trang trí nội thất";
                    break;
                case "son-ngoai-that":
                    key = 7;
                    groupName = "Sơn trang trí ngoại thất";
                    break;
                case "san-pham-khac":
                    key = 8;
                    groupName = "Hệ sản phẩm khác";
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

        [HttpGet]
        [Route("san-pham-chi-tiet/{id}/{htm}")]
        public ActionResult ProductDetail(int id, string index)
        {
            DataSet ds = _productDa.GetProductById(id);
            Products products = (Products)CBO.FillObjectFromDataSet(ds, typeof(Products));
            return View(products);
        }


        [HttpPost]
        [Route("get-san-pham")]
        public ActionResult GetProduct(int id)
        {
            DataSet ds = _productDa.GetProductById(id);
            Products products = (Products)CBO.FillObjectFromDataSet(ds, typeof(Products));
            return Json(new
            {
                img = products.Avatar,
                name = products.ShortName,
                coating = products.CoatingThickness
            });

        }

        private ListProductsPortal GetProductPortal(SearchProductPortalRequest productPortalRequest)
        {
            var total = 0;
            var ds = _productDa.GetProductPortal(productPortalRequest, ref total);
            List<Products> list = CBO<Products>.FillCollectionFromDataSet(ds);
            list = list.OrderByDescending(m => m.Price).ThenByDescending(m => m.Id).ToList();
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
            //var request = new SearchProjectRequest
            //{
            //    Start = 1,
            //    End = 1000
            //};

            //var total = 0;
            //var ds = _projectDa.Search(request, ref total);
            //List<Project> lst = CBO<Project>.FillCollectionFromDataSet(ds);
            var listProject = new ListProject()
            {
                Collection = DataMemory.c_lstProject
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
            int canChi = (year - 3) % 60;

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

            emailInfo.MailTo = ConfigInfo.EmailBusiness;
            string oMsg = "";
            var result = EmailHelper.SendMail(emailInfo, out oMsg);

            return Json(new
            {
                Status = result
            });
        }


        [HttpGet]
        [Route("dich-vu/kho-du-lieu-phoi-mau.htm")]
        public ActionResult ColorWarehouse()
        {

            var request = new SearchColorWarehouseRequest()
            {
                Start = 1,
                End = 1000
            };

            var total = 0;
            var ds = _colorWarehouseDa.Search(request, ref total);
            List<ColorWarehouse> lst = CBO<ColorWarehouse>.FillCollectionFromDataSet(ds);
            var listColorWarehouse = new ListColorWarehouse()
            {
                Collection = lst
            };
            return View(listColorWarehouse);
        }

        [HttpGet]
        [Route("dich-vu/cong-cu-tinh-luong-son.htm")]
        public ActionResult CalculatorPaint()
        {
            try
            {
                var request = new SearchProductRequest()
                {
                    CurrentPage = 1,
                    Start = 1,
                    End = 1000,
                    OrderBy = "ShortName",
                    OrderByType = "Asc"
                };
                var total = 0;
                var ds = _productDa.SearchProduct(request, ref total);
                var lstGroupProduct = CBO<Products>.FillCollectionFromDataSet(ds);

                ViewBag.LstProduct = lstGroupProduct;
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString());
            }
            return View();
        }

        [HttpGet]
        [Route("chung-nhan-san-pham.htm")]
        public ActionResult ProductCertification()
        {
            return View();
        }


        [HttpGet]
        [Route("gioi-thieu.htm")]
        public ActionResult AboutUs()
        {
            var model = GetById(1);
            return View(model);
        }

        [HttpGet]
        [Route("chinh-sach-dai-ly.htm")]
        public ActionResult AgencyPolicy()
        {
            var model = GetById(2);
            return View(model);
        }

        [HttpGet]
        [Route("lien-he.htm")]
        public ActionResult ContactUs()
        {
            var model = GetById(3);
            return View(model);
        }

        [HttpGet]
        [Route("tuyen-dung.htm")]
        public ActionResult Recruitment()
        {
            var model = GetById(4);
            return View(model);
        }

        [HttpGet]
        [Route("cong-ty-thanh-vien.htm")]
        public ActionResult MemberCompanies()
        {
            return View();
        }

        private Page GetById(int id)
        {
            try
            {
                //var ds = _pageDa.GetById(id);
                //var page = (Page)CBO.FillObjectFromDataSet(ds, typeof(Page));
                //return page;

                Page _page = DataMemory.c_lstPage.Find(m => m.Id == id);
                return _page;
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString());
                return new Page();
            }
        }
    }
}
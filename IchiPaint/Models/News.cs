﻿using System.Collections.Generic;

namespace IchiPaint.Models
{
    public class NewsRequest
    {
        public string Title { get; set; }
        public string FeatureImage { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Tag { get; set; }
        public string CreateBy { get; set; }
        public string Special { get; set; }
        public string CategoryType { get; set; }
    }

    public class News : NewsRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CreateDate { get; set; }
    }

    public class ListNews
    {
        public List<News> Collection { get; set; }
        public int Start { get; set; }
        public string Paging { get; set; }
        public int TotalRecord { get; set; }
        public decimal TotalPage { get; set; }
        public int CurrentPage { get; set; }
    }

    public class SearchNewsRequest
    {
        public int CurrentPage { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string OrderBy { get; set; }
        public string OrderByType { get; set; }
        public string CategoryType { get; set; }
        public string CreateDate { get; set; }
    }


    public class PortalSearchNews
    {
        public int CurrentPage { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
    }

    public class PortalSearchNewsIndex: PortalSearchNews
    {
        public int Id { get; set; }
    }
}


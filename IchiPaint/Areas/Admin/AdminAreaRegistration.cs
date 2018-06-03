﻿using System.Web.Mvc;

namespace IchiPaint.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Login", id = UrlParameter.Optional }
            );

            //context.MapRoute("Admin", "quan-tri-ichi.htm", new { controller = "Admin", action = "Login" });
        }
    }
}
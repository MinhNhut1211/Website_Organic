using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebOrganicFood.Areas
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
                name: "Admin_default",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new 
                {
                    controller="Homes",
                    action = "Index",
                    id = UrlParameter.Optional,
                    namespaces = new[] { "WebOrganicFood.Areas.Admin.Controllers" } }


            );
        }
    }
}
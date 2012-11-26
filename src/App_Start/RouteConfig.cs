using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IssueTracker
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "issue/{id}/status",
                defaults: new { controller = "Issues", action = "UpdateStatus", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: null,
                url: "issue/{id}/comment",
                defaults: new { controller = "Issues", action = "Comment", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: null,
                url: "issue/{id}",
                defaults: new { controller = "Issues", action = "Detail", id = UrlParameter.Optional }
            );

            routes.MapRoute(null,
                "issues/new",
                new { controller = "Issues", action = "New"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Issues", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
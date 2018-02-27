using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TravelPackage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Sitemapxml",
                url: "Sitemap.xml",
                defaults: new { controller = "Home", action = "SitemapXml" }
                );

            routes.MapRoute(
                name: "area_Sitemapxml",
                url: "TravelPackages/{id}/{AreaName}/Sitemap.xml",
                defaults: new { controller = "Home", action = "SitemapXml" }
                );

            routes.MapRoute(
                name: "Destination",
                url: "TravelPackages/{id}/{AreaName}",
                defaults: new { controller = "Home", action = "Destination", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "TourPackages/{id}/{ProductName}",
                defaults: new { controller = "Home", action = "Product", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

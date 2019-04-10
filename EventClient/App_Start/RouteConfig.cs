using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EventClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Depences",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Depences", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "Event",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Event", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
             name: "Ticket",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Ticket", action = "Index", id = UrlParameter.Optional }
         );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BadgeScannerApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "UpdateApi",
                routeTemplate: "api/{controller}/{action}/{key1}/{val1}/{key2}/{val2}",
                defaults: new { action = RouteParameter.Optional,
                                key1 = RouteParameter.Optional, val1 = RouteParameter.Optional,
                                key2 = RouteParameter.Optional, val2 = RouteParameter.Optional,
                              }
            );
        }
    }
}

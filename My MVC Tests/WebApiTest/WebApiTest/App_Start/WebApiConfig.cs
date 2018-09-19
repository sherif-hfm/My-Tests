using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApiTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            /*
            config.Routes.MapHttpRoute(
                    name: "Api UriPathExtension",
                    routeTemplate: "api/{controller}.{extension}/{id}",
                    defaults: new { id = RouteParameter.Optional, extension = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
              name: "Api UriPathExtension ID",
              routeTemplate: "api/{controller}/{id}.{extension}",
              defaults: new { id = RouteParameter.Optional, extension = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");
            config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "text/xml");
            */
        }
    }
}

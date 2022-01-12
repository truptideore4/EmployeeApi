using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmpCrudOperation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //New
            //config.Routes.MapHttpRoute(
            //    name: "ActionBased",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            
            //New Added
            config.Filters.Add(new ValidateModelAttribute());
            config.Filters.Add(new LogCustomExceptionFilter());
        }
    }
}

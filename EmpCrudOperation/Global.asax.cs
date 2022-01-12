using BusinessLayer;
using DataAccessLayer;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EmpCrudOperation
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //New Added For filters
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //For Simple Injector DI
            var container = new Container();
            container.Register<IEmployeeDataAccesslayer, EmployeeDataAccesslayer>();
            container.Register<IEmployeeBusinessLayer, EmployeeBusinessLayer>();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);
            //For Log4Net
            //log4net.Config.XmlConfigurator.Configure();
        }
    }
}

﻿using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpCrudOperation
{
    public class SimpleInjectorDependencyResolver : System.Web.Mvc.IDependencyResolver,
           System.Web.Http.Dependencies.IDependencyResolver,
           System.Web.Http.Dependencies.IDependencyScope
    {

        public SimpleInjectorDependencyResolver(Container container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.Container = container;
        }
        public Container Container { get; private set; }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsAbstract && typeof(IController).IsAssignableFrom(serviceType))
                return this.Container.GetInstance(serviceType);
            return ((IServiceProvider)this.Container).GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            //return this.Container.GetAllInstances(serviceType);
            return GetAllInstances(serviceType);
        }
        //
        public IEnumerable<object> GetAllInstances(Type service)
        {
            IServiceProvider provider = Container;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(service);
            var services = (IEnumerable<object>)provider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }
        //

        System.Web.Http.Dependencies.IDependencyScope System.Web.Http.Dependencies.IDependencyResolver.BeginScope()
        {
            return this;
        }

        object System.Web.Http.Dependencies.IDependencyScope.GetService(Type serviceType)
        {
            return ((IServiceProvider)this.Container).GetService(serviceType);
        }

        IEnumerable<object> System.Web.Http.Dependencies.IDependencyScope.GetServices(Type serviceType)
        {
            IServiceProvider provider = Container;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var services = (IEnumerable<object>)provider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }

        void IDisposable.Dispose()
        {
        }
    }
}
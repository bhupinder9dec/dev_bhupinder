using BooksMvcApp.Infrastructure;
using BooksMvcApp.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksMvcApp.App_Start
{
    public class IocConfigurator
    {
        public static void ConfigureUnityContainer()
        {
            IUnityContainer container = new UnityContainer();
            registerServices(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void registerServices(IUnityContainer container)
        {
            container.RegisterType<IBookServices, BookServices>();
        }

    }
}
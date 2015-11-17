using System;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksMvcApp.Infrastructure
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _unityContainer;

        public UnityDependencyResolver(IUnityContainer unitycontainer)
        {
            _unityContainer = unitycontainer;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }

        }
    }
}
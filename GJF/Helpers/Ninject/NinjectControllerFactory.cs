
using Audit.Helpers.Ninject;
using GJF.Core.Ninject;
using Microsoft.AspNet.SignalR;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GJF.Helpers.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory(IKernel kernel)
        {
            _ninjectKernel = kernel;
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (controllerType == null) ? null : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            var registrator = new NinjectTypeRegistrator { Kernel = _ninjectKernel };
            new DefaultTypeRegistrator().Register(registrator);

            GlobalHost.DependencyResolver = new NinjectSignalRDependencyResolver(registrator.Kernel);
        }

        public class NinjectTypeRegistrator : ITypeRegistrator
        {
            public IKernel Kernel { get; set; }
            public void RegisterType<TTo, TFrom>() where TFrom : TTo
            {
                Kernel.Bind<TTo>().To<TFrom>();
            }
        }
    }
}
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJF.Helpers.Ninject
{
    public static class KernelFactory
    {
        public static StandardKernel Kernel { get; set; }
        public static void InitializeKernel()
        {
            Kernel = new StandardKernel();

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(Kernel));


        }
    }
}
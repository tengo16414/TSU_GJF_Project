using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Core.Ninject
{
    public interface ITypeRegistrator
    {
        IKernel Kernel { get; set; }
        void RegisterType<TTo, TFrom>() where TFrom : TTo;
    }
}

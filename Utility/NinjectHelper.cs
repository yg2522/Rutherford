using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Utility
{
    /// <summary>
    /// Helper class to allow us to statically access the ninject kernel
    /// </summary>
    public static class NinjectHelper
    {
        private static IKernel _kernel;

        public static IKernel Kernel { get { return _kernel; } }

        public static void CreateKernel()
        {
            _kernel = new StandardKernel();
        }

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
}

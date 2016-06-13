using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Utility
{
    public class NinjectHelper
    {
        private static IKernel _kernal;

        public static void LoadKernal(IKernel kernel)
        {
            _kernal = kernel;
        }

        /// <summary>
        /// Calls the Kernel's get method for bound item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return _kernal.Get<T>();
        }
    }
}

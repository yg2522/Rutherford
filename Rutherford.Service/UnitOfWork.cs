using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Rutherford.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRutherfordService RutherfordService
        {
            get
            {
                return NinjectHelper.Get<IRutherfordService>();
            }
        }

        public static IUnitOfWork Get()
        {
            return NinjectHelper.Get<IUnitOfWork>();
        }

        public void Dispose()
        {
        }
    }
}

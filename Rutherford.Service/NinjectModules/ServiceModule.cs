using Rutherford.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Rutherford.Service.NinjectModules
{
    /// <summary>
    /// module used to bind service layer interfaces to ninject
    /// </summary>
    public class ServiceModule : Ninject.Modules.NinjectModule
    {
        private string _connectionString;
        public ServiceModule(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IRepository>().To<Repository.Repository>().WithConstructorArgument("connectionString", _connectionString);
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IRutherfordService>().To<Services.RutherfordService>().WithConstructorArgument("repo", context => context.Kernel.Get<IRepository>()); ;
        }
    }
}

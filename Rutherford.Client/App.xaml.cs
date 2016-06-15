using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Utility;

namespace Rutherford.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NinjectHelper.CreateKernel();
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RutherfordEntities"].ConnectionString;
            NinjectHelper.Kernel.Load(new Rutherford.Service.NinjectModules.ServiceModule(connectionString));
            NinjectHelper.Kernel.Load(new Rutherford.Client.NinjectModules.WpfModule());
            base.OnStartup(e);
        }
    }
}

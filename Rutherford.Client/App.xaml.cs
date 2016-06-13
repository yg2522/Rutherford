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
            IKernel kernel = new StandardKernel();
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RutherfordEntities"].ConnectionString;
            kernel.Load(new Rutherford.Service.NinjectModules.ServiceModule(connectionString));
            kernel.Load(new Rutherford.Client.NinjectModules.WpfModule());
            NinjectHelper.LoadKernal(kernel);
            base.OnStartup(e);
        }
    }
}

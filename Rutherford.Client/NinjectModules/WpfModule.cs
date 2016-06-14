using Rutherford.Client.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Client.NinjectModules
{
    /// <summary>
    /// module to bind wpf layer interfaces to ninject
    /// </summary>
    public class WpfModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IFileManager>().To<FileManager>();
        }
    }
}

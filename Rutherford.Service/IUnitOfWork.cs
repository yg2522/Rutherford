using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IRutherfordService RutherfordService { get; }
    }
}

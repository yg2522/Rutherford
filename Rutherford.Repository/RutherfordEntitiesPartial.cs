using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Repository
{
    public partial class RutherfordEntities : DbContext
    {
        public RutherfordEntities(string connectionString)
            : base (connectionString)
        {
        }
    }
}

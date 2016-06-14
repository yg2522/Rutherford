using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Repository
{
    /// <summary>
    /// partial to add in another constructor to RutherfordEntities so we can pass in a connection string for a connection
    /// </summary>
    public partial class RutherfordEntities : DbContext
    {
        public RutherfordEntities(string connectionString)
            : base (connectionString)
        {
        }
    }
}

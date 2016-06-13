using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Client.Managers
{
    public interface IFileManager
    {
        void WriteFile(string filename, byte[] input);
    }
}

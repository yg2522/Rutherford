using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutherford.Client.Managers
{
    public class FileManager : IFileManager
    {
        /// <summary>
        /// writes a file to a directory given a byte array
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="input"></param>
        public void WriteFile(string filename, byte[] input)
        {
            string directories = Path.GetDirectoryName(filename);

            if (!Directory.Exists(directories))
                Directory.CreateDirectory(directories);

            File.WriteAllBytes(filename, input);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.BL
{
    public interface ILogger
    {
        string FilePath { get; set; }
        string FileName { get; set; }
        void Log(string message);
    }
}

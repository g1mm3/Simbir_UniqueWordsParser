using System;

namespace Simbir_UniqueWordsParser.Core
{
    public interface ILogger
    {
        string FilePath { get; set; }
        string FileName { get; set; }
        void Log(string message);
    }
}

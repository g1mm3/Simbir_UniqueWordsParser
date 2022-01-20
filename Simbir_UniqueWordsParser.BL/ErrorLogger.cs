using Simbir_UniqueWordsParser.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.BL
{
    public class ErrorLogger : ILogger
    {
        public string FilePath { get; set; }
        public string FileName { get; set; } = "errors.log";

        public ErrorLogger()
        {
            FilePath = AppDomain.CurrentDomain.BaseDirectory;
        }

        public void Log(string message)
        {
            using (StreamWriter w = File.AppendText(FilePath + FileName))
            {
                w.WriteLine($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] {message}");
            }
        }
    }
}

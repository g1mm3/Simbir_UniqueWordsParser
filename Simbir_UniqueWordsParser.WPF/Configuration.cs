using Simbir_UniqueWordsParser.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.WPF
{
    /// <summary>
    /// Класс, используемый для настройки зависимостей
    /// </summary>
    public static class Configuration
    {
        public static IReader GetReader()
        {
            return new HtmlReader();
        }
    }
}

using Simbir_UniqueWordsParser.BL;
using Simbir_UniqueWordsParser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public static IMessageService GetMessageService()
        {
            return new Service.MessageService();
        }

        public static ILogger GetLogger()
        {
            return new ErrorLogger();
        }
    }
}

using Simbir_UniqueWordsParser.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simbir_UniqueWordsParser.WPF.Service
{
    public class MessageService : IMessageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowExclamation(string exclamationMessage)
        {
            MessageBox.Show(exclamationMessage, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

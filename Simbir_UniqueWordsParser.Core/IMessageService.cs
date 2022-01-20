using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.Core
{
    public interface IMessageService
    {
        void ShowMessage(string message);
        void ShowExclamation(string exclamationMessage);
        void ShowError(string errorMessage);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.Core
{
    public interface IReader
    {
        Task<List<WordStat>> GetUniqueWordsStatisticsByUrl(string url);
    }
}

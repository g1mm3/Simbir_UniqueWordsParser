using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.BL
{
    public interface IReader
    {
        public Task<List<WordStat>> GetUniqueWordsStatisticsByUrl(string url);
    }
}

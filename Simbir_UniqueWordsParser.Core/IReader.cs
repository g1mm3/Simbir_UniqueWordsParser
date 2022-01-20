using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.Core
{
    public interface IReader
    {
        /// <summary>
        /// Получение статистики уникальных слов по URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<List<WordStat>> GetUniqueWordsStatisticsByUrl(string url);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.Core
{
    /// <summary>
    /// Класс, использующийся для последующего подставления в таблицу статистики в графическом интерфейсе
    /// </summary>
    public class WordStat
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }
}

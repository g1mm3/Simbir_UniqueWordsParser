using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.BL.Convert
{
    public static class BlToDb
    {
        public static DB.Models.WordStat WordStat(Core.WordStat wordStat)
        {
            DB.Models.WordStat dbWordStat = new DB.Models.WordStat
            {
                Word = wordStat.Word,
                Count = wordStat.Count
            };

            return dbWordStat;
        }

        public static List<DB.Models.WordStat> WordStatsList(List<Core.WordStat> wordStats)
        {
            List<DB.Models.WordStat> dbWordStats = new List<DB.Models.WordStat>();
            wordStats?.ForEach(x => dbWordStats.Add(BL.Convert.BlToDb.WordStat(x)));

            return dbWordStats;
        }
    }
}

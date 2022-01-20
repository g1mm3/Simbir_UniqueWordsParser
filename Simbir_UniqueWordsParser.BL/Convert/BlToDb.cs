using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.BL.Convert
{
    public static class BlToDb
    {
        public static DB.Models.WordStat WordStat(Core.WordStat blWordStat)
        {
            DB.Models.WordStat dbWordStat = new DB.Models.WordStat
            {
                Word = blWordStat.Word,
                Count = blWordStat.Count
            };

            return dbWordStat;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.BL.Convert
{
    public static class DbToBl
    {
        public static Core.WordStat WordStat(DB.Models.WordStat dbWordStat)
        {
            Core.WordStat wordStat = new Core.WordStat
            {
                Word = dbWordStat.Word,
                Count = dbWordStat.Count
            };

            return wordStat;
        }
    }
}

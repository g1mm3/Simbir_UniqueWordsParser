using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.BL.Convert
{
    public static class DbToBl
    {
        public static BL.WordStat WordStat(DB.Models.WordStat dbWordStat)
        {
            BL.WordStat blWordStat = new BL.WordStat
            {
                Word = dbWordStat.Word,
                Count = dbWordStat.Count
            };

            return blWordStat;
        }
    }
}

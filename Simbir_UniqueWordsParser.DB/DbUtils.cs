using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.DB
{
    public static class DbUtils
    {
        public static async Task AddStatsToDb(Models.Site site, List<Models.WordStat> wordStats)
        {
            using (UniqueWordsParserContext db = new UniqueWordsParserContext())
            {
                //await db.AddAsync(wordStat);
                await db.SaveChangesAsync();
            }
        }
    }
}

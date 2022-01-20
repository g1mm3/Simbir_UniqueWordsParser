using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.DB
{
    public static class DbUtils
    {
        public static async Task AddStatsToDb(string url, List<Models.WordStat> wordStats)
        {
            using (UniqueWordsParserContext db = new UniqueWordsParserContext())
            {
                Models.Site site = new Models.Site { Url = url, WordStats = wordStats };

                await db.AddAsync(site);
                await db.SaveChangesAsync();
            }
        }
    }
}

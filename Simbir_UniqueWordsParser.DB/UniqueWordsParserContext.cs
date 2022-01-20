using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.DB
{
    internal class UniqueWordsParserContext : DbContext
    {
        public DbSet<Models.WordStat> WordStats { get; set; }

        public UniqueWordsParserContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=UniqueWordsParser_DB.db");
        }
    }
}

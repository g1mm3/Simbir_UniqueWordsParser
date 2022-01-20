using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.DB.Models
{
    public class WordStat
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public int Count { get; set; }

        public int SiteId { get; set; }
        public Site Site {get;set;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.DB.Models
{
    public class Site
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public List<WordStat> WordStats { get; set; }
    }
}

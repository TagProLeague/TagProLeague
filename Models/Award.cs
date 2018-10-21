using System.Collections.Generic;

namespace TagProLeague.Models
{
    public class Award : Document
    {
        public string ImageUrl { get; set; }
        public int Place { get; set; }
        public string Type { get; set; }
        public string Season { get; set; }
        public List<string> Teams { get; set; }
        public List<string> Players { get; set; }
    }
}

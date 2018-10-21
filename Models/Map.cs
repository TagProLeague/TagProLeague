using System.Collections.Generic;

namespace TagProLeague.Models
{
    public class Map : Document
    {
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Games { get; set; }
        public List<string> Statlines { get; set; }
        public string TotalStatline { get; set; }
    }
}

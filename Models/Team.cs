using System;
using System.Collections.Generic;

namespace TagProLeague.Models
{
    public class Team : Document
    {
        public DateTime? EstablishedOn { get; set; }
        public DateTime? LastActiveOn { get; set; }
        public string LogoUrl { get; set; }
        public string FullName { get; set; }
        public string Founder { get; set; }
        public List<string> Leagues { get; set; }
        public List<string> Players { get; set; }
        public List<string> Series { get; set; }
        public List<string> Maps { get; set; }
        public List<string> Awards { get; set; }
        public List<string> Games { get; set; }
        public string TotalStatline { get; set; }
    }
}

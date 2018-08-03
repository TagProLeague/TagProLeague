using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destarwin.Models
{
    public class Season
    {
        public int Id { get; set; }
        public Enums.LeagueType LeagueType { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public League League { get; set; }
        public List<String> Teams { get; set; }
        public List<String> Players { get; set; }
    }
}

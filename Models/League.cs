using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destarwin.Models
{
    public class League
    {
        public int Id { get; set; }
        public Enums.LeagueType LeagueType { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public List<String> Seasons { get; set; }
        public List<String> Franchises { get; set; }
        public List<String> Players { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Destarwin.Models;

namespace Destarwin.Controllers
{
    [Route("api/[controller]")]
    public class LeaguesController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<League> Current()
        {
            return Enumerable.Range(1, 5).Select(index => new League
            {
                Id = index,
                LeagueType = Enums.LeagueType.StandardLeague,
                Name = "League " + index,
                CreatedOn = DateTime.UtcNow,
                Seasons = new List<String> { "1","2","3" },
                Franchises = new List<String> { "Franchise 1", "Franchise 2", "Franchise 3" },
                Players = new List<String> { "Player 1", "Player 1", "Player 1" },
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<League> HistoricalLeagues()
        {
            return Enumerable.Range(1, 5).Select(index => new League
            {
                Id = index,
                LeagueType = Enums.LeagueType.StandardLeague,
                Name = "Historical Leauge " + index,
                CreatedOn = DateTime.UtcNow,
                Seasons = new List<String> { "1", "2", "3" },
                Franchises = new List<String> { "Franchise 1", "Franchise 2", "Franchise 3" },
                Players = new List<String> { "Player 1", "Player 1", "Player 1" },
            });
        }
    }
}

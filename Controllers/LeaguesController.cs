using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagProLeague.Models;

namespace TagProLeague.Controllers
{
    [Route("api/[controller]")]
    public class LeaguesController : Controller
    {
        [HttpGet("")]
        public IEnumerable<League> GetCurrentLeagues()
        {
            return Enumerable.Range(1, 5).Select(index => new League
            {
                Id = index,
                LeagueType = Enums.LeagueType.StandardLeague,
                Name = "League " + index,
                CreatedOn = DateTime.UtcNow,
                Seasons = new List<String> { "1","2","3" },
                Teams = new List<String> { "Franchise 1", "Franchise 2", "Franchise 3" },
                Players = new List<String> { "Player 1", "Player 1", "Player 1" },
            });
        }

        [HttpGet("Historical")]
        public IEnumerable<League> GetHistoricalLeagues()
        {
            return Enumerable.Range(1, 5).Select(index => new League
            {
                Id = index,
                LeagueType = Enums.LeagueType.StandardLeague,
                Name = "Historical League " + index,
                CreatedOn = DateTime.UtcNow,
                Seasons = new List<String> { "1", "2", "3" },
                Teams = new List<String> { "Franchise 1", "Franchise 2", "Franchise 3" },
                Players = new List<String> { "Player 1", "Player 1", "Player 1" },
            });
        }

        [HttpGet("{leagueName}")]
        public League GetLeague(string leagueName)
        {
            return new League
            {
                Id = 0,
                LeagueType = Enums.LeagueType.StandardLeague,
                Name = "League " + leagueName,
                CreatedOn = DateTime.UtcNow,
                Seasons = new List<String> { "1", "2", "3" },
                Teams = new List<String> { "Team 1", "Team 2", "Team 3" },
                Players = new List<String> { "Player 1", "Player 1", "Player 1" },
            };
        }

        [HttpGet("{leagueName}/Seasons")]
        public IEnumerable<Season> GetSeasons(string leagueName, string seasonName)
        {
            return Enumerable.Range(1, 5).Select(index => new Season
            {
                Id = index,
                LeagueType = Enums.LeagueType.StandardLeague,
                CreatedOn = DateTime.UtcNow,
                League = GetLeague(leagueName),
                Teams = new List<String> { "Team 1", "Team 2", "Team 3" },
                Players = new List<String> { "Player 1", "Player 1", "Player 1" },
            });
        }

        [HttpGet("League/{leagueName}/{seasonName}")]
        public Season GetSeason(string leagueName, string seasonName)
        {
            return new Season
            {
                Id = 0,
                LeagueType = Enums.LeagueType.StandardLeague,
                Name = "Season " + seasonName,
                CreatedOn = DateTime.UtcNow,
                League = GetLeague(leagueName),
                Teams = new List<String> { "Team 1", "Team 2", "Team 3" },
                Players = new List<String> { "Player 1", "Player 1", "Player 1" },
            };
        }
    }
}

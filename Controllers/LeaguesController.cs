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
                Name = $"League {index}"
            });
        }

        [HttpGet("Historical")]
        public IEnumerable<League> GetHistoricalLeagues()
        {
            return Enumerable.Range(1, 5).Select(index => new League
            {
                Name = $"League {index}"
            });
        }

        [HttpGet("{leagueName}")]
        public League GetLeague(string leagueName)
        {
            return new League
            {
                Name = leagueName
            };
        }

        //[HttpGet("{leagueName}/Seasons")]
        //public IEnumerable<Season> GetSeasons(string leagueName, string seasonName)
        //{
        //    return Enumerable.Range(1, 5).Select(index => new Season
        //    {
        //    });
        //}

        //[HttpGet("League/{leagueName}/{seasonName}")]
        //public Season GetSeason(string leagueName, string seasonName)
        //{
        //    return new Season
        //    {
        //    };
        //}
    }
}

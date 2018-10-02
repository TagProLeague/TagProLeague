using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagProLeague.Models;
using MongoDB.Bson;

namespace TagProLeague.Controllers
{
    [Route("api/[controller]")]
    public class LeaguesController : Controller
    {
        [HttpGet("")]
        public IEnumerable<League> GetCurrentLeagues()
        {
            var leagues = new League[]
            {
                new League
                {
                    Id = "1",
                    Name = "Major League TagPro",
                    Abbreviation = "MLTP",
                    StartedOn = new DateTime(2013, 6, 23),
                    EndedOn = null,
                    Founder = new LeagueFounder
                    {
                        Id = "1",
                        Name = "Trappets"
                    },
                    Status = "S16 Postseason",
                    Seasons = new List<LeagueSeason>
                    {
                        new LeagueSeason
                        {
                            Name = "Season 16",
                            Abbreviation = "S16",
                        }
                    }
                },
                new League
                {
                    Id = "2",
                    Name = "European League TagPro",
                    Abbreviation = "ELTP",
                    StartedOn = new DateTime(2014, 1, 1),
                    EndedOn = null,
                    Founder = new LeagueFounder
                    {
                        Id = "2",
                        Name = "idk bizkut?"
                    },
                    Status = "S12 Regular Season",
                    Seasons = new List<LeagueSeason>
                    {
                        new LeagueSeason
                        {
                            Name = "Season 12",
                            Abbreviation = "S12",
                        }
                    }
                }
            };
            return leagues;
        }

        [HttpGet("Historical")]
        public IEnumerable<League> GetHistoricalLeagues()
        {
            return Enumerable.Range(1, 5).Select(index => new League
            {
                Name = $"Historical League {index}"
            });
        }

        [HttpGet("{leagueName}")]
        public League GetLeague(string leagueName)
        {
            return new League
            {
                Id = "1",
                Name = "Major League TagPro",
                Abbreviation = "MLTP",
                StartedOn = new DateTime(2013, 6, 23),
                EndedOn = null,
                Founder = new LeagueFounder
                {
                    Name = "Trappets"
                },
                Status = "S16 Postseason",
                Seasons = new List<LeagueSeason>
                    {
                        new LeagueSeason
                        {
                            Name = "Season 16",
                            Abbreviation = "S16",
                        }
                    }
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

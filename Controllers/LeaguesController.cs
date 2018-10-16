using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagProLeague.Models;
using MongoDB.Bson;
using TagProLeague.Services;

namespace TagProLeague.Controllers
{
    [Route("api/[controller]")]
    public class LeaguesController : Controller
    {
        ILeaguesRepository _leaguesRepository;

        public LeaguesController(ILeaguesRepository leaguesRepository)
        {
            _leaguesRepository = leaguesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<League>> Get()
        {
            var leagues = await _leaguesRepository.GetAllLeagues();
            return leagues;
        }

        [HttpGet("{id}")]
        public async Task<League> Get(string id)
        {
            var league = await _leaguesRepository.GetLeague(id);
            return league;
        }
    }
}

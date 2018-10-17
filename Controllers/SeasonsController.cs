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
    public class SeasonsController : Controller
    {
        ISeasonsRepository _seasonsRepository;

        public SeasonsController(ISeasonsRepository seasonsRepository)
        {
            _seasonsRepository = seasonsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Season>> Get()
        {
            var seasons = await _seasonsRepository.GetAllSeasons();
            return seasons;
        }

        [HttpGet("{id}")]
        public async Task<Season> Get([FromQuery] string id)
        {
            var season = await _seasonsRepository.GetSeasonById(id);
            return season;
        }
    }
}

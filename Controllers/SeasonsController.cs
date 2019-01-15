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
        IDocumentsRepository<League> _leaguesRepository;
        IDocumentsRepository<Season> _seasonsRepository;

        public SeasonsController(
            IDocumentsRepository<League> leaguesRepository,
            IDocumentsRepository<Season> seasonsRepository)
        {
            _leaguesRepository = leaguesRepository;
            _seasonsRepository = seasonsRepository;
        }

        [HttpGet("{leagueName}")]
        public async Task<IEnumerable<Season>> GetSeasons([FromRoute] string leagueName)
        {
            var league = await _leaguesRepository.GetDocumentByName(leagueName);
            var seasons = await _seasonsRepository.GetDocumentListByIds(league.Seasons);
            return seasons;
        }

        [HttpGet("{leagueName}/{seasonName}")]
        public async Task<Season> GetSeason([FromRoute] string leagueName, [FromRoute] string seasonName)
        {
            var seasons = await GetSeasons(leagueName);
            var season = seasons.FirstOrDefault(x => x.Name == seasonName);
            return season;
        }
    }
}

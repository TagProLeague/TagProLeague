using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagProLeague.Models;
using TagProLeague.Services;

namespace TagProLeague.Controllers
{
    [Route("api/[controller]")]
    public class LeaguesController : Controller
    {
        IDocumentsRepository<League> _leaguesRepository;

        public LeaguesController(IDocumentsRepository<League> leaguesRepository)
        {
            _leaguesRepository = leaguesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<League>> Get()
        {
            var leagues = await _leaguesRepository.GetAllDocuments();
            return leagues;
        }

        [HttpGet("{id}")]
        public async Task<League> Get([FromQuery] string id)
        {
            var league = await _leaguesRepository.GetDocumentById(id);
            return league;
        }
    }
}

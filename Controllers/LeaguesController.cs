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

        [HttpGet("{name}")]
        public async Task<League> Get([FromRoute] string name)
        {
            var league = await _leaguesRepository.GetDocumentByName(name);
            return league;
        }
    }
}

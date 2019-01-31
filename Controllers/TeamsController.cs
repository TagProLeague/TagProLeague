using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagProLeague.Models;
using TagProLeague.Services;

namespace TagProLeague.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        IDocumentsRepository<Team> _teamsRepository;

        public TeamsController(IDocumentsRepository<Team> teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Team>> Get()
        {
            var teams = await _teamsRepository.GetAllDocuments();
            return teams;
        }

        [HttpGet("{name}")]
        public async Task<Team> Get([FromRoute] string name)
        {
            var team = await _teamsRepository.GetDocumentByName(name);
            return team;
        }
    }
}
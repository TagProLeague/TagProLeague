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
        IDocumentsRepository<Season> _seasonsRepository;

        public SeasonsController(IDocumentsRepository<Season> seasonsRepository)
        {
            _seasonsRepository = seasonsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Season>> Get()
        {
            var seasons = await _seasonsRepository.GetAllDocuments();
            return seasons;
        }

        [HttpGet("{id}")]
        public async Task<Season> Get([FromQuery] string id)
        {
            var season = await _seasonsRepository.GetDocumentById(id);
            return season;
        }
    }
}

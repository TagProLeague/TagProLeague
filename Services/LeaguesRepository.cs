using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagProLeague.Models;

namespace TagProLeague.Services
{
    public interface ILeaguesRepository
    {
        Task<IEnumerable<League>> GetAllLeagues();
        Task<League> GetLeagueByName(string name);
        Task<League> GetLeagueById(string id);
        Task CreateLeague(League league);
        Task<bool> UpdateLeague(League league);
        Task<bool> DeleteLeague(string name);
    }

    public class LeaguesRepository : ILeaguesRepository
    {
        private readonly IMongoDbContext _context;

        public LeaguesRepository(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<League>> GetAllLeagues()
        {
            return await _context
                            .Leagues
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<League> GetLeagueByName(string name)
        {
            FilterDefinition<League> filter = Builders<League>.Filter.Eq(m => m.Name, name);
            return _context
                    .Leagues
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<League> GetLeagueById(string id)
        {
            FilterDefinition<League> filter = Builders<League>.Filter.Eq(m => m.Id, id);
            return _context
                    .Leagues
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task CreateLeague(League league)
        {
            await _context.Leagues.InsertOneAsync(league);
        }

        public async Task<bool> UpdateLeague(League league)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Leagues
                        .ReplaceOneAsync(
                            filter: g => g.Id == league.Id,
                            replacement: league);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteLeague(string name)
        {
            FilterDefinition<League> filter = Builders<League>.Filter.Eq(m => m.Name, name);
            DeleteResult deleteResult = await _context
                                                .Leagues
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}

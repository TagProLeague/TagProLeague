using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagProLeague.Models;

namespace TagProLeague.Services
{
    public class LeaguesRepository : ILeaguesRepository
    {
        private readonly IMongoDbContext _context;

        public LeaguesRepository(IMongoDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MongoDbLeague>> GetAllLeagues()
        {
            return await _context
                            .Leagues
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<MongoDbLeague> GetLeague(string name)
        {
            FilterDefinition<MongoDbLeague> filter = Builders<MongoDbLeague>.Filter.Eq(m => m.Name, name);
            return _context
                    .Leagues
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task CreateLeague(MongoDbLeague league)
        {
            await _context.Leagues.InsertOneAsync(league);
        }
        public async Task<bool> UpdateLeague(MongoDbLeague league)
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
            FilterDefinition<MongoDbLeague> filter = Builders<MongoDbLeague>.Filter.Eq(m => m.Name, name);
            DeleteResult deleteResult = await _context
                                                .Leagues
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}

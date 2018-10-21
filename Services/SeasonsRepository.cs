using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagProLeague.Models;

namespace TagProLeague.Services
{
    public interface ISeasonsRepository
    {
        Task<IEnumerable<Season>> GetAllSeasons();
        Task<Season> GetSeasonByName(string name);
        Task<Season> GetSeasonById(string id);
        Task CreateSeason(Season season);
        Task<bool> UpdateSeason(Season season);
        Task<bool> DeleteSeason(string name);
    }

    public class SeasonsRepository : ISeasonsRepository
    {
        private readonly IMongoDbContext _context;

        public SeasonsRepository(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Season>> GetAllSeasons()
        {
            return await _context
                            .Seasons
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Season> GetSeasonByName(string name)
        {
            FilterDefinition<Season> filter = Builders<Season>.Filter.Eq(m => m.Name, name);
            return _context
                    .Seasons
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<Season> GetSeasonById(string id)
        {
            FilterDefinition<Season> filter = Builders<Season>.Filter.Eq(m => m.Id, id);
            return _context
                    .Seasons
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task CreateSeason(Season season)
        {
            await _context.Seasons.InsertOneAsync(season);
        }

        public async Task<bool> UpdateSeason(Season season)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Seasons
                        .ReplaceOneAsync(
                            filter: g => g.Id == season.Id,
                            replacement: season);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteSeason(string name)
        {
            FilterDefinition<Season> filter = Builders<Season>.Filter.Eq(m => m.Name, name);
            DeleteResult deleteResult = await _context
                                                .Seasons
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}

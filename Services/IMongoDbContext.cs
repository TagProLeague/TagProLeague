using MongoDB.Driver;
using TagProLeague.Models;

namespace TagProLeague.Services
{
    public interface IMongoDbContext
    {
        IMongoCollection<MongoDbPlayer> Players { get; }
        IMongoCollection<MongoDbLeague> Leagues { get; }
        IMongoCollection<MongoDbSeason> Seasons { get; }
        IMongoCollection<MongoDbTeam> Teams { get; }
        IMongoCollection<MongoDbSeries> Series { get; }
        IMongoCollection<MongoDbMap> Maps { get; }
    }
}

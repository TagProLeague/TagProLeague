using MongoDB.Driver;
using TagProLeague.Models;

namespace TagProLeague.Services
{
    public interface IMongoDbContext
    {
        IMongoCollection<Player> Players { get; }
        IMongoCollection<League> Leagues { get; }
        IMongoCollection<Season> Seasons { get; }
        IMongoCollection<Team> Teams { get; }
        IMongoCollection<Series> Series { get; }
        IMongoCollection<Map> Maps { get; }
    }
}

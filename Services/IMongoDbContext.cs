using MongoDB.Driver;
using TagProLeague.Models;

namespace TagProLeague.Services
{
    public interface IMongoDbContext
    {
        IMongoCollection<Player> Players { get; }
        IMongoCollection<League> Leagues { get; }
        IMongoCollection<Season> Seasons { get; }
        IMongoCollection<Team> Team { get; }
        IMongoCollection<Series> Series { get; }
        IMongoCollection<League> Maps { get; }
    }
}

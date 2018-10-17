using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TagProLeague.Models;
using TagProLeague.Settings;

namespace TagProLeague.Services
{
    public interface IMongoDbContext
    {
        IMongoCollection<League> Leagues { get; }
        IMongoCollection<Season> Seasons { get; }
        IMongoCollection<Team> Teams { get; }
        IMongoCollection<Player> Players { get; }
        IMongoCollection<Series> Series { get; }
        IMongoCollection<SeriesFormat> SeriesFormats { get; }
        IMongoCollection<Video> Videos { get; }
        IMongoCollection<Game> Games { get; }
        IMongoCollection<GameFormat> GameFormats { get; }
        IMongoCollection<Award> Awards { get; }
        IMongoCollection<Statline> Statlines { get; }
        IMongoCollection<Map> Maps { get; }
    }

    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _db;

        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Player> Players => _db.GetCollection<Player>("Players");
        public IMongoCollection<League> Leagues => _db.GetCollection<League>("Leagues");
        public IMongoCollection<Season> Seasons => _db.GetCollection<Season>("Seasons");
        public IMongoCollection<Team> Teams => _db.GetCollection<Team>("Teams");
        public IMongoCollection<Series> Series => _db.GetCollection<Series>("Series");
        public IMongoCollection<SeriesFormat> SeriesFormats => _db.GetCollection<SeriesFormat>("SeriesFormat");
        public IMongoCollection<Video> Videos => _db.GetCollection<Video>("Video");
        public IMongoCollection<Game> Games => _db.GetCollection<Game>("Game");
        public IMongoCollection<GameFormat> GameFormats => _db.GetCollection<GameFormat>("GameFormat");
        public IMongoCollection<Award> Awards => _db.GetCollection<Award>("Award");
        public IMongoCollection<Statline> Statlines => _db.GetCollection<Statline>("Statline");
        public IMongoCollection<Map> Maps => _db.GetCollection<Map>("Maps");
    }
}

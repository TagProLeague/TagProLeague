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
        IMongoCollection<T> Collection<T>();
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

        public IMongoCollection<T> Collection<T>()
        {
            if (typeof(T) == typeof(Player)) return Players as IMongoCollection<T>;
            if (typeof(T) == typeof(League)) return Leagues as IMongoCollection<T>;
            if (typeof(T) == typeof(Season)) return Seasons as IMongoCollection<T>;
            if (typeof(T) == typeof(Team)) return Teams as IMongoCollection<T>;
            if (typeof(T) == typeof(Series)) return Series as IMongoCollection<T>;
            if (typeof(T) == typeof(SeriesFormat)) return SeriesFormats as IMongoCollection<T>;
            if (typeof(T) == typeof(Video)) return Videos as IMongoCollection<T>;
            if (typeof(T) == typeof(Game)) return Games as IMongoCollection<T>;
            if (typeof(T) == typeof(GameFormat)) return GameFormats as IMongoCollection<T>;
            if (typeof(T) == typeof(Award)) return Awards as IMongoCollection<T>;
            if (typeof(T) == typeof(Statline)) return Statlines as IMongoCollection<T>;
            if (typeof(T) == typeof(Map)) return Maps as IMongoCollection<T>;
            return null;
        }
    }
}

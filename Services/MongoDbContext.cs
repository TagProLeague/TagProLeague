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

        public IMongoCollection<Player> Players => _db.GetCollection<Player>("players");
        public IMongoCollection<League> Leagues => _db.GetCollection<League>("leagues");
        public IMongoCollection<Season> Seasons => _db.GetCollection<Season>("seasons");
        public IMongoCollection<Team> Teams => _db.GetCollection<Team>("teams");
        public IMongoCollection<Series> Series => _db.GetCollection<Series>("series");
        public IMongoCollection<SeriesFormat> SeriesFormats => _db.GetCollection<SeriesFormat>("seriesFormat");
        public IMongoCollection<Video> Videos => _db.GetCollection<Video>("video");
        public IMongoCollection<Game> Games => _db.GetCollection<Game>("game");
        public IMongoCollection<GameFormat> GameFormats => _db.GetCollection<GameFormat>("gameFormat");
        public IMongoCollection<Award> Awards => _db.GetCollection<Award>("award");
        public IMongoCollection<Statline> Statlines => _db.GetCollection<Statline>("statline");
        public IMongoCollection<Map> Maps => _db.GetCollection<Map>("maps");

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

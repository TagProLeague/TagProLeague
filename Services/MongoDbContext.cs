using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TagProLeague.Models;
using TagProLeague.Settings;

namespace TagProLeague.Services
{
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
        public IMongoCollection<Map> Maps => _db.GetCollection<Map>("Maps");
    }
}

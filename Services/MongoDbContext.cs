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

        public IMongoCollection<MongoDbPlayer> Players => _db.GetCollection<MongoDbPlayer>("Players");
        public IMongoCollection<MongoDbLeague> Leagues => _db.GetCollection<MongoDbLeague>("Leagues");
        public IMongoCollection<MongoDbSeason> Seasons => _db.GetCollection<MongoDbSeason>("Seasons");
        public IMongoCollection<MongoDbTeam> Teams => _db.GetCollection<MongoDbTeam>("Teams");
        public IMongoCollection<MongoDbSeries> Series => _db.GetCollection<MongoDbSeries>("Series");
        public IMongoCollection<MongoDbMap> Maps => _db.GetCollection<MongoDbMap>("Maps");
    }
}

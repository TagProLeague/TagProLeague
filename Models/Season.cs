using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TagProLeague.Models
{
    public class Season
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TagProLeague.Models
{
    public class Player
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}

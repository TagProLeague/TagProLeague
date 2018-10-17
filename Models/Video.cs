using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TagProLeague.Models
{
    public class Video
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string TwitchUrl { get; set; }
        public string YouTubeUrl { get; set; }
        public string Streamer { get; set; }
        public string Series { get; set; }
    }
}

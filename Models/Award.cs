using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace TagProLeague.Models
{
    public class Award
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Place { get; set; }
        public string Type { get; set; }
        public string Season { get; set; }
        public List<string> Teams { get; set; }
        public List<string> Players { get; set; }
    }
}

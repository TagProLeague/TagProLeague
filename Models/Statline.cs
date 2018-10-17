using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace TagProLeague.Models
{
    public class Statline
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Score { get; set; }
        public int Tags { get; set; }
        public int Grabs { get; set; }
        public int Hold { get; set; }
        public int Captures { get; set; }
        public int Prevent { get; set; }
        public int Returns { get; set; }
        public int Support { get; set; }
        public int PowerUps { get; set; }
        public int Pops { get; set; }
        public int Drops { get; set; }
        public string Game { get; set; }
        public string Player { get; set; }
    }
}

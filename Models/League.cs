using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace TagProLeague.Models
{
    public class League
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public DateTimeOffset? StartedOn { get; set; }
        public DateTimeOffset? EndedOn { get; set; }
        public string Status { get; set; }
        public string Founder { get; set; }
        public List<string> Seasons { get; set; }
        public List<string> Teams { get; set; }
        public List<string> Players { get; set; }
        public List<string> Games { get; set; }
        public string TotalStatline { get; set; }
    }
}

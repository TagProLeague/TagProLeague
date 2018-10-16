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
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public DateTimeOffset? StartedOn { get; set; }
        public DateTimeOffset? EndedOn { get; set; }
        public string Status { get; set; }
        public MongoDBRef Founder { get; set; }
        public IEnumerable<MongoDBRef> Seasons { get; set; }
        public IEnumerable<MongoDBRef> Teams { get; set; }
        public IEnumerable<MongoDBRef> Players { get; set; }
        public IEnumerable<MongoDBRef> Games { get; set; }
        public MongoDBRef TotalStatline { get; set; }
    }
}

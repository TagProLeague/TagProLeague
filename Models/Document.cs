using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TagProLeague.Models
{
    public class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

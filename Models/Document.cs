using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TagProLeague.Models
{
    public interface IDocument
    {
        string Id { get; set; }
        string Name { get; set; }
    }

    public class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
        string Name { get; set; }
    }
}

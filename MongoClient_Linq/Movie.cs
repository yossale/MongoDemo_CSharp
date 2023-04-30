using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements] // When deserializing, ignore fields that weren't specified here
public class Movie {

    [BsonId] // "This is the ID field"
    [BsonRepresentation(BsonType.ObjectId)] // "It should be represented as Mongo object Id"
    public string Id { get; set; }

    [BsonElement("title")]
    public string Title { get; set; } = null!;

    [BsonElement("year")]
    public int Year { get; set; }

    [BsonElement("runtime")]
    public int Runtime { get; set; }

    [BsonElement("plot")]
    [BsonIgnoreIfNull]
    public string Plot { get; set; } = null!;

    [BsonElement("cast")]
    [BsonIgnoreIfNull] // "When serializing, don't output if it's null. On deserializing, it will be null"
    public List<string> Cast { get; set; } = null!;

}
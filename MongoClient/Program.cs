using System;
using MongoDB.Driver;
using MongoDB.Bson;

var connectionString = Environment.GetEnvironmentVariable("ATLAS_URI");

var client = new MongoClient(connectionString);

var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");

// Find movie by title

var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");

var document = collection.Find(filter).First();

Console.WriteLine(document);

// Michael Keaton movies in the 80's:

filter = Builders<BsonDocument>.Filter.And(
    Builders<BsonDocument>.Filter.Gte("year", 1985),
    Builders<BsonDocument>.Filter.Lte("year", 1990),
    Builders<BsonDocument>.Filter.AnyIn("cast", new BsonArray { "Michael Keaton" })
);

Console.WriteLine("\nMichael Keaton movies in the 80's:");
var cursor = collection.Find(filter).ToCursor();
while (cursor.MoveNext())
{
    foreach (var doc in cursor.Current)
    {
        Console.WriteLine("Title: {0}, Year: {1}", doc["title"], doc["year"]);
    }
}

// Ryan Reynolds Screen time

Console.WriteLine("\n Ryan Reynolds Screen time");

var pipeline = new BsonDocument[]
{
    new BsonDocument("$match", new BsonDocument("cast", "Ryan Reynolds")),    
    new BsonDocument("$group", new BsonDocument("_id", "Ryan Reynolds")
        .Add("totalRuntime", new BsonDocument("$sum", "$runtime")))
};

var result = collection.Aggregate<BsonDocument>(pipeline).FirstOrDefault();

if (result != null) {
    var totalRuntime = result.GetValue("totalRuntime", new BsonInt32(0));
    Console.WriteLine("Total runtime of movies with Ryan Reynolds: {0}", totalRuntime);
}
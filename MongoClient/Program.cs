using System;
using MongoDB.Driver;
using MongoDB.Bson;

var user = Environment.GetEnvironmentVariable("MFLIX_DEMO_USER");
var pass = Environment.GetEnvironmentVariable("MFLIX_DEMO_PASS");

var connectionString = $"mongodb+srv://{user}:{pass}@playground.rdtfg.mongodb.net/?retryWrites=true&w=majority";

var client = new MongoClient(connectionString);

var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");

var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");

var document = collection.Find(filter).First();

Console.WriteLine(document);

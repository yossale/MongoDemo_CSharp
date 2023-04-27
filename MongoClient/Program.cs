using System;
using MongoDB.Driver;
using MongoDB.Bson;

var connectionString = Environment.GetEnvironmentVariable("ATLAS_URI");

var client = new MongoClient(connectionString);

var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");

var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");

var document = collection.Find(filter).First();

Console.WriteLine(document);

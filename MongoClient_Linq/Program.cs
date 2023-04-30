using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Text.Json;

MongoClientSettings settings = MongoClientSettings.FromConnectionString(
    Environment.GetEnvironmentVariable("ATLAS_URI")
);

settings.LinqProvider = LinqProvider.V3;

MongoClient client = new MongoClient(settings);

IMongoCollection<Movie> moviesCollection = client.GetDatabase("sample_mflix").GetCollection<Movie>("movies");

Console.WriteLine("Back to the future!");
IMongoQueryable<Movie> backToFuture =
            from movie in moviesCollection.AsQueryable()
            where movie.Title == "Back to the Future"
            select movie;

var entry = backToFuture.FirstOrDefault();
string strJson = JsonSerializer.Serialize<Object>(entry);
Console.WriteLine(strJson);

Console.WriteLine("\nMichael Keaton movies in the 80's:");

IMongoQueryable<Movie> michaelKeatonMovies =
            from movie in moviesCollection.AsQueryable()
            where movie.Year >= 1985 && movie.Year < 1990
            where movie.Cast.Contains("Michael Keaton")
            select movie;

foreach(Movie film in michaelKeatonMovies) {
    Console.WriteLine("{0}: {1}", film.Title, film.Year);
}


var ryanReynTimeOnScreen = 
            from movie in moviesCollection.AsQueryable()
            where movie.Cast.Contains("Ryan Reynolds") from cast in movie.Cast            
            where cast == "Ryan Reynolds"
            group movie by cast into g
            select new { Cast = g.Key, Sum = g.Sum(x => x.Runtime) };

foreach(var result in ryanReynTimeOnScreen) {
    Console.WriteLine("\n{0} appeared on screen for {1} minutes!", result.Cast, result.Sum);
}


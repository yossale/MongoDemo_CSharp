using MongoDB.Driver;
using MongoDB.Driver.Linq;

MongoClientSettings settings = MongoClientSettings.FromConnectionString(
    Environment.GetEnvironmentVariable("ATLAS_URI")
);

settings.LinqProvider = LinqProvider.V3;

MongoClient client = new MongoClient(settings);

IMongoCollection<Movie> moviesCollection = client.GetDatabase("sample_mflix").GetCollection<Movie>("movies");

IMongoQueryable<Movie> michaelKeatonMovies =
            from movie in moviesCollection.AsQueryable()
            where movie.Year >= 1985 && movie.Year < 1990
            where movie.Cast.Contains("Michael Keaton")
            select movie;

Console.WriteLine("Michael Keaton movies in the 80's:");
foreach(Movie film in michaelKeatonMovies) {
    Console.WriteLine("{0}: {1}", film.Title, film.Year);
}

Console.WriteLine("");
var ryanReynTimeOnScreen = 
            from movie in moviesCollection.AsQueryable()
            where movie.Cast.Contains("Ryan Reynolds")
            from cast in movie.Cast
            where cast == "Ryan Reynolds"
            group movie by cast into g
            select new { Cast = g.Key, Sum = g.Sum(x => x.Runtime) };

foreach(var result in ryanReynTimeOnScreen) {
    Console.WriteLine("{0} appeared on screen for {1} minutes!", result.Cast, result.Sum);
}
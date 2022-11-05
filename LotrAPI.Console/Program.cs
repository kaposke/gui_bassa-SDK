using LotrAPI.SDK;
using LotrAPI.SDK.Options;
using LotrAPI.SDK.Options.Filters;

var client = new LotrClient("-qPsGZOoXUn89qgfoRaC");

var movies = await client.GetMovies();
Console.WriteLine(movies);
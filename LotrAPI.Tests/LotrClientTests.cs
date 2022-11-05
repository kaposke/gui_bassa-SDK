using LotrAPI.SDK;
using LotrAPI.SDK.Options;
using LotrAPI.SDK.Options.Filters;
using Microsoft.Extensions.Configuration;

namespace LotrAPI.Tests;

public class LotrClientTests
{
    private readonly string apiKey = "-qPsGZOoXUn89qgfoRaC";

    [Fact]
    public async Task should_getBooks()
    {
        var client = new LotrClient(apiKey);

        var books = await client.GetBooks();

        Assert.NotEmpty(books);
    }

    [Theory]
    [InlineData("5cf58077b53e011a64671583", "The Two Towers")]
    [InlineData("5cf58080b53e011a64671584", "The Return Of The King")]
    public async Task should_getSpecificBook_whenCallingGetBook(string id, string? expectedName)
    {
        var client = new LotrClient(apiKey);

        var book = await client.GetBook(id);

        Assert.Equal(book.Name, expectedName);
    }

    [Fact]
    public async Task should_getMovies()
    {
        var client = new LotrClient(apiKey);

        var movies = await client.GetMovies();

        Assert.NotEmpty(movies);
    }

    [Theory]
    [InlineData("5cd95395de30eff6ebccde56", "The Lord of the Rings Series")]
    [InlineData("5cd95395de30eff6ebccde5c", "The Fellowship of the Ring")]
    public async Task should_getSpecificMovie_whenCallingGetMovie(string id, string? expectedName)
    {
        var client = new LotrClient(apiKey);

        var movie = await client.GetMovie(id);

        Assert.Equal(movie.Name, expectedName);
    }

    [Fact]
    public async Task should_getCharacters()
    {
        var client = new LotrClient(apiKey);

        var characters = await client.GetCharacters();

        Assert.NotEmpty(characters);
    }

    [Theory]
    [InlineData("5cd99d4bde30eff6ebccfc3d", "Bob")]
    [InlineData("5cd99d4bde30eff6ebccfc38", "Bilbo Baggins")]
    public async Task should_getSpecificCharacter_whenCallingGetCharacter(string id, string? expectedName)
    {
        var client = new LotrClient(apiKey);

        var character = await client.GetCharacter(id);

        Assert.Equal(character.Name, expectedName);
    }

    [Fact]
    public async Task should_getQuotes()
    {
        var client = new LotrClient(apiKey);

        var quotes = await client.GetQuotes();

        Assert.NotEmpty(quotes);
    }

    [Theory]
    [InlineData("5cd96e05de30eff6ebcceb7c", "You stink of horse.The Man......was he from Gondor?")]
    [InlineData("5cd96e05de30eff6ebcce982", "Yes, I wish that.")]
    public async Task should_getSpecificQuote_whenCallingGetQuote(string id, string? expectedDialog)
    {
        var client = new LotrClient(apiKey);

        var quote = await client.GetQuote(id);

        Assert.Equal(quote.Dialog, expectedDialog);
    }

    [Fact]
    public async Task should_getChapter()
    {
        var client = new LotrClient(apiKey);

        var chapters = await client.GetChapters();

        Assert.NotEmpty(chapters);
    }

    [Theory]
    [InlineData("6091b6d6d58360f988133b8d", "Three is Company")]
    [InlineData("6091b6d6d58360f988133bc8", "The Grey Havens")]
    public async Task should_getSpecificChapter_whenCallingGetChapter(string id, string? expectedName)
    {
        var client = new LotrClient(apiKey);

        var chapter = await client.GetChapter(id);

        Assert.Equal(chapter.ChapterName, expectedName);
    }

    [Theory]
    [InlineData(400, 2)]
    [InlineData(200, 3)]
    [InlineData(100, 8)]
    public async Task should_getOnlyMoviesGreaterRuntimeInMinutes_whenUsingGreaterThanComparisonFilterForRuntimeInMinutes(int greaterThan, int expectedLength)
    {
        var client = new LotrClient(apiKey);

        var options = new LotrRequestOptions
        {
            Filters = new() {
                new FilterOperatorComparison<int>("runtimeInMinutes", ComparisonOperator.GREATER_THAN, greaterThan)
            }
        };

        var movies = await client.GetMovies(options);

        Assert.Equal(movies.Length, expectedLength);
    }

    [Fact]
    public async Task should_onlyGetHobbitsAndHumansFromCharacters_whenFilteringHobbitsAndHumans()
    {
        var client = new LotrClient(apiKey);

        var races = new string[] { "Hobbit", "Human" };

        var options = new LotrRequestOptions
        {
            Filters = new() {
                new FilterInclude("race", races)
            }
        };

        var characters = await client.GetCharacters(options);

        Assert.All(characters, c => races.Contains(c.Race));
    }
}
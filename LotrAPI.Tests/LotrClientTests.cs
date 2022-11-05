using LotrAPI.SDK;
using LotrAPI.SDK.Options;
using LotrAPI.SDK.Options.Filters;
using Microsoft.Extensions.Configuration;

namespace LotrAPI.Tests;

public class LotrClientTests
{
    private readonly string apiKey = "-qPsGZOoXUn89qgfoRaC";

    [Fact]
    public async Task should_getThreeBooks()
    {
        var client = new LotrClient(apiKey);

        var books = await client.GetBooks();

        Assert.Equal(books.Length, 3);
    }

    [Fact]
    public async Task should_getTheTwoTowersFirst_whenSortingByNameAscending()
    {
        var client = new LotrClient(apiKey);

        var options = new LotrRequestOptions
        {
            Sorting = new SortingOptions("name", SortingDirection.DESC),
        };

        var books = await client.GetBooks(options);

        Assert.Equal(books[0].Name, "The Two Towers");
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
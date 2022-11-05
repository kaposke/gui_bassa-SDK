using RestSharp;
using RestSharp.Authenticators;

using LotrAPI.SDK.Common;
using LotrAPI.SDK.Options;
using LotrAPI.SDK.Models;
using LotrAPI.SDK.Extension;

namespace LotrAPI.SDK;

public class LotrClient : ILotrClient, IDisposable
{
    private readonly RestClient _client;

    public LotrClient(string apiKey)
    {
        var options = new RestClientOptions("https://the-one-api.dev/v2");

        _client = new RestClient(options)
        {
            Authenticator = new JwtAuthenticator(apiKey),
        };
    }

    public async Task<Book[]> GetBooks(LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/book");
        if (options is not null)
            request.AddOptions(options);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Book>>(request);

        return paginatedResponse.Docs;
    }

    public async Task<Book> GetBook(string id)
    {
        var request = new RestRequest("/book/{id}");
        request.AddUrlSegment("id", id);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Book>>(request);

        return paginatedResponse.Docs is not null ? paginatedResponse.Docs[0] : null;
    }

    public async Task<Chapter[]> GetChapters(LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/chapter");
        if (options is not null)
            request.AddOptions(options);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Chapter>>(request);

        return paginatedResponse.Docs;
    }

    public async Task<Chapter> GetChapter(string id)
    {
        var request = new RestRequest("/chapter/{id}");
        request.AddUrlSegment("id", id);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Chapter>>(request);

        return paginatedResponse.Docs is not null ? paginatedResponse.Docs[0] : null;
    }

    public async Task<Chapter[]> GetChaptersFromBook(string bookId, LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/book/{id}/chapter");
        request.AddUrlSegment("id", bookId);
        if (options is not null)
            request.AddOptions(options);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Chapter>>(request);

        return paginatedResponse.Docs;
    }

    public async Task<Character[]> GetCharacters(LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/character");
        if (options is not null)
            request.AddOptions(options);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Character>>(request);

        return paginatedResponse.Docs;
    }

    public async Task<Character> GetCharacter(string id)
    {
        var request = new RestRequest("/character/{id}");
        request.AddUrlSegment("id", id);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Character>>(request);

        return paginatedResponse.Docs is not null ? paginatedResponse.Docs[0] : null;
    }

    public async Task<Movie[]> GetMovies(LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/movie");
        if (options is not null)
            request.AddOptions(options);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Movie>>(request);

        return paginatedResponse.Docs;
    }

    public async Task<Movie> GetMovie(string id)
    {
        var request = new RestRequest("/movie/{id}");
        request.AddUrlSegment("id", id);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Movie>>(request);

        return paginatedResponse.Docs is not null ? paginatedResponse.Docs[0] : null;
    }

    public async Task<Quote[]> GetQuotes(LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/quote");
        if (options is not null)
            request.AddOptions(options);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Quote>>(request);

        return paginatedResponse.Docs;
    }

    public async Task<Quote> GetQuote(string id)
    {
        var request = new RestRequest("/quote/{id}");
        request.AddUrlSegment("id", id);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Quote>>(request);

        return paginatedResponse.Docs is not null ? paginatedResponse.Docs[0] : null;
    }

    public async Task<Quote[]> GetQuotesFromMovie(string movieId, LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/movie/{id}/quote");
        request.AddUrlSegment("id", movieId);
        if (options is not null)
            request.AddOptions(options);

        var paginatedResponse = await _client.GetAsync<PaginatedResponse<Quote>>(request);

        return paginatedResponse.Docs;
    }

    public void Dispose()
    {
        _client?.Dispose();
    }
}
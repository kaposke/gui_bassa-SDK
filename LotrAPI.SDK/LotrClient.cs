using RestSharp;
using RestSharp.Authenticators;

using LotrAPI.SDK.Common;
using LotrAPI.SDK.Options;
using LotrAPI.SDK.Models;
using LotrAPI.SDK.Extension;
using LotrAPI.SDK.Exceptions;

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

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Book>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedBooks = response.Data;

        return paginatedBooks.Docs;
    }

    public async Task<Book> GetBook(string id)
    {
        var request = new RestRequest("/book/{id}");
        request.AddUrlSegment("id", id);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Book>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedBooks = response.Data;

        return paginatedBooks.Docs is not null && paginatedBooks.Docs.Length > 0 ? paginatedBooks.Docs[0] : null;
    }

    public async Task<Chapter[]> GetChapters(LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/chapter");
        if (options is not null)
            request.AddOptions(options);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Chapter>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedChapters = response.Data;

        return paginatedChapters.Docs;
    }

    public async Task<Chapter> GetChapter(string id)
    {
        var request = new RestRequest("/chapter/{id}");
        request.AddUrlSegment("id", id);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Chapter>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedChapters = response.Data;

        return paginatedChapters.Docs is not null && paginatedChapters.Docs.Length > 0 ? paginatedChapters.Docs[0] : null;
    }

    public async Task<Chapter[]> GetChaptersFromBook(string bookId, LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/book/{id}/chapter");
        request.AddUrlSegment("id", bookId);
        if (options is not null)
            request.AddOptions(options);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Chapter>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedChapters = response.Data;

        return paginatedChapters.Docs;
    }

    public async Task<Character[]> GetCharacters(LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/character");
        if (options is not null)
            request.AddOptions(options);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Character>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedCharacters = response.Data;

        return paginatedCharacters.Docs;
    }

    public async Task<Character> GetCharacter(string id)
    {
        var request = new RestRequest("/character/{id}");
        request.AddUrlSegment("id", id);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Character>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedCharacters = response.Data;

        return paginatedCharacters.Docs is not null && paginatedCharacters.Docs.Length > 0 ? paginatedCharacters.Docs[0] : null;
    }

    public async Task<Movie[]> GetMovies(LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/movie");
        if (options is not null)
            request.AddOptions(options);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Movie>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedMovies = response.Data;

        return paginatedMovies.Docs;
    }

    public async Task<Movie> GetMovie(string id)
    {
        var request = new RestRequest("/movie/{id}");
        request.AddUrlSegment("id", id);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Movie>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedMovies = response.Data;

        return paginatedMovies.Docs is not null && paginatedMovies.Docs.Length > 0 ? paginatedMovies.Docs[0] : null;
    }

    public async Task<Quote[]> GetQuotes(LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/quote");
        if (options is not null)
            request.AddOptions(options);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Quote>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedQuotes = response.Data;

        return paginatedQuotes.Docs;
    }

    public async Task<Quote> GetQuote(string id)
    {
        var request = new RestRequest("/quote/{id}");
        request.AddUrlSegment("id", id);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Quote>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedQuotes = response.Data;

        return paginatedQuotes.Docs is not null && paginatedQuotes.Docs.Length > 0 ? paginatedQuotes.Docs[0] : null;
    }

    public async Task<Quote[]> GetQuotesFromMovie(string movieId, LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/movie/{id}/quote");
        request.AddUrlSegment("id", movieId);
        if (options is not null)
            request.AddOptions(options);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Quote>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedQuotes = response.Data;

        return paginatedQuotes.Docs;
    }

    public async Task<Quote[]> GetQuotesFromCharacter(string characterId, LotrRequestOptions? options = null)
    {
        var request = new RestRequest("/character/{id}/quote");
        request.AddUrlSegment("id", characterId);
        if (options is not null)
            request.AddOptions(options);

        var response = await _client.ExecuteGetAsync<PaginatedResponse<Quote>>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new LotrApiResponseException(response.StatusCode, response.StatusDescription);
        }

        var paginatedQuotes = response.Data;

        return paginatedQuotes.Docs;
    }

    public void Dispose()
    {
        _client?.Dispose();
    }
}
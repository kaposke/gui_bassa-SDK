
using LotrAPI.SDK.Options;
using LotrAPI.SDK.Models;

namespace LotrAPI.SDK;

public interface ILotrClient
{
    Task<Book[]> GetBooks(LotrRequestOptions? options);
    Task<Book> GetBook(string id);
    Task<Movie[]> GetMovies(LotrRequestOptions? options);
    Task<Movie> GetMovie(string id);
    Task<Character[]> GetCharacters(LotrRequestOptions? options);
    Task<Character> GetCharacter(string id);
    Task<Quote[]> GetQuotes(LotrRequestOptions? options);
    Task<Quote> GetQuote(string id);
    Task<Quote[]> GetQuotesFromMovie(string movieId, LotrRequestOptions? options);
    Task<Chapter[]> GetChapters(LotrRequestOptions? options);
    Task<Chapter> GetChapter(string id);
    Task<Chapter[]> GetChaptersFromBook(string bookId, LotrRequestOptions? options);
}
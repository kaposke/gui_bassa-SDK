
using LotrAPI.SDK.Models;

namespace LotrAPI.SDK;

public interface ILotrClient
{
    Task<Book[]> GetBooks();
    Task<Book> GetBook(string id);
    Task<Movie[]> GetMovies();
    Task<Movie> GetMovie(string id);
    Task<Character[]> GetCharacters();
    Task<Character> GetCharacter(string id);
    Task<Quote[]> GetQuotes();
    Task<Quote> GetQuote(string id);
    Task<Quote[]> GetQuotesFromMovie(string movieId);
    Task<Chapter[]> GetChapters();
    Task<Chapter> GetChapter(string id);
    Task<Chapter> GetChaptersFromBook(string bookId);
}
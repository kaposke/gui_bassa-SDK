## The SDK design
### Client
The Lord of the Rings API is a small API, with not many endpoints, so I went for a simple design (which also doesn't give me much to talk about). All requests are 
contained within a single client, but if the SDK was bigger, I would probably start considering splitting it up into resources.
Here's what the client interface looks like:
```csharp
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
  Task<Quote[]> GetQuotesFromCharacter(string characterId, LotrRequestOptions? options);
  Task<Chapter[]> GetChapters(LotrRequestOptions? options);
  Task<Chapter> GetChapter(string id);
  Task<Chapter[]> GetChaptersFromBook(string bookId, LotrRequestOptions? options);
}
```

### Options
There are many ways of dealing with options. The approach I chose was inspired on how Microsoft libraries do it, which is via Option objects. I initially started
building option builders, but realized it was overkill for this case (there aren't that many option variations). My main goal was to mantain a good developer-experience, 
and I think this approach does a good job with it:
```csharp
var client = new LotrClient(apiKey);
var options = new LotrRequestOptions
{
    Sorting = new SortingOptions("name") // <- Magic string
};

var characters = await client.GetCharacters(options);
```
### The Magic strings flaw
The biggest flaw I left behind are the magic strings. I made sure my models followed the C# conventions, so they all use PascalCase. But the JSON api expects camelCase,
so when providing these magic strings, there is a weird developer experience, not to mention the room for human error. Also, I changed the name of some fields 
like "movie" in Quotes, to "movieId". I didn't tackle the problem due to time limits, but a couple approaches to this come to my mind, if I was to spend the time on it:
- Somehow use the `JsonPropertyName` property that are in present in every model to describe how to convert from JSON to object, to figure out what the name of each field
  would be in the original json and use that, aiming for this usage model:
  ```csharp
  // Super imaginative idea, not sure if its possible to do something similar
  new SortingOptions(nameof(Character.Name));
  ```
- Just have constants or enums for everything. (also not a fan)

### Filters
For filters, I created an `IFilter` interface, and a few Filter implementations. The main reason is that they affect the query string differently. So the IFilter interface
has a getter called `AsQueryString` that the filters need to implement in their own way.

Example:
```csharp
public interface IFilter
{
  public string FieldName { get; set; }
  public string AsQueryParam { get; }
}

// One filter implementation
public class FilterOperatorComparison<T> : IFilter
{
  public string FieldName { get; set; }
  public ComparisonOperator ComparisonOperator { get; set; }
  public T Value { get; set; }
  public string AsQueryParam => $"{FieldName}{OperatorAsString}{Value}"; // Uses custom operators

  public FilterOperatorComparison(string fieldName, ComparisonOperator comparisonOperator, T value)
  {
    FieldName = fieldName;
    ComparisonOperator = comparisonOperator;
    Value = value;
  }

  private string OperatorAsString => ComparisonOperator switch
  {
    ComparisonOperator.EQUALS => "=",
    ComparisonOperator.NOT_EQUALS => "!=",
    ComparisonOperator.LESS_THAN => "<",
    ComparisonOperator.GREATER_THAN => ">",
    ComparisonOperator.LESS_THEN_EQUALS => "<=",
    ComparisonOperator.GREATER_THAN_EQUALS => ">=",
  };
}

// Another filter implementation
public class FilterInclude : IFilter
{
  public string FieldName { get; set; }
  public string[] Values { get; set; }
  public string AsQueryParam => $"{FieldName}={string.Join(",", Values)}"; // Creates a comma-separated list

  public FilterInclude(string fieldName, string[] values)
  {
    FieldName = fieldName;
    Values = values;
  }
}
```


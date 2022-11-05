## The Lord of the Rings API SDK for .NET
The go-to .NET SDK for The Lord of the Rings API :P

## Instalation
```bash
dotnet add package GuiBassa.11.05.22.001.LotrSDK --version 1.0.0
```

## Usage
Initialize the client:
```csharp
using LotrSDK;
var client = new LotrClient("my-apy-key");
```
> You can get your own API key by registering in the official api [website](https://the-one-api.dev/).

Start making requests!
```csharp
// Get all movies
var movies = await client.GetMovies();

// Get single book
var book = await client.GetBook("book-id");
```

## Pagination, sorting and filtering
Every request for multiple results (GetMovies, GetCharacters, GetBooks, etc.) accepts a `LotrRequestOptions` as a parameter. You can use this option object to customize your request.


### Pagination
```csharp
var options = new LotrRequestOptions
{
  Pagination = new PaginationOptions()
  {
    Page = 3,
    Limit = 15
  }
};

var characters = await client.GetCharacters(options);
```


### Sorting
```csharp
var options = new LotrRequestOptions
{
  Sorting = new SortingOptions("name", SortingDirection.DESC)
};

var quotes = await client.GetQuotes(options);
```

### Filtering
```csharp
var options = new LotrRequestOptions
{
  Filters = new ()
  {
    new FilterOperatorComparison<int>("runtimeInMinutes", ComparisonOperator.GREATER_THAN, 200),
    // you can add more!
  }
};

var movies = await client.GetMovies(options);
```

These are the available filter types:
- `FilterOperatorComparison` - For simple operation comparisons (`==`, `!=`, `>=`, `<`, etc.)
- `FilterInclude` - For values that match any value in a list. Eg:

  ```csharp
    new FilterInclude("race", new string[] { "Human", "Hobbit" });
  ```
- `FilterExclude` - For values that are not contained in a list.
- `FilterExists` - Filter options where a field exists.
- `FilterNotExists` - Filter options where a field does not exist.

### Combining options
You can also combine filtering, sorting and pagination into the same request:
```csharp
var options = new LotrRequestOptions
{
  Pagination = new PaginationOptions{ Limit = 15, Page = 2 },
  Sorting = new SortingOptions("budgetInMillions", SortingDirection.ASC),
  Filters = new () 
  {
    new FilterOperatorComparison<int>("rottenTomatoesScore", ComparisonOperator.GREATER_THAN_EQUAL, 80)
  }
};

var movies = await client.GetMovies(options);
```

## Testing
Clone the repo:
```bash
git clone https://github.com/kaposke/gui_bassa-SDK
```

Install packages:
```bash
cd ./gui_bassa-SDK
dotnet restore
```
> You'll need to have the .NET 6 SDK installed ([Download it here](https://dotnet.microsoft.com/en-us/download))

Open `LotrAPI.Tests/LotrClientTests.cs` and replace the API key with yours on line 10 (or just use that one, but you might be rate-limited).

Run the tests:
```bash
dotnet test
```
> If you run tests multiple times, they will start failing because of the rate limits!

## Notes for the reviewrs
- C# and .NET are not my daily driver, its just a language and ecosystem that I like but haven't used in years. I decided to do the challenge with it to prove 
to you (and myself, honestly) that I would be able to (re)learn it and overcome the bumps on the road.

- I started using the .NET HttpClient, but eventually changed to [RestSharp](https://restsharp.dev/), which is a wrapper that makes stuff much easier. If this wasn't a challenge, I would probably
have explored [Refit](https://github.com/reactiveui/refit), which apparently makes building SDKs super straight forward.

- I have limited the scope of the unit tests because it hits the actual api, which has request limits. Its also my first time using xUnit, so take it easy xD.

- I totaly pushed the code with my API key there. Aparently using environment variables in .NET is a bit of a headache, so for this small and temporary project I 
intentionally left the key there. Just know that I'm aware of how wrong that is.

- For this small API I decided to leave all the requests in one class, but for a bigger API, I would probably split it up by resources somehow.

- Error handling certainly has room for improvement. I lack the knowledge on .NET error handling best practices, but I covered the basic cases. 
  The error handling for invalid ids has inconsistent responses in the LOTR API itself:
  - `/book/123` - Returns 200 but with error body
  - `/movies/123` (and all other `/:id` routes) - Returns 500 with same error body ^
  - `/movies/invalid_id_but_with_correct_length?` (I think) - Returns 200 and a paginated response on the body, but with an empty array (0 results).
  
  The SDK will just return null for 200 responses, but will throw an exception for 500's.

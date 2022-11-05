
using System.Text.Json.Serialization;

namespace LotrAPI.SDK.Models;

public record Movie(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("runtimeInMinutes")] int RuntimeInMinutes,
    [property: JsonPropertyName("budgetInMillions")] int BudgetInMillions,
    [property: JsonPropertyName("boxOfficeRevenueInMillions")] int BoxOfficeRevenueInMillions,
    [property: JsonPropertyName("academyAwardNominations")] int AcademyAwardNominations,
    [property: JsonPropertyName("rottenTomatoesScore")] int RottenTomatoesScore
);
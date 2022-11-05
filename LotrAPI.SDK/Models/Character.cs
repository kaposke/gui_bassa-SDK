using System.Text.Json.Serialization;

namespace LotrAPI.SDK.Models;

public record Character(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("height")] string Height,
    [property: JsonPropertyName("race")] string Race,
    [property: JsonPropertyName("gender")] string Gender,
    [property: JsonPropertyName("birth")] string Birth,
    [property: JsonPropertyName("spouse")] string Spouse,
    [property: JsonPropertyName("death")] string Death,
    [property: JsonPropertyName("realm")] string Realm,
    [property: JsonPropertyName("hair")] string Hair,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("wikiUrl")] string WikiUrl
);
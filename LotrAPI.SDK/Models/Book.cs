using System.Text.Json.Serialization;

namespace LotrAPI.SDK.Models;

public record Book(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("name")] string Name
);
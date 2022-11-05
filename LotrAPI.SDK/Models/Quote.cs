using System.Text.Json.Serialization;

namespace LotrAPI.SDK.Models;

public record Quote(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("dialog")] string Dialog,
    [property: JsonPropertyName("movie")] string MovieId,
    [property: JsonPropertyName("character")] string CharacterId
);
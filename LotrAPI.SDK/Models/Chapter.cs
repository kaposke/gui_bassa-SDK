
using System.Text.Json.Serialization;

namespace LotrAPI.SDK.Models;

public record Chapter(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("chapterName")] string ChapterName,
    [property: JsonPropertyName("book")] string BookId
);
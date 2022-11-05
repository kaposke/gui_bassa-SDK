using System.Text.Json.Serialization;

namespace LotrAPI.SDK.Common;

public record PaginatedResponse<T>(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("limit")] int Limit,
    [property: JsonPropertyName("offset")] int Offset,
    [property: JsonPropertyName("page")] int Page,
    [property: JsonPropertyName("pages")] int Pages,
    [property: JsonPropertyName("docs")] T[] Docs
);
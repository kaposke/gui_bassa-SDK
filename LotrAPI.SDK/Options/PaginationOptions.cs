namespace LotrAPI.SDK.Options;

public record PaginationOptions
{
    public int? Limit { get; init; } = null;
    public int? Page { get; init; } = null;
    public int? Offset { get; init; } = null;
}

using LotrAPI.SDK.Options.Filters;

namespace LotrAPI.SDK.Options;

public record LotrRequestOptions
{
    public PaginationOptions? Pagination { get; init; }
    public SortingOptions? Sorting { get; init; }
    public List<IFilter> Filters { get; init; } = new();
}
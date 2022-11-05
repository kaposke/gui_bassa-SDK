
using LotrAPI.SDK.Options.Filters;

namespace LotrAPI.SDK.Options;

public class LotrRequestOptions
{
    public PaginationOptions? Pagination { get; set; }
    public SortingOptions? Sorting { get; set; }
    public List<IFilter> Filters { get; set; } = new();
}
using LotrAPI.SDK.Options;
using RestSharp;

namespace LotrAPI.SDK.Extension;

public static class OptionExtensions
{
    public static RestRequest AddOptions(this RestRequest request, LotrRequestOptions options)
    {
        if (options is not null)
        {
            if (options.Pagination is not null)
            {
                if (options.Pagination.Limit.HasValue) request.AddQueryParameter("limit", options.Pagination.Limit.Value);
                if (options.Pagination.Page.HasValue) request.AddQueryParameter("page", options.Pagination.Page.Value);
                if (options.Pagination.Offset.HasValue) request.AddQueryParameter("offset", options.Pagination.Offset.Value);
            }

            if (options.Sorting is not null)
            {
                request.AddQueryParameter("sort", options.Sorting.AsQueryParam);
            }

            if (options.Filters is not null)
            {
                foreach (var filter in options.Filters)
                {
                    request.AddQueryParameter(filter.AsQueryParam, null);
                }
            }
        }

        return request;
    }
}
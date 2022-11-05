namespace LotrAPI.SDK.Options.Filters;

public class FilterNotExists<T> : IFilter
{
    public string FieldName { get; set; }
    public string AsQueryParam => $"!{FieldName}";

    public FilterNotExists(string fieldName)
    {
        FieldName = fieldName;
    }
}
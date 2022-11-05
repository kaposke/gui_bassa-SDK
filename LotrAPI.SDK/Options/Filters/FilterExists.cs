namespace LotrAPI.SDK.Options.Filters;

public class FilterExists<T> : IFilter
{
    public string FieldName { get; set; }
    public string AsQueryParam => $"{FieldName}";

    public FilterExists(string fieldName)
    {
        FieldName = fieldName;
    }
}
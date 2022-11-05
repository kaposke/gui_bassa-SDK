namespace LotrAPI.SDK.Options.Filters;

public class FilterInclude : IFilter
{
    public string FieldName { get; set; }
    public string[] Values { get; set; }
    public string AsQueryParam => $"{FieldName}={string.Join(",", Values)}";

    public FilterInclude(string fieldName, string[] values)
    {
        FieldName = fieldName;
        Values = values;
    }
}
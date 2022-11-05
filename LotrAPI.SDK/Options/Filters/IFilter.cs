namespace LotrAPI.SDK.Options.Filters;

public interface IFilter
{
    public string FieldName { get; set; }

    public string AsQueryParam { get; }
}
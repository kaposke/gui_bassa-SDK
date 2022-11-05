namespace LotrAPI.SDK.Options;

public class SortingOptions
{
    public string FieldName { get; set; } = String.Empty;
    public SortingDirection Direction { get; set; } = SortingDirection.DESC;

    public SortingOptions(string fieldName, SortingDirection direction)
    {
        FieldName = fieldName;
        Direction = direction;
    }

    public string AsQueryParam => $"{FieldName}:{(Direction == SortingDirection.DESC ? "desc" : "asc")}";
}
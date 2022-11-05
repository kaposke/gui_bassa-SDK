namespace LotrAPI.SDK.Options;

public record SortingOptions(
    string FieldName,
    SortingDirection Direction = SortingDirection.DESC
)
{
    public string AsQueryParam => $"{FieldName}:{(Direction == SortingDirection.DESC ? "desc" : "asc")}";
}
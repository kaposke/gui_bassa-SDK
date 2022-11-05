namespace LotrAPI.SDK.Options.Filters;

public enum ComparisonOperator
{
    EQUALS,
    NOT_EQUALS,
    LESS_THAN,
    GREATER_THAN,
    LESS_THEN_EQUALS,
    GREATER_THAN_EQUALS
}

public class FilterOperatorComparison<T> : IFilter
{
    public string FieldName { get; set; }
    public ComparisonOperator ComparisonOperator { get; set; }
    public T Value { get; set; }
    public string AsQueryParam => $"{FieldName}{OperatorAsString}{Value}";

    public FilterOperatorComparison(string fieldName, ComparisonOperator comparisonOperator, T value)
    {
        FieldName = fieldName;
        ComparisonOperator = comparisonOperator;
        Value = value;
    }

    private string OperatorAsString => ComparisonOperator switch
    {
        ComparisonOperator.EQUALS => "=",
        ComparisonOperator.NOT_EQUALS => "!=",
        ComparisonOperator.LESS_THAN => "<",
        ComparisonOperator.GREATER_THAN => ">",
        ComparisonOperator.LESS_THEN_EQUALS => "<=",
        ComparisonOperator.GREATER_THAN_EQUALS => ">=",
    };
}
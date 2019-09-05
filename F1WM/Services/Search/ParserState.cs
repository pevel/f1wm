namespace F1WM.Services.Search
{
	public enum ParserState
	{
		Initial,
		HasReadPropertyName,
		HasReadComparisonOperator,
		HasReadValue,
		HasReadLogicalOperator
	}
}

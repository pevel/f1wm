using System.Collections.Generic;
using System.Linq.Expressions;

namespace F1WM.Services.Search
{
	public class ParserContext
	{
		public ParameterExpression EntityParameter { get; set; }
		public ParserState State { get; set; } = ParserState.Initial;
		public Queue<Expression> LeftExpressions { get; set; } = new Queue<Expression>();
		public Queue<Expression> RightExpressions { get; set; } = new Queue<Expression>();
		public Expression FinalExpression { get; set; }
		public Queue<LogicalOperator> LogicalOperators { get; set; } = new Queue<LogicalOperator>();
		public Queue<ComparisonOperator> ComparisonOperators { get; set; } = new Queue<ComparisonOperator>();
	}
}

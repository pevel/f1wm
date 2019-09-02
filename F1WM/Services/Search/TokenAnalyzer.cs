using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace F1WM.Services.Search
{
	public class TokenAnalyzer
	{
		private readonly Dictionary<ParserState, Func<ParserContext, string, ParserContext>> functionMapping;
		private static readonly Dictionary<string, LogicalOperator> logicalOperatorMapping =
			new Dictionary<string, LogicalOperator>()
			{
				{ "and", LogicalOperator.And },
				{ "or", LogicalOperator.Or }
			};
		private static readonly Dictionary<string, ComparisonOperator> comparisonOperatorMapping =
			new Dictionary<string, ComparisonOperator>()
			{
				{ "eq", ComparisonOperator.Equal },
				{ "like", ComparisonOperator.Like },
				{ "gt", ComparisonOperator.GreaterThan },
				{ "lt", ComparisonOperator.LessThan }
			};
		
		private Func<ParserContext, string, ParserContext> ParsePropertyName = (context, token) =>
		{
			var expression = Expression.Property(context.EntityParameter, token);
			context.LeftExpressions.Enqueue(expression);
			context.State = ParserState.HasReadPropertyName;
			return context;
		};

		private Func<ParserContext, string, ParserContext> ParseComparisonOperator = (context, token) => {
			var comparisonOperator = comparisonOperatorMapping[token];
			context.ComparisonOperators.Enqueue(comparisonOperator);
			context.State = ParserState.HasReadComparisonOperator;
			return context;
		};

		private Func<ParserContext, string, ParserContext> ParseValue = (context, token) => {
			var expression = Expression.Constant(token);
			context.RightExpressions.Enqueue(expression);
			context.State = ParserState.HasReadValue;
			return context;
		};

		private Func<ParserContext, string, ParserContext> ParseLogicalOperator = (context, token) => {
			var logicalOperator = logicalOperatorMapping[token];
			context.LogicalOperators.Enqueue(logicalOperator);
			context.State = ParserState.HasReadLogicalOperator;
			return context;
		};

		public ParserContext Analyze(ParserContext context, string token)
		{
			return functionMapping[context.State](context, token);
		}

		public TokenAnalyzer()
		{
			functionMapping = new Dictionary<ParserState, Func<ParserContext, string, ParserContext>>()
			{
				{ ParserState.Initial, ParsePropertyName },
				{ ParserState.HasReadLogicalOperator, ParsePropertyName },
				{ ParserState.HasReadPropertyName, ParseComparisonOperator },
				{ ParserState.HasReadComparisonOperator, ParseValue },
				{ ParserState.HasReadValue, ParseLogicalOperator }
			};
		}
	}
}

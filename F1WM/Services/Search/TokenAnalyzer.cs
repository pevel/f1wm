using System;
using System.Collections.Generic;
using System.Linq;
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
			try
			{
				var expression = Expression.Property(context.EntityParameter, token);
				context.LeftExpressions.Enqueue(expression);
				context.State = ParserState.HasReadPropertyName;
				return context;
			}
			catch (ArgumentException expressionException)
			{
				throw new TokenAnalyzerException(
					$"Property '{token}' does not exist in entity of type '{context.EntityParameter.Type.Name}'.",
					expressionException
				);
			}
			catch (Exception otherException)
			{
				throw new TokenAnalyzerException($"Cannot parse property name: '{token}'.", otherException);
			}
		};

		private Func<ParserContext, string, ParserContext> ParseComparisonOperator = (context, token) => {
			try
			{
				var comparisonOperator = comparisonOperatorMapping[token];
				context.ComparisonOperators.Enqueue(comparisonOperator);
				context.State = ParserState.HasReadComparisonOperator;
				return context;
			}
			catch
			{
				var expectedOperators = string.Join("', '", comparisonOperatorMapping.Keys.ToArray());
				throw new TokenAnalyzerException(
					$"Cannot parse: '{token}'. Expected any of comparison operators: '{expectedOperators}'.");
			}
		};

		private Func<ParserContext, string, ParserContext> ParseValue = (context, token) => {
			try
			{
				var expression = Expression.Constant(token);
				context.RightExpressions.Enqueue(expression);
				context.State = ParserState.HasReadValue;
				return context;
			}
			catch
			{
				throw new TokenAnalyzerException($"Cannot parse: '{token}'. Expected a value to compare to.");
			}
		};

		private Func<ParserContext, string, ParserContext> ParseLogicalOperator = (context, token) => {
			try
			{
				var logicalOperator = logicalOperatorMapping[token];
				context.LogicalOperators.Enqueue(logicalOperator);
				context.State = ParserState.HasReadLogicalOperator;
				return context;
			}
			catch
			{
				var expectedOperators = string.Join("', '", logicalOperatorMapping.Keys.ToArray());
				throw new TokenAnalyzerException(
					$"Cannot parse: '{token}'. Expected any of logical operators: '{expectedOperators}'.");
			}
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

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace F1WM.Services.Search
{
	public class ExpressionTreeBuilder
	{
		private readonly Dictionary<LogicalOperator, Func<ParserContext, ParserContext>> logicalBuilderMapping;
		private readonly Dictionary<ComparisonOperator, Func<ParserContext, ParserContext>> comparisonBuilderMapping;

		private Func<ParserContext, ParserContext> BuildAndExpression = (c) =>
		{
			var firstOperand = c.LeftExpressions.Dequeue();
			if (c.LeftExpressions.TryDequeue(out var secondOperand))
			{
				c.FinalExpression = Expression.AndAlso(firstOperand, secondOperand);
			}
			else if (c.FinalExpression != null)
			{
				c.FinalExpression = Expression.AndAlso(firstOperand, c.FinalExpression);
			}
			else
			{

			}
			return c;
		};

		private Func<ParserContext, ParserContext> BuildOrExpression = (c) =>
		{
			var firstOperand = c.LeftExpressions.Dequeue();
			if (c.LeftExpressions.TryDequeue(out var secondOperand))
			{
				c.FinalExpression = Expression.OrElse(firstOperand, secondOperand);
			}
			else if (c.FinalExpression != null)
			{
				c.FinalExpression = Expression.OrElse(firstOperand, c.FinalExpression);
			}
			else
			{

			}
			return c;
		};

		private Func<ParserContext, ParserContext> BuildEqualExpression = (c) =>
		{
			var leftOperand = c.LeftExpressions.Dequeue();
			var rightOperand = c.RightExpressions.Dequeue();
			var expression = Expression.Equal(leftOperand, rightOperand);
			c.LeftExpressions.Enqueue(expression);
			return c;
		};

		private Func<ParserContext, ParserContext> BuildLikeExpression = (c) =>
		{
			var leftOperand = c.LeftExpressions.Dequeue();
			var rightOperand = c.RightExpressions.Dequeue();
			var expression = Expression.Call(
				leftOperand,
				typeof(string).GetMethod(nameof(string.Contains), new Type[] { typeof(string) }),
				new Expression[] { rightOperand }
			);
			c.LeftExpressions.Enqueue(expression);
			return c;
		};

		private Func<ParserContext, ParserContext> BuildGreaterThanExpression = (c) =>
		{
			var leftOperand = c.LeftExpressions.Dequeue();
			var rightOperand = c.RightExpressions.Dequeue();
			var expression = Expression.GreaterThan(leftOperand, rightOperand);
			c.LeftExpressions.Enqueue(expression);
			return c;
		};

		private Func<ParserContext, ParserContext> BuildLessThanExpression = (c) =>
		{
			var leftOperand = c.LeftExpressions.Dequeue();
			var rightOperand = c.RightExpressions.Dequeue();
			var expression = Expression.LessThan(leftOperand, rightOperand);
			c.LeftExpressions.Enqueue(expression);
			return c;
		};

		public Expression BuildExpressionFrom(ParserContext context)
		{
			Expression expression = null;
			while (ShouldBuildComparisonExpression(context))
			{
				var comparisonOperator = context.ComparisonOperators.Dequeue();
				context = comparisonBuilderMapping[comparisonOperator](context);
			}
			while (ShouldBuildLogicalExpression(context))
			{
				var logicalOperator = context.LogicalOperators.Dequeue();
				context = logicalBuilderMapping[logicalOperator](context);
			}
			expression = context.FinalExpression;
			if (expression == null)
			{

			}
			return expression;
		}

		public ExpressionTreeBuilder()
		{
			logicalBuilderMapping = new Dictionary<LogicalOperator, Func<ParserContext, ParserContext>>()
			{
				{ LogicalOperator.And, BuildAndExpression },
				{ LogicalOperator.Or, BuildOrExpression }
			};
			comparisonBuilderMapping = new Dictionary<ComparisonOperator, Func<ParserContext, ParserContext>>()
			{
				{ ComparisonOperator.Equal, BuildEqualExpression },
				{ ComparisonOperator.Like, BuildLikeExpression },
				{ ComparisonOperator.GreaterThan, BuildGreaterThanExpression },
				{ ComparisonOperator.LessThan, BuildLessThanExpression }
			};
		}

		private bool ShouldBuildComparisonExpression(ParserContext c)
		{
			return c.LeftExpressions.TryPeek(out var x) && c.RightExpressions.TryPeek(out var y); 
		}

		private bool ShouldBuildLogicalExpression(ParserContext c)
		{
			return c.LeftExpressions.TryPeek(out var x) && c.LogicalOperators.TryPeek(out var y);
		}
	}
}

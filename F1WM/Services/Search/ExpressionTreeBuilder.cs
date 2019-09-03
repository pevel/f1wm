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
			try
			{
				var firstOperand = c.LeftExpressions.Dequeue();
				if (c.LeftExpressions.TryDequeue(out var secondOperand))
				{
					c.FinalExpression = Expression.AndAlso(firstOperand, secondOperand);
					return c;
				}
				else if (c.FinalExpression != null)
				{
					c.FinalExpression = Expression.AndAlso(firstOperand, c.FinalExpression);
					return c;
				}
				throw new ExpressionTreeBuilderException("Cannot apply 'and' operator. The order of filter tokens is incorrect.");
			}
			catch (Exception ex)
			{
				throw new ExpressionTreeBuilderException("Cannot apply 'and' operator.", ex);
			}
		};

		private Func<ParserContext, ParserContext> BuildOrExpression = (c) =>
		{
			try
			{
				var firstOperand = c.LeftExpressions.Dequeue();
				if (c.LeftExpressions.TryDequeue(out var secondOperand))
				{
					c.FinalExpression = Expression.OrElse(firstOperand, secondOperand);
					return c;
				}
				else if (c.FinalExpression != null)
				{
					c.FinalExpression = Expression.OrElse(firstOperand, c.FinalExpression);
					return c;
				}
				throw new ExpressionTreeBuilderException("Cannot apply 'or' operator. The order of filter tokens is incorrect.");
			}
			catch (Exception ex)
			{
				throw new ExpressionTreeBuilderException("Cannot apply 'or' operator.", ex);
			}
		};

		private Func<ParserContext, ParserContext> BuildEqualExpression = (c) =>
		{
			try
			{
				var leftOperand = c.LeftExpressions.Dequeue();
				var rightOperand = c.RightExpressions.Dequeue();
				var expression = Expression.Equal(leftOperand, rightOperand);
				c.LeftExpressions.Enqueue(expression);
				return c;
			}
			catch (Exception ex)
			{
				throw new ExpressionTreeBuilderException("Cannot apply equality operator.", ex);
			}
		};

		private Func<ParserContext, ParserContext> BuildLikeExpression = (c) =>
		{
			try
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
			}
			catch (Exception ex)
			{
				throw new ExpressionTreeBuilderException("Cannot apply 'like' operator.", ex);
			}
		};

		private Func<ParserContext, ParserContext> BuildGreaterThanExpression = (c) =>
		{
			try
			{
				var leftOperand = c.LeftExpressions.Dequeue();
				var rightOperand = c.RightExpressions.Dequeue();
				var expression = Expression.GreaterThan(leftOperand, rightOperand);
				c.LeftExpressions.Enqueue(expression);
				return c;
			}
			catch (Exception ex)
			{
				throw new ExpressionTreeBuilderException("Cannot apply greater than operator.", ex);
			}
		};

		private Func<ParserContext, ParserContext> BuildLessThanExpression = (c) =>
		{
			try
			{
				var leftOperand = c.LeftExpressions.Dequeue();
				var rightOperand = c.RightExpressions.Dequeue();
				var expression = Expression.LessThan(leftOperand, rightOperand);
				c.LeftExpressions.Enqueue(expression);
				return c;
			}
			catch (Exception ex)
			{
				throw new ExpressionTreeBuilderException("Cannot apply less than operator.", ex);
			}
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
			expression = context.FinalExpression ?? context.LeftExpressions.Dequeue();
			if (expression == null)
			{
				throw new ExpressionTreeBuilderException("Cannot build expression. The order of filter tokens is incorrect.");
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

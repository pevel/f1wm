using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using F1WM.Services.Search;

namespace F1WM.Services
{
	public class SearchService : ISearchService
	{
		private const int costLimit = 40;
		private ParserContext context = new ParserContext();
		private TokenAnalyzer analyzer = new TokenAnalyzer();
		private ExpressionTreeBuilder expressionBuilder = new ExpressionTreeBuilder();

		public Expression<Func<T, bool>> BuildExpressionFrom<T>(string filter)
		{
			var tokens = Tokenize(filter);
			context.EntityParameter = Expression.Parameter(typeof(T), "e");
			foreach (var token in tokens)
			{
				context = analyzer.Analyze(context, token);
			}
			var innerExpression = expressionBuilder.BuildExpressionFrom(context);
			return Expression.Lambda<Func<T, bool>>(
				innerExpression,
				new ParameterExpression[] { context.EntityParameter }
			);
		}

		private IEnumerable<string> Tokenize(string filter)
		{
			var tokens = filter.ToLower().Split(' ');
			if (tokens.Length < 3)
			{

			}
			if (tokens.Length > costLimit)
			{

			}
			return tokens;
		}
	}
}

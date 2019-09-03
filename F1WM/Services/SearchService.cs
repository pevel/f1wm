using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using F1WM.Services.Search;

namespace F1WM.Services
{
	public class SearchService : ISearchService
	{
		private const int costLimit = 40;
		private const int filterCharLimit = 500;
		private ParserContext context = new ParserContext();
		private TokenAnalyzer analyzer = new TokenAnalyzer();
		private ExpressionTreeBuilder expressionBuilder = new ExpressionTreeBuilder();
		private readonly Dictionary<Type, Func<Exception, string>> errorMessagesMapping = new Dictionary<Type, Func<Exception, string>>()
		{
			{
				typeof(FilterTooLongException),
				_ => $"Provided filter is too long. Number of tokens is limited to {costLimit} and number of characters is limited to {filterCharLimit}."
			},
			{
				typeof(FilterTooShortException),
				_ => $"Provided filter is too short. Minimal viable filter has 3 tokens."
			},
			{
				typeof(TokenAnalyzerException),
				ex => (ex as TokenAnalyzerException).Message
			},
			{
				typeof(ExpressionTreeBuilderException),
				ex => (ex as ExpressionTreeBuilderException).Message
			}
		};

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

		public bool TryBuildError(Exception exception, out string humanReadableError)
		{
			if (errorMessagesMapping.TryGetValue(exception.GetType(), out var messageFactory))
			{
				humanReadableError = messageFactory(exception);
				return true;
			}
			humanReadableError = null;
			return false;
		}

		private IEnumerable<string> Tokenize(string filter)
		{
			if (filter.Length > filterCharLimit)
			{
				throw new FilterTooLongException();
			}
			var tokens = filter.ToLower().Split(' ');
			if (tokens.Length < 3)
			{
				throw new FilterTooShortException();
			}
			if (tokens.Length > costLimit)
			{
				throw new FilterTooLongException();
			}
			return tokens;
		}
	}
}

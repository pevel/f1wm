using System;
using System.Linq;
using System.Linq.Expressions;

namespace F1WM.Utilities
{
	public static class F1WMExpressions
	{
		public static Expression<Func<T, bool>> Like<T>(string term, params string[] propertyNames)
		{
			if (propertyNames == null || propertyNames.Length == 0)
			{
				throw new ArgumentException("No properties to search on.", nameof(propertyNames));
			}

			Expression lambdaBody;
			var entity = Expression.Parameter(typeof(T), "e");
			var compareExpressions = propertyNames.Select(propertyName =>
			{
				return F1WMExpressions.GetCaseInsensitiveStringCompareExpression(
					Expression.Property(entity, propertyName),
					Expression.Constant(term)
				);
			});

			lambdaBody = compareExpressions.First();

			foreach (var compareExpression in compareExpressions.Skip(1))
			{
				lambdaBody = Expression.Or(lambdaBody, compareExpression);
			}

			return Expression.Lambda<Func<T, bool>>(
				lambdaBody,
				new ParameterExpression[] { entity }
			);
		}

		public static Expression GetCaseInsensitiveStringCompareExpression(Expression value, Expression searchTerm)
		{
			return Expression.GreaterThanOrEqual(
				Expression.Call(
					value,
					typeof(string).GetMethod(nameof(string.IndexOf), new Type[] { typeof(string), typeof(StringComparison) }),
					searchTerm,
					Expression.Constant(StringComparison.CurrentCultureIgnoreCase)
				),
				Expression.Constant(0)
			);
		}
	}
}

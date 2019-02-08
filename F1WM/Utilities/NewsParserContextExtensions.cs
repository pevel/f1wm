using System;
using System.Text.RegularExpressions;
using F1WM.Utilities.Model;

namespace F1WM.Utilities
{
	public static class NewsParserContextExtensions
	{
		public static void ParseTable(this NewsParserContext context)
		{
			if (IsTableDefinition(context.CurrentLine) && context.Reader.Peek() != -1)
			{
				context.Writer.Write("<table><tr>");
				ParseTableHeaders(context);
				context.Writer.Write("</tr>");
				ParseTableBody(context);
				context.Writer.Write("</table>");
			}
			else
			{
				context.Writer.Write(context.CurrentLine + "<br/>");
			}
		}

		private static bool IsTableDefinition(string text)
		{
			var regex = new Regex(@"%MAX%(\d)%");
			return regex.Matches(text).Count != 0;
		}

		private static void ParseTableHeaders(NewsParserContext context)
		{
			var headersLine = context.Reader.ReadLine();
			var tokens = headersLine.Split('|');
			if (tokens.Length > 1)
			{
				foreach (var token in tokens)
				{
					var header = token == "&" ? "" : token;
					context.Writer.Write($"<th>{header}</th>");
				}
			}
			else
			{
				throw new ArgumentException(
					"Attempted to parse news table in an unknown format",
					nameof(context));
			}
		}

		private static void ParseTableBody(NewsParserContext context)
		{
			while (context.Reader.Peek() != -1)
			{
				var line = context.Reader.ReadLine();
				var tokens = line.Split('|');
				if (tokens.Length > 1)
				{

				}
			}
		}
	}
}

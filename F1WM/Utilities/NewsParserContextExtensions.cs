using System;
using System.Linq;
using System.Text.RegularExpressions;
using F1WM.Utilities.Model;

namespace F1WM.Utilities
{
	public static class NewsParserContextExtensions
	{
		private const string tableClass = "news-table";
		private const string titleClass = "news-table-title";
		private const string footerClass = "news-table-footer";

		public static void ParseTable(this NewsParserContext context)
		{
			if (TryParseTableDeclaration(context.CurrentLine, out var tableProperties) && context.Reader.Peek() != -1)
			{
				ParseTable(context, tableProperties);
			}
			else
			{
				context.Writer.Write(context.CurrentLine + "<br/>");
			}
		}

		private static bool TryParseTableDeclaration(string text, out NewsTableProperties properties)
		{
			properties = null;
			var regex = new Regex(@"%(?<width>\w+)%(?<columns>\d+)%(?<order>NR)?%?(STRATA)?%?(\w+)?");
			var match = regex.Match(text);
			if (match.Success)
			{
				properties = new NewsTableProperties
				{
					Width = match.Groups["width"].Value,
					InsertOrderColumn = match.Groups["order"].Success,
					ColumnsCount = Int32.Parse(match.Groups["columns"].Value)
				};
				return true;
			}
			return false;
		}

		private static void ParseTable(NewsParserContext context, NewsTableProperties properties)
		{
			bool expectHeaders = false;
			int order = 1;
			context.Writer.Write($"<table class=\"{tableClass}\">");
			while (context.Reader.Peek() != -1)
			{
				var line = context.Reader.ReadLine();
				var tokens = line.Split('|').Take(properties.ColumnsCount).ToArray();
				if (tokens.Length > 1)
				{
					context.Writer.Write("<tr>");
					if (tokens[0] == "&" || tokens[0] == "%")
					{
						string className = tokens[0] == "&" ? titleClass : footerClass;
						int colspan = properties.InsertOrderColumn ? properties.ColumnsCount + 1 : properties.ColumnsCount;
						context.Writer.Write($"<td class=\"{className}\" colspan=\"{colspan}\">{tokens[1]}</td>");
						expectHeaders = true;
						order = 1;
					}
					else
					{
						string tag = expectHeaders ? "th" : "td";
						if (properties.InsertOrderColumn)
						{
							string toWrite = expectHeaders ? "" : order.ToString();
							context.Writer.Write($"<{tag}>{toWrite}</{tag}>");
						}
						foreach (var token in tokens)
						{
							string toWrite = token;
							if (toWrite.StartsWith('~'))
							{
								toWrite = $"<img src=\"{toWrite.Substring(1).GetFlagIconPath()}\">";
							}
							context.Writer.Write($"<{tag}>{toWrite}</{tag}>");
						}
						expectHeaders = false;
					}
					context.Writer.Write("</tr>");
				}
				else
				{
					context.Writer.Write("</table>");
					context.Writer.Write(line);
					return;
				}
			}
			context.Writer.Write("</table>");
		}
	}
}

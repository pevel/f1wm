using System;
using System.Linq;
using System.Text.RegularExpressions;
using F1WM.ApiModel;
using F1WM.Utilities.Model;

namespace F1WM.Utilities
{
	public static class NewsParserContextExtensions
	{
		private const string tableClass = "news-table";
		private const string titleClass = "news-table-title";
		private const string footerClass = "news-table-footer";
		private const string videoClass = "news-video";

		public static void ParseTable(this NewsParserContext context)
		{
			if (TryParseTableDeclaration(context.CurrentLine, out var tableProperties) && context.Reader.Peek() != -1)
			{
				ParseTable(context, tableProperties);
			}
			else
			{
				context.DumpCurrentLine();
			}
		}

		public static void ParseResultsOrVideo(this NewsParserContext context)
		{
			if (TryGetEventId(context.CurrentLine, out var resultLink))
			{
				context.News.ResultLink = resultLink;
			}
			else if (context.CurrentLine.StartsWith("^youtube,"))
			{
				ParseVideo(context);
			}
			else
			{
				context.DumpCurrentLine();
			}
		}

		public static void ParsePracticeResults(this NewsParserContext context)
		{
			if (TryGetPracticeResultLink(context.CurrentLine, out var resultLink))
			{
				context.News.ResultLink = resultLink;
			}
			else
			{
				context.DumpCurrentLine();
			}
		}

		private static bool TryGetEventId(string line, out ResultLink resultLink)
		{
			var preparedLine = line;
			if (line.StartsWith("^rezultat,"))
			{
				preparedLine = line.Replace("rezultat,", "");
			}
			if (int.TryParse(preparedLine.Replace("^", ""), out int eventId))
			{
				resultLink = new ResultLink()
				{
					Type = ResultLinkType.Other,
					EventId = eventId
				};
				return true;
			}
			resultLink = null;
			return false;
		}

		private static void ParseVideo(NewsParserContext context)
		{

		}

		private static bool TryGetPracticeResultLink(this string line, out ResultLink resultLink)
		{
			if (line.StartsWith("$^"))
			{
				var regex = new Regex(@"\$\^([\d]+)\$(t[\d]+)");
				var match = regex.Match(line);
				if (match.Groups.Count == 3)
				{
					resultLink = new ResultLink()
					{
						Type = ResultLinkType.Practice,
						RaceId = Int32.Parse(match.Groups[1].Value),
						Session = match.Groups[2].Value
					};
					return true;
				}
			}
			resultLink = null;
			return false;
		}

		private static bool TryParseTableDeclaration(string text, out NewsTableProperties properties)
		{
			properties = null;
			var regex = new Regex(@"%(?<width>\w+)%(?<columns>\d+)%?(?<order>NR)?%?(STRATA)?%?(\w+)?");
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
			bool expectHeaders = true;
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
						expectHeaders = tokens[0] == "&";
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

		private static void DumpCurrentLine(this NewsParserContext context)
		{
			context.Writer.Write(context.CurrentLine + "<br/>");
		}
	}
}

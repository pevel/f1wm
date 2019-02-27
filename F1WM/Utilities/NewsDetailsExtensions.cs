using System;
using System.IO;
using System.Text.RegularExpressions;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities.Model;
using Database = F1WM.DatabaseModel.Constants;

namespace F1WM.Utilities
{
	public static class NewsDetailsExtensions
	{
		public static NewsDetails ParseCustomFormatting(this NewsDetails news)
		{
			if (!string.IsNullOrEmpty(news.Text))
			{
				using(var reader = new StringReader(news.Text))
				using(var writer = new StringWriter())
				{
					while (reader.Peek() != -1)
					{
						var line = reader.ReadLine();
						var token = line.Length > 0 ? $"{line[0]}" : "";
						if (Constants.TokenToParser.TryGetValue(token, out var parse))
						{
							parse(new NewsParserContext()
							{
								CurrentLine = line,
								Reader = reader,
								Writer = writer,
								News = news
							});
						}
						else
						{
							writer.Write(line + "<br/>");
						}
					}
					news.Text = writer.ToString();
				}
			}
			return news;
		}

		public static bool TryParseResultRedirect(this NewsDetails news, out ResultRedirectLink link)
		{
			if (!string.IsNullOrWhiteSpace(news.Redirect))
			{
				var regex = new Regex(@"php/rel_gen\.php\?rok=([\d]+)&nr=([\d]+)(&dzial=([\d]+))*");
				var match = regex.Match(news.Redirect);
				if (match.Groups.Count == 5)
				{
					if (!int.TryParse(match.Groups[4].Value, out int resultType))
					{
						resultType = (int)Database.ResultType.Race;
					}
					link = new ResultRedirectLink()
					{
						Year = int.Parse(match.Groups[1].Value),
						Number = int.Parse(match.Groups[2].Value),
						ResultType = (Database.ResultType)resultType
					};
					return true;
				}
			}
			link = null;
			return false;
		}
	}
}

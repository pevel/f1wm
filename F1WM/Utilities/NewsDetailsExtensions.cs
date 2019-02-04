using System;
using System.IO;
using System.Text.RegularExpressions;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
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
						if (line.TryGetEventId(out ResultLink otherLink))
						{
							news.ResultLink = otherLink;
						}
						else if (line.TryGetPracticeResultLink(out ResultLink practiceLink))
						{
							news.ResultLink = practiceLink;
						}
						else
						{
							var token = line.Length > 0 ? $"{line[0]}" : "";
							if (Constants.TokenToParser.ContainsKey(token))
							{
								line = Constants.TokenToParser[token](line);
							}
							writer.Write(line + "<br/>");
						}
					}
					news.Text = writer.ToString();
				}
				return news;
			}
			else
			{
				return news;
			}
		}

		private static bool TryGetEventId(this string line, out ResultLink resultLink)
		{
			if (!string.IsNullOrEmpty(line) && line.StartsWith("^"))
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
			}
			resultLink = null;
			return false;
		}

		private static bool TryGetPracticeResultLink(this string line, out ResultLink resultLink)
		{
			if (!string.IsNullOrEmpty(line) && line.StartsWith("$^"))
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

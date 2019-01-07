using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using F1WM.ApiModel;

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
							if (Constants.TokenToParserMapping.ContainsKey(token))
							{
								line = Constants.TokenToParserMapping[token](line);
							}
							writer.WriteLine(line + "<br/>");
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
				if (line.StartsWith("^rezultat,"))
				{
					line = line.Replace("rezultat,", "");
				}
				resultLink = new ResultLink()
				{
					Type = ResultLinkType.Other,
						EventId = Int32.Parse(line.Replace("^", ""))
				};
				return true;
			}
			else
			{
				resultLink = null;
				return false;
			}
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
	}
}
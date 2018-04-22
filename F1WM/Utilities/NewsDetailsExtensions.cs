using System;
using System.Collections.Generic;
using System.IO;
using F1WM.Model;

namespace F1WM.Utilities
{
	public static class NewsDetailsExtensions
	{
		public static Dictionary<string, Func<string, string>> TokenToParserMapping = new Dictionary<string, Func<string, string>>()
		{
			{ "#", line => $"<span class=\"news-text-center\">${line}</span>" },
			{ "*", line => $"<h2 class=\"news-text-center\">${line}</h2>" },
			{ ">", line => $"<h3>${line}</h3>"},
			{ "=", line => $"<span class=\"news-text-title\">${line}</span>" },
			{ "@", line => line.ParseImageInformation()}
		};

		public static NewsDetails ParseCustomFormatting(this NewsDetails news)
		{
			if (!string.IsNullOrEmpty(news.Text))
			{
				using (var reader = new StringReader(news.Text))
				using (var writer = new StringWriter())
				{
					int? raceResultId;
					while (reader.Peek() != -1)
					{
						var line = reader.ReadLine();
						if (line.TryGetRaceResultId(out raceResultId))
						{
							news.RaceResultId = raceResultId;
						}
						else
						{
							var token = line.Length > 0 ? $"{line[0]}" : "";
							if (TokenToParserMapping.ContainsKey(token))
							{
								line = TokenToParserMapping[token](line);
							}
							writer.WriteLine(line);
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

		private static bool TryGetRaceResultId(this string line, out int? raceResultId)
		{
			if (!string.IsNullOrEmpty(line) && line.StartsWith("^rezultat,"))
			{
				raceResultId = Int32.Parse(line.Replace("^rezultat,", ""));
				return true;
			}
			else
			{
				raceResultId = null;
				return false;
			}
		}
	}
}
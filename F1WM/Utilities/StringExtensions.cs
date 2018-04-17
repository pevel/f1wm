using System;
using System.Collections.Generic;
using System.IO;

namespace F1WM.Utilities
{
	public static class StringExtensions
	{
		public static Dictionary<string, Func<string, string>> TokenToParserMapping = new Dictionary<string, Func<string, string>>()
		{
			{ "#", line => $"<span class=\"news-text-center\">${line}</span>" },
			{ "*", line => $"<h2 class=\"news-text-center\">${line}</h2>" },
			{ ">", line => $"<h3 class=\"news-text-center\">${line}</h3>"},
			{ "@", line => line.ParseImageInformation()}
		};

		public static string ParseImageInformation(this string text)
		{
			if (!string.IsNullOrEmpty(text))
			{
				var imageSource = text.Split(',')[2];
				imageSource = imageSource.StartsWith("http") ? imageSource : $"/img/news/{imageSource}";
				var imageInformation = $"<img src=\"{imageSource}\">";
				text = imageInformation;
			}
			return text;
		}

		public static string Cleanup(this string text)
		{
			return text?.Replace("[urlb=", "[url=").Replace("[urln=", "[url=");
		}

		public static string ParseCustomFormatting(this string text)
		{
			if (!string.IsNullOrEmpty(text))
			{
				using (var reader = new StringReader(text))
				using (var writer = new StringWriter())
				{
					while (reader.Peek() != -1)
					{
						var line = reader.ReadLine();
						var token = line.Length > 0 ? $"{line[0]}" : "";
						if (TokenToParserMapping.ContainsKey(token))
						{
							line = TokenToParserMapping[token](line);
						}
						writer.WriteLine(line);
					}
					return writer.ToString();
				}
			}
			else
			{
				return text;
			}
		}
	}
}
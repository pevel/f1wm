using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using F1WM.ApiModel;
using Constants = F1WM.DatabaseModel.Constants;

namespace F1WM.Utilities
{
	public static class StringExtensions
	{
		private static Dictionary<string, ApiModel.ResultStatus> textToResultStatus = new Dictionary<string, ApiModel.ResultStatus>()
		{ 
			{ Constants.ResultStatus.DidNotStart, ApiModel.ResultStatus.DidNotStart },
			{ Constants.ResultStatus.DidNotStartAgain, ApiModel.ResultStatus.DidNotStartAgain },
			{ Constants.ResultStatus.Disqualified, ApiModel.ResultStatus.Disqualified },
			{ Constants.ResultStatus.Excluded, ApiModel.ResultStatus.Excluded },
			{ Constants.ResultStatus.NotClassified, ApiModel.ResultStatus.NotClassified }
		};

		private static Dictionary<string, ApiModel.StartStatus> textToStartStatus = new Dictionary<string, StartStatus>()
		{
			{ Constants.StartStatus.NotClassified, ApiModel.StartStatus.NotClassified },
			{ Constants.StartStatus.Excluded, ApiModel.StartStatus.Excluded },
			{ Constants.StartStatus.FromPitLane, ApiModel.StartStatus.FromPitLane },
			{ Constants.StartStatus.NotPreQualified, ApiModel.StartStatus.NotPreQualified },
			{ Constants.StartStatus.NotQualified, ApiModel.StartStatus.NotQualified }
		};

		private static Dictionary<string, ApiModel.QualifyStatus> textToQualifyStatus = new Dictionary<string, QualifyStatus>()
		{
			{ Constants.QualifyStatus.DidNotStart, ApiModel.QualifyStatus.DidNotStart },
			{ Constants.QualifyStatus.Excluded, ApiModel.QualifyStatus.Excluded },
			{ Constants.QualifyStatus.NotQualified, ApiModel.QualifyStatus.NotQualified }
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

		public static ImportantNewsSummary ParseImportantNews(this string text)
		{
			if (!string.IsNullOrEmpty(text))
			{
				var tokens = text.Split('|');
				int id;
				if (tokens.Length != 3 || !int.TryParse(tokens[0], out id)) 
				{
					throw new ArgumentException("Attempted to parse text in an unknown format (it's expected to be: newsID|imageUrl|newsShortText)", nameof(text));
				}
				return new ImportantNewsSummary()
				{
					Id = id,
					ImageUrl = tokens[1].GetImageUrl(),
					ShortText = tokens[2]
				};
			}
			return null;
		}

		public static string GetImageUrl(this string text)
		{
			return $"/img/news/{text}";
		}

		public static string Cleanup(this string text)
		{
			return text == null ? string.Empty : text.Replace("[urlb=", "[url=").Replace("[urln=", "[url=");
		}

		public static string GetFlagIconPath(this string id)
		{
			return $"/img/flagi/{id}2.gif";
		}

		public static string GetTrackIconPath(this string id)
		{
			return $"/img/tory/{id}_m2.png";
		}

		public static string GetGrandPrixName(this string genitive)
		{
			return $"Grand Prix {genitive}";
		}

		public static ResultStatus GetResultStatus(this string statusText)
		{
			return textToResultStatus.TryGetValue(statusText, out ResultStatus status) ? status : ResultStatus.Unknown;
		}

		public static StartStatus GetStartStatus(this string statusText)
		{
			return textToStartStatus.TryGetValue(statusText, out StartStatus status) ? status : StartStatus.Unknown;
		}

		public static QualifyStatus GetQualifyStatus(this string statusText)
		{
			return textToQualifyStatus.TryGetValue(statusText, out QualifyStatus status) ? status : QualifyStatus.Unknown;
		}
	}
}
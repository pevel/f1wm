using System;
using System.Collections.Generic;
using F1WM.ApiModel;
using Database = F1WM.DatabaseModel.Constants;

namespace F1WM.Utilities
{
	public static class StringExtensions
	{
		public static string IgnoreEmpty(this string text)
		{
			return text == "-" || string.IsNullOrWhiteSpace(text) ? null : text;
		}

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
					throw new ArgumentException(
						"Attempted to parse text in an unknown format (it's expected to be: newsID|imageUrl|newsShortText)",
						nameof(text)
					);
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

		public static string GetGenericIconPath(this string id)
		{
			return id == null ? string.Empty : $"/img/ikony/{id}.gif";
		}

		public static string GetDriverPicturePath(this string id)
		{
			return $"/img/ikony/1_{id}.gif";
		}

		public static string GetTeamLogoPath(this string id)
		{
			return $"/img/ikony/2_{id}.gif";
		}

		public static string GetGrandPrixName(this string genitive)
		{
			return $"Grand Prix {genitive}";
		}

		public static string GetCareerImagePath(this string text)
		{
			return text == null ? null : $"/kierowcy/kariera/{text}";
		}

		public static string GetTeamImagePath(this string text)
		{
			return text == null || string.IsNullOrWhiteSpace(text) ? null : $"/img/zespoly/{text}";
		}

		public static ResultStatus GetResultStatus(this string statusText)
		{
			return Constants.TextToResultStatus.TryGetValue(statusText, out ResultStatus status) ? status : ResultStatus.Unknown;
		}

		public static StartStatus GetStartStatus(this string statusText)
		{
			return Constants.TextToStartStatus.TryGetValue(statusText, out StartStatus status) ? status : StartStatus.Unknown;
		}

		public static QualifyStatus GetQualifyStatus(this string statusText)
		{
			return Constants.TextToQualifyStatus.TryGetValue(statusText, out QualifyStatus status) ? status : QualifyStatus.Unknown;
		}

		public static OtherResultStatus GetOtherResultStatus(this string statusText)
		{
			return Constants.TextToOtherResultStatus.TryGetValue(statusText, out OtherResultStatus status) ? status : OtherResultStatus.Other;
		}

		public static bool IsPolePositionStatus(this string statusText)
		{
			return statusText == Database.OtherResultStatus.PolePosition;
		}

		public static bool IsFastestLapStatus(this string statusText)
		{
			return statusText == Database.OtherResultStatus.FastestLap;
		}

		public static bool HasAdditionalPoints(this string statusText)
		{
			return statusText == Database.OtherResultStatus.AdditionalPoints;
		}
	}
}

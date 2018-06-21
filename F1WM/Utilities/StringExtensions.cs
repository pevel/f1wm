using System;
using System.Collections.Generic;
using System.IO;
using F1WM.ApiModel;

namespace F1WM.Utilities
{
	public static class StringExtensions
	{
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

		public static string GetFlagIconPath(this string id)
		{
			return $"/img/ikony/{id}2.gif";
		}
	}
}
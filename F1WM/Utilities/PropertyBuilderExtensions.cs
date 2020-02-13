using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.Utilities
{
	public static class PropertyBuilderExtensions
	{
		private const string timeOfDayFormat = "h\\:mm";

		public static PropertyBuilder<TimeSpan> HasTimeConversions(this PropertyBuilder<TimeSpan> builder)
		{
			return builder.HasConversion(
				v => v.TotalMilliseconds,
				v => TimeSpan.FromMilliseconds(v * 1000)
			);
		}

		public static PropertyBuilder<TimeSpan> HasTimeOfDayConversions(this PropertyBuilder<TimeSpan> builder)
		{
			return builder.HasConversion(
				v => v.ToString(timeOfDayFormat),
				v => ParseTimeOfDay(v)
			);
		}

		private static TimeSpan ParseTimeOfDay(string v)
		{
			return string.IsNullOrWhiteSpace(v) ? TimeSpan.Zero : TimeSpan.ParseExact(
				v,
				timeOfDayFormat,
				CultureInfo.InvariantCulture);
		}
	}
}

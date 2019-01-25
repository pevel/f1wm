using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class DriverExtensions
	{
		public static IEnumerable<string> GetSeriesChampionInfo(this Driver driver)
		{
			if (!string.IsNullOrWhiteSpace(driver.ChampionAtSeries.IgnoreEmpty()))
			{
				return driver.ChampionAtSeries.Split('|', StringSplitOptions.None).ToList();
			}
			else
			{
				return null;
			}
		}

		public static IEnumerable<DriverCareerYear> ParseCareerInfo(this Driver driver)
		{
			var careerYears = new List<DriverCareerYear>();
			try
			{
				if (!string.IsNullOrEmpty(driver.CareerText))
				{
					using (var reader = new StringReader(driver.CareerText))
					{
						while (reader.Peek() != -1)
						{
							var headerLine = reader.ReadLine();
							var headerLineSplitted = headerLine.Trim().Split(':');
							var textLine = reader.ReadLine();
							careerYears.Add(new DriverCareerYear()
							{
								Year = Int32.Parse(headerLineSplitted[0]),
								Picture = headerLineSplitted[1].GetCareerImagePath(),
								Text = textLine
							});
						}
					}
				}
				return careerYears.OrderByDescending(y => y.Year);
			}
			catch (Exception ex)
			{
				throw new ArgumentException(
					"Attempted to parse text in an unknown format (it's expected to be: year:image\ntext",
					nameof(driver),
					ex
				);
			}
		}
	}
}

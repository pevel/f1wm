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

		public static IEnumerable<DriverCareerPeriod> ParseCareerInfo(this Driver driver)
		{
			var career = new List<DriverCareerPeriod>();
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
							var yearsSplitted = headerLineSplitted[0].Split('-');
							int startYear = Int32.Parse(yearsSplitted[0]);
							int endYear =  Int32.Parse(yearsSplitted.Length > 1 ? yearsSplitted[1] : yearsSplitted[0]);
							var textLine = reader.ReadLine();
							career.Add(new DriverCareerPeriod()
							{
								StartYear = startYear,
								EndYear = endYear,
								Picture = headerLineSplitted[1].GetCareerImagePath(),
								Text = textLine
							});
						}
					}
				}
				return career.OrderByDescending(y => y.StartYear);
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

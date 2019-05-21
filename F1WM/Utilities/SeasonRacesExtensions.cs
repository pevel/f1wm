using System;
using System.Linq.Expressions;
using F1WM.DatabaseModel;
using F1WM.DomainModel;

namespace F1WM.Utilities
{
	public static class SeasonRacesExtensions
	{
		public static Expression<Func<Race, bool>> GetNextRaceFilter(this SeasonRaces season)
		{
			bool shouldSearchInThisSeason = season.LastRaceNumber != season.RaceCount;
			if (shouldSearchInThisSeason)
			{
				return r => r.SeasonId == season.Id && r.OrderInSeason == season.LastRaceNumber + 1;
			}
			else
			{
				return r => r.Season.Year == season.Year + 1 && r.OrderInSeason == 1;
			}
		}

		public static Expression<Func<Race, bool>> GetMostRecentRaceFilter(this SeasonRaces season)
		{
			bool shouldSearchInThisSeason = season.LastRaceNumber != 0;
			if (shouldSearchInThisSeason)
			{
				return r => r.SeasonId == season.Id && r.OrderInSeason == season.LastRaceNumber;
			}
			else
			{
				return r => r.Season.Year == season.Year - 1 && r.OrderInSeason == r.Season.RaceCount;
			}
		}
	}
}

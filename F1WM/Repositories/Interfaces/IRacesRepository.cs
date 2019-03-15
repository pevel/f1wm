using System;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface IRacesRepository
	{
		Task<NextRaceSummary> GetFirstRaceAfter(DateTime afterDate);
		Task<LastRaceSummary> GetMostRecentRaceBefore(DateTime beforeDate);
		Task<RaceFastestLaps> GetRaceFastestLaps(int raceId);
		Task<RaceNews> GetRaceNews(int raceId);
	}
}

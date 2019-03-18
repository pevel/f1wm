using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IRacesService
	{
		Task<NextRaceSummary> GetNextRace(DateTime? after = null);
		Task<LastRaceSummary> GetLastRace(DateTime? before = null);
		Task<RaceFastestLaps> GetRaceFastestLaps(int raceId);
		Task<RaceNews> GetRaceNews(int raceId);
	}
}

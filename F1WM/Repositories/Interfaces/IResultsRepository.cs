using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface IResultsRepository
	{
		Task<RaceResult> GetRaceResult(int raceId);
		Task<IEnumerable<RaceResultPosition>> GetShortRaceResult(int raceId);
		Task<QualifyingResult> GetQualifyingResult(int raceId);
	}
}
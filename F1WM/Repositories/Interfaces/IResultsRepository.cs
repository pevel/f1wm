using System;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface IResultsRepository
	{
		Task<RaceResult> GetRaceResult(int raceId);
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IResultsService
	{
		Task<RaceResult> GetRaceResult(int raceId);
		Task<OtherResult> GetOtherResult(int id);
		Task<PracticeResult> GetPracticeResult(int id);
		Task<QualifyingResult> GetQualifyingResult(int id);
	}
}
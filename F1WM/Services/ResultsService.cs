using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class ResultsService : IResultsService
	{
		private readonly IResultsRepository repository;

		public Task<OtherResult> GetOtherResult(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<PracticeResult> GetPracticeResult(int id)
		{
			throw new System.NotImplementedException();
		}

		public async Task<QualifyingResult> GetQualifyingResult(int raceId)
		{
			var result = await repository.GetQualifyingResult(raceId);
			if (result != null && result.Results != null)
			{
				result.Format = DetectQualifyingResultFormat(result);
			}
			return result;
		}

		public Task<RaceResult> GetRaceResult(int raceId)
		{
			return repository.GetRaceResult(raceId);
		}

		public ResultsService(IResultsRepository repository)
		{
			this.repository = repository;
		}

		private QualifyingResultFormat DetectQualifyingResultFormat(QualifyingResult result)
		{
			if (result.Results.Any(r => r.Session3 != null))
			{
				return QualifyingResultFormat.Combined123;
			}
			else if (result.Results.Any(r => r.Session1 != null && r.Session2 != null))
			{
				if (result.Results.All(r => r.Session2?.FinishPosition != 0))
				{
					return QualifyingResultFormat.CombinedSummed12;
				}
				else
				{
					return QualifyingResultFormat.Combined12;
				}
			}
			else if (result.Results.All(r => r.Session2 == null && r.Session3 == null))
			{
				return QualifyingResultFormat.Basic;
			}
			else
			{
				return QualifyingResultFormat.Unknown;
			}
		}
	}
}
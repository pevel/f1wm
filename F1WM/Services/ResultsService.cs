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

		public Task<QualifyingResult> GetQualifyingResult(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<RaceResult> GetRaceResult(int id)
		{
			return repository.GetRaceResult(id);
		}

		public ResultsService(IResultsRepository repository)
		{
			this.repository = repository;
		}
	}
}
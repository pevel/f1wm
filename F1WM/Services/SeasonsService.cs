using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class SeasonsService : ISeasonsService
	{
		private readonly ISeasonsRepository repository;
		private readonly ITimeService timeService;

		public async Task<SeasonRules> GetSeasonRules(int? year)
		{
			var seasonRules = await repository.GetSeasonRules(year.HasValue ? year.Value : timeService.Now.Year);

			if (seasonRules == null) return null;

			seasonRules.QualifyingRules = seasonRules.QualifyingRules.Replace("\r\n", "<br>");
			seasonRules.QualifyingRules = seasonRules.QualifyingRules.Replace("\r", "<br>");
			return seasonRules;
		}

		public SeasonsService(ISeasonsRepository repository, ITimeService timeService)
		{
			this.repository = repository;
			this.timeService = timeService;
		}
	}
}

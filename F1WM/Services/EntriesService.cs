using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class EntriesService : IEntriesService
	{
		private readonly IEntriesRepository repository;

		public Task<RaceEntriesInformation> GetRaceEntries(int raceId)
		{
			return repository.GetRaceEntries(raceId);
		}

		public Task<SeasonEntriesInformation> GetSeasonEntries(int year)
		{
			return repository.GetSeasonEntries(year);
		}

		public EntriesService(IEntriesRepository repository)
		{
			this.repository = repository;
		}
	}
}

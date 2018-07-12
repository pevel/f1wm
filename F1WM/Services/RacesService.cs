using System;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class RacesService : IRacesService
	{
		private IRacesRepository repository;

		public Task<NextRaceSummary> GetNextRace()
		{
			return repository.GetFirstRaceAfter(DateTime.Now);
		}

		public RacesService(IRacesRepository repository)
		{
			this.repository = repository;
		}
	}
}
using F1WM.ApiModel;
using F1WM.Repositories;
using System.Threading.Tasks;

namespace F1WM.Services
{
	public class DriversService : IDriversService
	{
		private readonly ITimeService time;
		private readonly IDriversRepository repository;

		public Task<Drivers> GetDrivers(char letter)
		{
			return repository.GetDrivers(letter);
		}

		public Task<DriverDetails> GetDriver(int id, int? atYear)
		{
			return repository.GetDriver(id, atYear ?? time.Now.Year);
		}

		public DriversService(IDriversRepository repository, ITimeService time)
		{
			this.time = time;
			this.repository = repository;
		}
	}
}


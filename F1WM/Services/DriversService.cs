using F1WM.ApiModel;
using F1WM.Repositories;
using System.Threading.Tasks;

namespace F1WM.Services
{
	public class DriversService : IDriversService
	{
		private readonly IDriversRepository repository;

		public Task<Drivers> GetDrivers(char letter)
		{
			return repository.GetDrivers(letter);
		}

		public Task<DriverDetails> GetDriver(int id)
		{
			return repository.GetDriver(id);
		}

		public DriversService(IDriversRepository repository)
		{
			this.repository = repository;
		}
	}
}


using F1WM.ApiModel;
using F1WM.Repositories;
using System.Threading.Tasks;

namespace F1WM.Services
{
	public class DriversService : IDriversService
	{
		private readonly IDriversRepository repository;

		public async Task<Drivers> GetDrivers(char letter)
		{
			var drivers = await repository.GetDrivers(letter);
			return drivers;
		}

		public DriversService(IDriversRepository repository)
		{
			this.repository = repository;
		}
	}
}


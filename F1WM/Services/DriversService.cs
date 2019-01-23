using F1WM.ApiModel;
using F1WM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.Services
{
	public class DriversService : IDriversService
	{
		private readonly IDriversRepository repository;
	
		public async Task<DriversList> GetDrivers(string letter)
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
}

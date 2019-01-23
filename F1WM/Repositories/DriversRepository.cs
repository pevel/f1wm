using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.Repositories
{
	public class DriversRepository : RepositoryBase, IDriversRepository
	{
		private readonly IMapper mapper;

		public async Task<Drivers> GetDrivers(string letter)
		{
			await SetDbEncoding();

			Drivers result = new Drivers();

			result.DriversList = await mapper.ProjectTo<DriverSummary>(
				context.Drivers
				.Where(d => d.Litera == letter)
				.OrderBy(d => d.Surname))
				.ToListAsync();

			if (result.DriversList.Any())
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		public DriversRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class RacesRepository : RepositoryBase, IRacesRepository
	{
		private IMapper mapper;

		public async Task<NextRaceSummary> GetFirstRaceAfter(DateTime afterDate)
		{
			var dbNextRace = await context.Races
				.OrderBy(r => r.Date)
				.Include(r => r.Track)
				.Include(r => r.Country)
				.FirstOrDefaultAsync(r => r.Date > afterDate);
			return mapper.Map<NextRaceSummary>(dbNextRace);
		}

		public RacesRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}
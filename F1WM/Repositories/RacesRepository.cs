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
			var apiNextRace = mapper.Map<NextRaceSummary>(dbNextRace);
			var dbLastPolePositionResult = await context.Grids
				.Include(g => g.Race)
				.Where(g => g.Race.TrackId == dbNextRace.TrackId && g.Race.Date < dbNextRace.Date && g.StartingPosition == "1")
				.Include(g => g.Entry)
				.ThenInclude(e => e.Driver)
				.ThenInclude(d => d.Nationality)
				.OrderByDescending(g => g.Race.Date)
				.FirstAsync();
			apiNextRace.LastPolePositionLapResult = mapper.Map<LapResultSummary>(dbLastPolePositionResult.Entry);
			var dbLastWinnerResult = await context.Results
				.Include(r => r.Race)
				.Where(r => r.Race.TrackId == dbNextRace.TrackId && r.Race.Date < dbNextRace.Date && r.FinishPosition == "1")
				.Include(r => r.Entry)
				.ThenInclude(e => e.Driver)
				.ThenInclude(d => d.Nationality)
				.OrderByDescending(r => r.Race.Date)
				.FirstAsync();
			apiNextRace.LastWinnerRaceResult = mapper.Map<RaceResultSummary>(dbLastWinnerResult.Entry);
			return apiNextRace;
		}

		public RacesRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}
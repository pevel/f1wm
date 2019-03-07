using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class EntriesRepository : RepositoryBase, IEntriesRepository
	{
		private readonly IMapper mapper;

		public async Task<RaceEntriesInformation> GetRaceEntries(int raceId)
		{
			var apiEntries = new RaceEntriesInformation() { RaceId = raceId };
			var dbEntries = context.Entries
				.Where(e => e.RaceId == raceId)
				.OrderBy(e => e.IsThirdDriver).ThenBy(e => e.Number);
			apiEntries.Entries = await mapper.ProjectTo<RaceEntry>(dbEntries).ToListAsync();
			return apiEntries.Entries.Any() ? apiEntries : null;
		}

		public async Task<SeasonEntriesInformation> GetSeasonEntries(int year)
		{
			var apiEntries = new SeasonEntriesInformation() { SeasonYear = year };
			var entries = await mapper.ProjectTo<SeasonEntry>(context.Entries
					.Where(e => e.Race.Season.Year == year))
				.GroupBy(e => e.Driver.Id)
				.Select(g => g.First())
				.OrderBy(e => e.IsThirdDriver).ThenBy(e => e.Number)
				.ToListAsync();
			apiEntries.Entries = entries;
			return apiEntries.Entries.Any() ? apiEntries : null;
		}

		public EntriesRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

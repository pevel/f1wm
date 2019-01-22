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
				.Include(e => e.Driver).ThenInclude(d => d.Nationality)
				.Include(e => e.Car).ThenInclude(c => c.Constructor)
				.Where(e => e.RaceId == raceId);
			apiEntries.Entries = await mapper.ProjectTo<RaceEntry>(dbEntries).ToListAsync();
			return apiEntries;
		}

		public EntriesRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

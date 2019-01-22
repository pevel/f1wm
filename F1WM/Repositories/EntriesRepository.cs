using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public class EntriesRepository : RepositoryBase, IEntriesRepository
	{
		private readonly IMapper mapper;

		public Task<RaceEntriesInformation> GetRaceEntries(int raceId)
		{
			throw new System.NotImplementedException();
		}

		public EntriesRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

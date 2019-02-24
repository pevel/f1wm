using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class EnginesRepository: RepositoryBase, IEnginesRepository
	{
		private readonly IMapper mapper;

		public async Task<Engines> GetEngines(char letter)
		{
			Engines result = new Engines();

			result.EnginesList = await mapper.ProjectTo<EngineSummary>(
				context.Engines
					.Where(d => d.Letter == letter.ToString())
					.OrderBy(d => d.Name))
				.ToListAsync();

			return (result.EnginesList.Any()) ? result : null;
		}

		public async Task<EngineDetails> GetEngine(int id)
		{
			var apiEngine = await mapper.ProjectTo<EngineDetails>(context.Engines
					.Where(e => e.Id == id))
				.SingleOrDefaultAsync();
			if (apiEngine != null)
			{
				await IncludeRacesInfo(id, apiEngine);
			}
			return apiEngine;
		}

		public EnginesRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		private async Task IncludeRacesInfo(int id, EngineDetails apiEngine)
		{
			apiEngine.FirstStartAt = await mapper.ProjectTo<RaceSummary>(context.Grids
					.Where(g => g.Entry.EngineId == id)
					.OrderBy(g => g.Race.Date)
					.Select(g => g.Race))
				.FirstOrDefaultAsync();
			apiEngine.FirstWinAt = await mapper.ProjectTo<RaceSummary>(context.Entries
					.Where(e => e.Result.PositionOrStatus == "1")
					.Where(e => e.EngineId == id)
					.OrderBy(e => e.Race.Date)
					.Select(e => e.Race))
				.FirstOrDefaultAsync();
		}
	}
}

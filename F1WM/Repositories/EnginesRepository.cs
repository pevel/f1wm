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

		public Task<EngineDetails> GetEngine(int id)
		{
			return mapper.ProjectTo<EngineDetails>(context.Engines
					.Where(e => e.Id == id))
				.SingleOrDefaultAsync();
		}

		public EnginesRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

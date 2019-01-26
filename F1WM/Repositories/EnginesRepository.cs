using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.ApiModel.Engines;
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

			result.EnginesList = 
				context.Engines
					.Where(d => d.Letter == letter.ToString())
					.OrderBy(d => d.Name)
				.AsEnumerable();

			return (result.EnginesList.Any()) ? result : null;
		}

		public EnginesRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

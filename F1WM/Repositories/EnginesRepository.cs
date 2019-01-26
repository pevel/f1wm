using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel.Engines;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class EnginesRepository: RepositoryBase, IEnginesRepository
	{
		public async Task<Engines> GetEngines(char letter)
		{
			Engines result = new Engines();

			 result.EnginesList = 
				await context.Engines
					.Where(d => d.Letter == letter.ToString())
					.OrderBy(d => d.Name)
				.ToListAsync();

			return (result.EnginesList.Any()) ? result : null;
		}

		public EnginesRepository(F1WMContext context)
		{
			this.context = context;
		}
	}
}

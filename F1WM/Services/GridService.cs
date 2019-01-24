using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class GridsService : IGridsService
	{
		private readonly IGridsRepository repository;

		public Task<GridInformation> GetGrid(int raceId)
		{
			return repository.GetGrid(raceId);
		}

		public GridsService(IGridsRepository repository)
		{
			this.repository = repository;
		}
	}
}

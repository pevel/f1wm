using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public interface IGridsRepository
	{
		Task<GridInformation> GetGrid(int raceId);
	}
}

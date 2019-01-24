using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IGridsService
	{
		Task<GridInformation> GetGrid(int raceId);
	}
}

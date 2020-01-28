using F1WM.ApiModel;
using F1WM.Repositories;
using System.Threading.Tasks;

namespace F1WM.Services
{
	public interface IDriversService : ISearching<DriverSummary>
	{
		Task<Drivers> GetDrivers(char letter);
		Task<DriverDetails> GetDriver(int id, int? atYear);
	}
}

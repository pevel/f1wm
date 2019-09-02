using F1WM.ApiModel;
using System.Threading.Tasks;

namespace F1WM.Repositories
{
	public interface IDriversRepository : ISearching<DriverSummary>
	{
		Task<Drivers> GetDrivers(char letter);
		Task<DriverDetails> GetDriver(int id, int atYear);
	}
}

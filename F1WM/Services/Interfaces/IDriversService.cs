using F1WM.ApiModel;
using System.Threading.Tasks;

namespace F1WM.Services
{
	public interface IDriversService
	{
		Task<Drivers> GetDrivers(char letter);
		Task<DriverDetails> GetDriver(int id);
	}
}

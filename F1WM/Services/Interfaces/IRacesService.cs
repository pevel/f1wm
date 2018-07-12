using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IRacesService
	{
		Task<NextRaceSummary> GetNextRace();
	}
}
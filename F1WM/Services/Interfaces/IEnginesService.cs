using System.Threading.Tasks;
using F1WM.ApiModel.Engines;

namespace F1WM.Services
{
	public interface IEnginesService
	{
		Task<Engines> GetEngines(char letter);
	}
}

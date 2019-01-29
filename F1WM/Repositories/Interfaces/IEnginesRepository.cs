using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface IEnginesRepository
	{
		Task<Engines> GetEngines(char letter);
	}
}

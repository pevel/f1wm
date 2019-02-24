using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IEnginesService
	{
		Task<Engines> GetEngines(char letter);
		Task<EngineDetails> GetEngine(int id);
	}
}

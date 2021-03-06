using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class EnginesService : IEnginesService
	{
		private readonly IEnginesRepository repository;

		public Task<Engines> GetEngines(char letter)
		{
			return repository.GetEngines(letter);
		}

		public Task<EngineDetails> GetEngine(int id)
		{
			return repository.GetEngine(id);
		}

		public EnginesService(IEnginesRepository repository)
		{
			this.repository = repository;
		}
	}
}

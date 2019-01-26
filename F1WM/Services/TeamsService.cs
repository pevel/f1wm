using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class TeamsService : ITeamsService
	{
		private readonly ITeamsRepository repository;

		public Task<TeamDetails> GetTeam(int id)
		{
			return repository.GetTeam(id);
		}

		public TeamsService(ITeamsRepository repository)
		{
			this.repository = repository;
		}
	}
}

using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public class TeamsRepository : RepositoryBase, ITeamsRepository
	{
		private readonly IMapper mapper;

		public Task<TeamDetails> GetTeam(int id)
		{
			throw new System.NotImplementedException();
		}

		public TeamsRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
		}
	}
}

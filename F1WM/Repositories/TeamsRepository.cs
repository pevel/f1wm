using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class TeamsRepository : RepositoryBase, ITeamsRepository
	{
		private readonly IMapper mapper;

		public async Task<TeamDetails> GetTeam(int id)
		{
			return await mapper.ProjectTo<TeamDetails>(context.Teams
					.Where(t => t.Id == id))
				.FirstOrDefaultAsync();
		}

		public TeamsRepository(F1WMContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
		}
	}
}

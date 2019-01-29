using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Repositories
{
	public interface ITeamsRepository
	{
		Task<TeamDetails> GetTeam(int id);
	}
}

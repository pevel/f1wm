using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface ITeamsService
	{
		Task<TeamDetails> GetTeam(int id);
	}
}

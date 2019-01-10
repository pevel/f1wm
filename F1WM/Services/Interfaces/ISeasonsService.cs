using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface ISeasonsService
	{
		Task<SeasonRules> GetSeasonRules(int? year);
	}
}

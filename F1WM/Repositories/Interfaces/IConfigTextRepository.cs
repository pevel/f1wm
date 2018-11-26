using System.Threading.Tasks;
using F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public interface IConfigTextRepository
	{
		Task<ConfigText> GetConfigText(string name);
	}
}
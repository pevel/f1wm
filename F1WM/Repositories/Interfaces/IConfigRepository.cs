using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public interface IConfigRepository
	{
		Task<ConfigText> GetConfigText(string name);
		Task<IEnumerable<ConfigText>> GetConfigTexts(ICollection<string> names);
		Task<IEnumerable<ConfigText>> AddConfigTexts(string sectionName, IEnumerable<ConfigText> configs);
	}
}

using System.Data;
using System.Threading.Tasks;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public abstract class RepositoryBase
	{
		protected F1WMContext context;
	}
}

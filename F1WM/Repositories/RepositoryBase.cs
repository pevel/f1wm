using System.Data;
using System.Threading.Tasks;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public abstract class RepositoryBase
	{
		protected F1WMContext context;

		protected async Task SetDbEncoding()
		{
			context.Database.OpenConnection();
			var connection = context.Database.GetDbConnection();
			var command = connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "SET NAMES utf8mb4; ";
			await command.ExecuteNonQueryAsync();
		}
	}
}
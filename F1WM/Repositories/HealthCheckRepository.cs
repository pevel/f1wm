using System.Data;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class HealthCheckRepository : RepositoryBase, IHealthCheckRepository
	{
		public ConnectionState GetConnectionState()
		{
			context.Database.OpenConnection();
			var state = context.Database.GetDbConnection().State;
			context.Database.CloseConnection();
			return state;
		}

		public void CloseConnection()
		{
			context.Database.CloseConnection();
		}

		public HealthCheckRepository(F1WMContext context)
		{
			this.context = context;
		}
	}
}
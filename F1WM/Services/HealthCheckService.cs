using System;
using System.Data;
using F1WM.Utilities;

namespace F1WM.Services
{
	public class HealthCheckService : IHealthCheckService
	{
		private IDbContext db;

		public string GetDatabaseStatus()
		{
			try
			{
				db.Connection.Open();
				var state = db.Connection.State;
				db.Connection.Close();
				return state == ConnectionState.Open ? "OK" : $"Not totally OK. Connection state: {state.ToString()}";
			}
			catch (Exception ex)
			{
				return $"Down. Error: {ex.Message}";
			}
			finally
			{
				if (db.Connection.State == ConnectionState.Open)
				{
					db.Connection.Close();
				}
			}
		}

		public HealthCheckService(IDbContext db)
		{
			this.db = db;
		}
	}
}
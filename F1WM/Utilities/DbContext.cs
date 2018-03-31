using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace F1WM.Utilities
{
	public class DbContext : IDbContext, IDisposable
	{
		public IDbConnection Connection { get; }

		public DbContext(string connectionString)
		{
			Connection = new MySqlConnection(connectionString);
		}

		public void Dispose()
		{
			Connection.Dispose();
		}
	}
}
using System;
using MySql.Data.MySqlClient;

namespace F1WM.Utilities
{
	public class DbContext : IDbContext, IDisposable
	{
		public MySqlConnection Connection { get; }

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
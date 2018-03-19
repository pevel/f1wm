using System;
using MySql.Data.MySqlClient;

namespace F1WM.Utilities
{
	public class DbContext : IDisposable
	{
		public readonly MySqlConnection Connection;

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
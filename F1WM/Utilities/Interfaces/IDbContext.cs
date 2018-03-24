using MySql.Data.MySqlClient;

namespace F1WM.Utilities
{
	public interface IDbContext
	{
		MySqlConnection Connection { get; }
	}
}
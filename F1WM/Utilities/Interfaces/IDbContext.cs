using System.Data;

namespace F1WM.Utilities
{
	public interface IDbContext
	{
		IDbConnection Connection { get; }
	}
}
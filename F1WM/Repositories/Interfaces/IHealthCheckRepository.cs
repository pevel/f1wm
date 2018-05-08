using System.Data;

namespace F1WM.Repositories
{
	public interface IHealthCheckRepository
	{
		ConnectionState GetConnectionState();
		void CloseConnection();
	}
}
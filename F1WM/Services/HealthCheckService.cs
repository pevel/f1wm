using System;
using System.Data;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class HealthCheckService : IHealthCheckService
	{
		private readonly IHealthCheckRepository repository;

		public string GetDatabaseStatus()
		{
			try
			{
				var state = repository.GetConnectionState();
				return state == ConnectionState.Open ? "OK" : $"Not totally OK. Connection state: {state.ToString()}";
			}
			catch (Exception ex)
			{
				return $"Down. Error: {ex.Message}";
			}
			finally
			{
				repository.CloseConnection();
			}
		}

		public HealthCheckService(IHealthCheckRepository repository)
		{
			this.repository = repository;
		}
	}
}
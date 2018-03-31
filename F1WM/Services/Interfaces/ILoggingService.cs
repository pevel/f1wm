using System;

namespace F1WM.Services
{
	public interface ILoggingService
	{
		void LogError(Exception ex);
	}
}
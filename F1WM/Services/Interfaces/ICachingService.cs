using System;

namespace F1WM.Services
{
	public interface ICachingService
	{
		T Get<T>(string key);
		T TryGetCacheValue<T>(string key) where T : class;
		void Set<T>(string key, T value, TimeSpan timeSpan);
		void DisposeCache();
	}
}

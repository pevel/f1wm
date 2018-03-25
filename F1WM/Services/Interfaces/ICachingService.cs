using System;
using Microsoft.Extensions.Caching.Memory;

namespace F1WM.Services
{
	public interface ICachingService
	{
		T Get<T>(string key);
		T Set<T>(string key, T value, MemoryCacheEntryOptions options);
	}
}
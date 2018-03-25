using System;
using Microsoft.Extensions.Caching.Memory;

namespace F1WM.Services
{
	public class CachingService : ICachingService
	{
		private IMemoryCache cache;

		public T Get<T>(string key)
		{
			return cache.Get<T>(key);
		}

		public T Set<T>(string key, T value, MemoryCacheEntryOptions options)
		{
			return cache.Set<T>(key, value, options);
		}

		public CachingService(IMemoryCache cache)
		{
			this.cache = cache;
		}
	}
}
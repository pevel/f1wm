using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading;

namespace F1WM.Services
{
	public class CachingService : ICachingService
	{
		private readonly IMemoryCache cache;
		private static CancellationTokenSource _resetCacheToken = new CancellationTokenSource();

		public T Get<T>(string key)
		{
			return cache.Get<T>(key);
		}

		public T TryGetCacheValue<T>(string key) where T : class
		{
			if (cache.TryGetValue(key, out T cacheValue))
			{
				return cacheValue;
			}
			return null;
		}

		public void Set<T>(string key, T value, TimeSpan absoluteExpirationRelativeToNow)
		{
			var options = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.Normal).SetSize(1).SetAbsoluteExpiration(absoluteExpirationRelativeToNow);
			options.AddExpirationToken(new CancellationChangeToken(_resetCacheToken.Token));
			cache.Set<T>(key, value, options);
		}

		public void DisposeCache()
		{
			if (_resetCacheToken != null && !_resetCacheToken.IsCancellationRequested && _resetCacheToken.Token.CanBeCanceled)
			{
				_resetCacheToken.Cancel();
				_resetCacheToken.Dispose();
			}

			_resetCacheToken = new CancellationTokenSource();
		}

		public CachingService(IMemoryCache cache)
		{
			this.cache = cache;
		}
	}
}

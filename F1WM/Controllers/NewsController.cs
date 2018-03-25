using System;
using System.Collections.Generic;
using F1WM.Model;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class NewsController : Controller
	{
		private const int defaultLatestNewsCount = 20;
		private readonly TimeSpan cacheExpiration = TimeSpan.FromHours(1);

		private INewsService service;
		private ICachingService cache;

		[HttpGet]
		public IEnumerable<NewsSummary> GetMany(
			[FromQuery(Name = "firstId")] int? firstId,
			[FromQuery(Name = "count")] int count = defaultLatestNewsCount)
		{
			var cacheKey = GetNewsSummaryCacheKey(firstId, count);
			var cacheEntry = cache.Get<IEnumerable<NewsSummary>>(cacheKey);
			if (cacheEntry != null)
			{
				return cacheEntry;
			}
			else
			{
				var news = service.GetLatestNews(count, firstId);
				var options = new MemoryCacheEntryOptions().SetSlidingExpiration(cacheExpiration);
				cache.Set(cacheKey, news, options);
				return news;
			}
		}

		[HttpGet("{id}")]
		public NewsDetails GetSingle(int id)
		{
			var cacheKey = GetNewsDetailsCacheKey(id);
			var cacheEntry = cache.Get<NewsDetails>(cacheKey);
			if (cacheEntry != null)
			{
				return cacheEntry;
			}
			else
			{
				var news = service.GetNewsDetails(id);
				var options = new MemoryCacheEntryOptions().SetSlidingExpiration(cacheExpiration);
				cache.Set(cacheKey, news, options);
				return news;
			}
		}

		public NewsController(INewsService service, ICachingService cache)
		{
			this.service = service;
			this.cache = cache;
		}

		private string GetNewsSummaryCacheKey(int? firstId, int count)
		{
			return $"{nameof(NewsController)}.{nameof(GetMany)}:{nameof(firstId)}={firstId},{nameof(count)}={count}";
		}

		private string GetNewsDetailsCacheKey(int id)
		{
			return $"{nameof(NewsController)}.{nameof(GetSingle)}:{nameof(id)}={id}";
		}
	}
}
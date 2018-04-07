using System;
using System.Collections.Generic;
using F1WM.Model;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class NewsController : ControllerBase
	{
		private const int defaultLatestNewsCount = 20;
		private readonly TimeSpan cacheExpiration = TimeSpan.FromHours(1);

		private INewsService service;
		private ICachingService cache;
		private ILoggingService logger;

		[HttpGet]
		public IEnumerable<NewsSummary> GetMany(
			[FromQuery(Name = "firstId")] int? firstId = null,
			[FromQuery(Name = "count")] int count = defaultLatestNewsCount)
		{
			try
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
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetSingle(int id)
		{
			try
			{
				var cacheKey = GetNewsDetailsCacheKey(id);
				var cacheEntry = cache.Get<NewsDetails>(cacheKey);
				if (cacheEntry != null)
				{
					return Ok(cacheEntry);
				}
				else
				{
					var news = service.GetNewsDetails(id);
					IActionResult result;
					if (news != null)
					{
						var options = new MemoryCacheEntryOptions().SetSlidingExpiration(cacheExpiration);
						cache.Set(cacheKey, news, options);
						result = Ok(news);
					}
					else
					{
						result = NotFound();
					}
					return result;
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}

		}

		public NewsController(INewsService service, ICachingService cache, ILoggingService logger)
		{
			this.service = service;
			this.cache = cache;
			this.logger = logger;
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
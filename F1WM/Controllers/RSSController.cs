using System;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class RSSController : ControllerBase
	{
		private const string rssContentType = "application/xml";
		private const string rssCacheKey = "rssFeed";
		private readonly IRSSService rssService;
		private readonly ICachingService cache;

		[HttpGet]
		[Produces(rssContentType)]
		[ProducesResponseType(200)]
		public async Task<Rss20FeedFormatter> GetFeed([FromQuery] int? firstId = null)
		{
			Response.ContentType = rssContentType;
			var shouldUseCache = !firstId.HasValue;
			SyndicationFeed feed = shouldUseCache ? this.cache.Get<SyndicationFeed>(rssCacheKey) : null;
			if (feed == null)
			{
				feed = await rssService.GetFeed(firstId);
				if (shouldUseCache)
				{
					this.cache.Set(rssCacheKey, feed, GetMemoryCacheExpiration());
				}
			}
			return new Rss20FeedFormatter(feed);
		}

		[HttpPut("configuration")]
		[Authorize]
		[ProducesResponseType(200)]
		[ProducesResponseType(401)]
		public async Task<ActionResult<RSSFeedConfiguration>> UpdateConfiguration(
			[FromBody] RSSFeedConfigurationEditRequest request)
		{
			var configuration = await rssService.UpdateOrAddConfiguration(request);
			return Ok(configuration);
		}

		public RSSController(IRSSService rssService, ICachingService cache)
		{
			this.rssService = rssService;
			this.cache = cache;
		}

		private TimeSpan GetMemoryCacheExpiration()
		{
			return TimeSpan.FromMinutes(5);
		}
	}
}

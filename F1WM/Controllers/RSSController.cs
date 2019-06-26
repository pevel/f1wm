using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class RSSController : ControllerBase
	{
		private const string rssContentType = "application/xml";
		private const string rssCacheKey = "rssFeed";
		private readonly IRSSService rssService;

		[HttpGet]
		[ResponseCache(Duration = 60 * 5)]
		[Produces(rssContentType)]
		[ProducesResponseType(200)]
		public async Task<Rss20FeedFormatter> GetFeed([FromQuery]DateTime? before = null)
		{
			Response.ContentType = rssContentType;
			var feed = await rssService.GetFeed(before);
			return new Rss20FeedFormatter(feed);
		}

		public RSSController(IRSSService rssService)
		{
			this.rssService = rssService;
		}
	}
}

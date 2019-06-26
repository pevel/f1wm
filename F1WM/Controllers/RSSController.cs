using System;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
		public async Task<Rss20FeedFormatter> GetFeed([FromQuery] DateTime? before = null)
		{
			Response.ContentType = rssContentType;
			var feed = await rssService.GetFeed(before);
			return new Rss20FeedFormatter(feed);
		}

		[HttpPost("configuration")]
		[Authorize]
		[ProducesResponseType(201)]
		[ProducesResponseType(401)]
		public async Task<ActionResult<RSSFeedConfiguration>> AddConfiguration(
			[FromBody] RSSFeedConfigurationAddRequest request)
		{
			var configuration = await rssService.AddConfiguration(request);
			return CreatedAtAction(nameof(AddConfiguration), configuration);
		}

		public RSSController(IRSSService rssService)
		{
			this.rssService = rssService;
		}
	}
}

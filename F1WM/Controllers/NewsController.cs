using System.Collections.Generic;
using F1WM.Model;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class NewsController : Controller
	{
		private const int defaultLatestNewsCount = 20;
		private INewsService service;

		[HttpGet]
		public IEnumerable<NewsSummary> Get(
			[FromQuery(Name = "firstId")] int? firstId,
			[FromQuery(Name = "count")] int count = defaultLatestNewsCount)
		{
			return this.service.GetLatestNews(count, firstId);
		}

		[HttpGet("{id}")]
		public NewsDetails Get(int id)
		{
			return this.service.GetNewsDetails(id);
		}

		public NewsController(INewsService service)
		{
			this.service = service;
		}
	}
}
using System.Collections.Generic;
using F1WM.Model;
using F1WM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class NewsController : Controller
	{
		private INewsRepository repository;

		[HttpGet]
		public IEnumerable<NewsSummary> Get([FromQuery(Name = "firstId")] int? firstId, [FromQuery(Name = "count")] int? count = Constants.NewsCount)
		{
			return this.repository.GetLatestNews(firstId, count);
		}

		[HttpGet("{id}")]
		public NewsDetails Get(int id)
		{
			return null;
		}

		public NewsController(INewsRepository repository)
		{
			this.repository = repository;
		}
	}
}
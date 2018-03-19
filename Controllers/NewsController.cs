using System.Collections.Generic;
using F1WM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class NewsController : Controller
	{
		private INewsRepository repository;

		[HttpGet]
		public IEnumerable<string> Get()
		{
			return this.repository.GetNews();
		}

		public NewsController(INewsRepository repository)
		{
			this.repository = repository;
		}
	}
}

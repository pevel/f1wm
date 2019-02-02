using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class NewsController : ControllerBase
	{
		private const int defaultPage = 1;
		private const int defaultCountPerPage = 20;

		private readonly INewsService service;

		[HttpGet]
		public async Task<NewsSummaryPaged> GetManyNews(
					[FromQuery(Name = "firstId")] int? firstId = null,
					[FromQuery(Name = "tagId")] int? tagId = null,
					[FromQuery(Name = "typeId")] int? typeId = null,
					[FromQuery(Name = "page")] uint page = defaultPage,
					[FromQuery(Name = "countPerPage")] uint countPerPage = defaultCountPerPage)
		{
			if (tagId != null)
				return await service.GetNewsByTagId((int)tagId, page, countPerPage);
			else if (typeId != null)
				return await service.GetNewsByTypeId((int)typeId, page, countPerPage);
			else
				return await service.GetLatestNews(firstId, page, countPerPage);
		}


		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<NewsDetails>> GetSingle(int id)
		{
			var news = await service.GetNewsDetails(id);
			return this.NotFoundResultIfNull(news);
		}

		[HttpGet("types")]
		public async Task<IEnumerable<NewsType>> GetTypes()
		{
			return await service.GetNewsTypes();
		}

		[HttpGet("tags")]
		public async Task<NewsTagsPaged> GetTags(
			[FromQuery(Name = "categoryId")] int? id = null,
			[FromQuery(Name = "page")] uint page = defaultPage,
			[FromQuery(Name = "countPerPage")] uint countPerPage = defaultCountPerPage)
		{
			if (id != null)
				return await service.GetNewsTagsByCategoryId((int)id, page, countPerPage);
			else
				return await service.GetNewsTags(page, countPerPage);
		}

		[HttpGet("categories")]
		public async Task<IEnumerable<NewsTagCategory>> GetTagCategories()
		{
			return await service.GetNewsTagCategories();
		}

		[HttpGet("important")]
		public async Task<IEnumerable<ImportantNewsSummary>> GetImportantNews()
		{
			return await service.GetImportantNews();
		}

		[HttpPost("{id}/views/increment")]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public async Task<ActionResult> IncrementViews(int id)
		{
			return (await service.IncrementViews(id)) ? (ActionResult)NoContent() : (ActionResult)NotFound();
		}

		public NewsController(INewsService service)
		{
			this.service = service;
		}
	}
}

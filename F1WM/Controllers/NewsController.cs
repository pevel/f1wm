using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
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
		private readonly ILoggingService logger;

		[HttpGet]
		public async Task<NewsSummaryPaged> GetManyNews(
					[FromQuery(Name = "firstId")] int? firstId = null,
					[FromQuery(Name = "tagId")] int? tagId = null,
					[FromQuery(Name = "typeId")] int? typeId = null,
					[FromQuery(Name = "page")] int page = defaultPage,
					[FromQuery(Name = "countPerPage")] int countPerPage = defaultCountPerPage)
		{
			try
			{
				if (tagId != null)
					return await service.GetNewsByTagId((int)tagId, page, countPerPage);
				else if (typeId != null)
					return await service.GetNewsByTypeId((int)typeId, page, countPerPage);
				else
					return await service.GetLatestNews(firstId, page, countPerPage);

			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}


		[HttpGet("{id}")]
		[Produces("application/json", Type = typeof(NewsDetails))]
		public async Task<IActionResult> GetSingle(int id)
		{
			try
			{
				var news = await service.GetNewsDetails(id);
				return (news != null ? (IActionResult)Ok(news) : (IActionResult)NotFound());
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("types")]
		public async Task<IEnumerable<NewsType>> GetTypes()
		{
			try
			{
				return await service.GetNewsTypes();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("tags")]
		public async Task<NewsTagsPaged> GetTags(
			[FromQuery(Name = "categoryId")] int? id = null,
			[FromQuery(Name = "page")] int page = defaultPage,
			[FromQuery(Name = "countPerPage")] int countPerPage = defaultCountPerPage)
		{
			try
			{
				if (id != null)
					return await service.GetNewsTagsByCategoryId((int)id, page, countPerPage);
				else
					return await service.GetNewsTags(page, countPerPage);

			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("categories")]
		public async Task<IEnumerable<NewsTagCategory>> GetTagCategories()
		{
			try
			{
				return await service.GetNewsTagCategories();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("important")]
		public async Task<IEnumerable<ImportantNewsSummary>> GetImportantNews()
		{
			try
			{
				return await service.GetImportantNews();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpPost("{id}/views/increment")]
		public async Task<IActionResult> IncremetViews(int id)
		{
			try
			{
				if (await service.IncrementViews(id))
				{
					return Ok();
				}
				else
				{
					return NotFound();
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public NewsController(INewsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}

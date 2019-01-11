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
		private const int defaultLatestNewsCount = 20;

		private readonly INewsService service;
		private readonly ILoggingService logger;

		[HttpGet]
		public async Task<IEnumerable<NewsSummary>> GetMany(
			[FromQuery(Name = "firstId")] int? firstId = null, [FromQuery(Name = "count")] int count = defaultLatestNewsCount)
		{
			try
			{
				return await service.GetLatestNews(count, firstId);
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

        [HttpGet("tag/{id}")]
        [Produces("application/json", Type = typeof(NewsSummary))]
        public async Task<IActionResult> GetByTag(int id)
        {
            try
            {
                var news = await service.GetNewsByTag(id);
                return (news.Any() ? (IActionResult)Ok(news) : (IActionResult)NotFound());
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                throw ex;
            }
        }

        [HttpGet("type/{id}")]
        [Produces("application/json", Type = typeof(NewsSummary))]
        public async Task<IActionResult> GetByType(int id)
        {
            try
            {
                var news = await service.GetNewsByType(id);
                return (news.Any() ? (IActionResult)Ok(news) : (IActionResult)NotFound());
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                throw ex;
            }
        }

        [HttpGet("types")]
        [Produces("application/json", Type = typeof(NewsType))]
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
        [Produces("application/json", Type = typeof(NewsTag))]
        public async Task<IEnumerable<NewsTag>> GetTags()
        {
            try
            {
                return await service.GetNewsTags();
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                throw ex;
            }
        }

        [HttpGet("tags/category/{id}")]
        [Produces("application/json", Type = typeof(NewsTag))]
        public async Task<IActionResult> GetTagsbyCategory(int id)
        {
            try
            {
                var tags = await service.GetNewsTagsByCategory(id);
                return (tags.Any() ? (IActionResult)Ok(tags) : (IActionResult)NotFound());
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                throw ex;
            }
        }

        [HttpGet("categories")]
        [Produces("application/json", Type = typeof(NewsCategory))]
        public async Task<IEnumerable<NewsCategory>> GetCategories()
        {
            try
            {
                return await service.GetNewsCategories();
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

		public NewsController(INewsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}
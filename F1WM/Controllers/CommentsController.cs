using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class CommentsController : ControllerBase
	{
		private readonly ICommentsService service;
		private readonly ILoggingService logger;

		[HttpGet]
		[ProducesResponseType(200)]
		public async Task<IEnumerable<Comment>> GetMany([FromQuery(Name = "newsId")] int newsId)
		{
			try
			{
				return await service.GetCommentsByNewsId(newsId);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("{id}")]
		[Produces("application/json", Type = typeof(Comment))]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetSingle(int id)
		{
			try
			{
				var comment = await service.GetComment(id);
				return this.NotFoundResultIfNull(comment);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public CommentsController(ICommentsService service, ILoggingService logger)
		{
			this.service = service;
			this.logger = logger;
		}
	}
}

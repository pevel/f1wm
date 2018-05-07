using System;
using System.Collections.Generic;
using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class CommentsController : ControllerBase
	{
		private ICommentsService service;
		private ILoggingService logger;

		[HttpGet]
		public IEnumerable<Comment> GetMany([FromQuery(Name = "newsId")] int newsId)
		{
			try
			{
				return service.GetCommentsByNewsId(newsId);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		[HttpGet("{id}")]
		[Produces("application/json", Type = typeof(Comment))]
		public IActionResult GetSingle(int id)
		{
			try
			{
				var comment = service.GetComment(id);
				IActionResult result;
				if (comment != null)
				{
					result = Ok(comment);
				}
				else
				{
					result = NotFound();
				}
				return result;
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
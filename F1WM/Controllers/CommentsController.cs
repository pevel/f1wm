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

		[HttpGet]
		public async Task<IEnumerable<Comment>> GetMany(
			[FromQuery(Name = "newsId")] int newsId)
		{
			return await service.GetCommentsByNewsId(newsId);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<Comment>> GetSingle(int id)
		{
			var comment = await service.GetComment(id);
			return this.NotFoundResultIfNull(comment);
		}

		public CommentsController(ICommentsService service)
		{
			this.service = service;
		}
	}
}

using System.Threading.Tasks;
using F1WM.Controllers;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Controllers
{
	public class CommentsControllerTests
	{
		private CommentsController controller;
		private Mock<ICommentsService> serviceMock;
		private Mock<ILoggingService> loggerMock;

		public CommentsControllerTests()
		{
			serviceMock = new Mock<ICommentsService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new CommentsController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnCommentsByNewsId()
		{
			var newsId = 42;

			await controller.GetMany(newsId);

			serviceMock.Verify(s => s.GetCommentsByNewsId(newsId), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnSingleComment()
		{
			var id = 43;

			await controller.GetSingle(id);

			serviceMock.Verify(s => s.GetComment(id), Times.Once);
		}

		[Fact]
		public async Task ShouldReturn404IfSingleCommentNotFound()
		{
			var id = 44;
			serviceMock.Setup(s => s.GetComment(id)).ReturnsAsync(() => null);

			var result = await controller.GetSingle(id);

			serviceMock.Verify(s => s.GetComment(id), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}
	}
}
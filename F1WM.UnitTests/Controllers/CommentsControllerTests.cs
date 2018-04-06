using F1WM.Controllers;
using F1WM.Services;
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
		public void ShouldReturnCommentsByNewsId()
		{
			var newsId = 42;

			controller.GetMany(newsId);

			serviceMock.Verify(s => s.GetCommentsByNewsId(newsId), Times.Once);
		}

		[Fact]
		public void ShouldReturnSingleComment()
		{
			var id = 43;

			controller.GetSingle(id);

			serviceMock.Verify(s => s.GetComment(id), Times.Once);
		}
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Controllers
{
	public class NewsControllerTests
	{
		private NewsController controller;
		private Mock<INewsService> serviceMock;
		private Mock<ILoggingService> loggerMock;

		public NewsControllerTests()
		{
			serviceMock = new Mock<INewsService>();
			loggerMock = new Mock<ILoggingService>();
			controller = new NewsController(serviceMock.Object, loggerMock.Object);
		}

		[Fact]
		public async Task ShouldReturnLast20NewsByDefault()
		{
			await controller.GetMany(null);

			serviceMock.Verify(s => s.GetLatestNews(20, null), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsOlderThanFirstId()
		{
			var firstId = 42;

			await controller.GetMany(firstId);

			serviceMock.Verify(s => s.GetLatestNews(20, firstId), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsDetailsById()
		{
			var id = 43;

			await controller.GetSingle(id);

			serviceMock.Verify(s => s.GetNewsDetails(id), Times.Once);
		}

		[Fact]
		public async Task ShouldReturn404IfSingleNewsNotFound()
		{
			var id = 44;

			var result = await controller.GetSingle(id);

			serviceMock.Verify(s => s.GetNewsDetails(id), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}

		[Fact]
		public async Task ShouldReturnImportantNews()
		{
			var result = await controller.GetImportantNews();

			serviceMock.Verify(s => s.GetImportantNews(), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnEmptyListOfImportantNews()
		{
			serviceMock.Setup(s => s.GetImportantNews()).ReturnsAsync(new List<ImportantNewsSummary>());

			var result = await controller.GetImportantNews();

			serviceMock.Verify(s => s.GetImportantNews(), Times.Once);
			Assert.Empty(result);
		}

        [Fact]
        public async Task ShouldReturn404IfNoNewsToIncrement()
        {
            var id = 44;

            var result = await controller.IncremetViews(id);

            serviceMock.Verify(s => s.IncrementViews(id), Times.Once);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task ShouldReturn200IfViewsIncremented()
        {
            var id = 44000;

            serviceMock.Setup(s => s.IncrementViews(id)).ReturnsAsync(true);

            var result = await controller.IncremetViews(id);

            serviceMock.Verify(s => s.IncrementViews(id), Times.Once);
            Assert.IsType<OkResult>(result);
        }
    }
}

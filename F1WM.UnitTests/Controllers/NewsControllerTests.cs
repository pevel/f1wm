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

			serviceMock.Verify(s => s.GetLatestNews(null, 1, 20), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsOlderThanFirstId()
		{
			var firstId = 42;

			await controller.GetMany(firstId);

			serviceMock.Verify(s => s.GetLatestNews(firstId, 1, 20), Times.Once);
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
		public async Task ShouldReturnNewsTypes()
		{
			await controller.GetTypes();

			serviceMock.Verify(s => s.GetNewsTypes(), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsTags()
		{
			await controller.GetTags();

			serviceMock.Verify(s => s.GetNewsTags(), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsCategories()
		{
			await controller.GetCategories();

			serviceMock.Verify(s => s.GetNewsCategories(), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsTagsByCategoryId()
		{
			var categoryId = 40;

			await controller.GetTags(categoryId);

			serviceMock.Verify(s => s.GetNewsTagsByCategoryId(categoryId), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsByTypeId()
		{
			var typeId = 1;

			await controller.GetMany(null, null, typeId);

			serviceMock.Verify(s => s.GetNewsByTypeId(typeId, 1, 20), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsByTagId()
		{
			var tagId = 4;

			await controller.GetMany(null, tagId);

			serviceMock.Verify(s => s.GetNewsByTagId(tagId, 1, 20), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnEmptyListOfNewsByTagId()
		{
			var tagId = 1;

			var result = await controller.GetMany(null, tagId);

			serviceMock.Verify(s => s.GetNewsByTagId(tagId, 1, 20), Times.Once);
			Assert.Null(result);
		}

		[Fact]
		public async Task ShouldReturnEmptyListOfNewsByTypeId()
		{
			var typeId = 1;

			var result = await controller.GetMany(null, null, typeId);

			serviceMock.Verify(s => s.GetNewsByTypeId(typeId, 1, 20), Times.Once);
			Assert.Null(result);
		}

		[Fact]
		public async Task ShouldReturnEmptyListOfTagsByCategoryId()
		{
			var categoryId = 10;

			var result = await controller.GetTags(categoryId);

			serviceMock.Verify(s => s.GetNewsTagsByCategoryId(categoryId), Times.Once);
			Assert.Empty(result);
		}
	}
}
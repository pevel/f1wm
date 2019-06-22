using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Controllers
{
	public class NewsControllerTests
	{
		private NewsController controller;
		private Mock<INewsService> serviceMock;
		private Fixture fixture;

		public NewsControllerTests()
		{
			serviceMock = new Mock<INewsService>();
			controller = new NewsController(serviceMock.Object);
			fixture = new Fixture();
		}

		[Fact]
		public async Task ShouldReturnLast20NewsByDefault()
		{
			await controller.GetManyNews(null);

			serviceMock.Verify(s => s.GetLatestNews(null, 1, 20), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnProperNewsCount()
		{
			uint count = 5;

			await controller.GetManyNews(null, null, null, 1, count);

			serviceMock.Verify(s => s.GetLatestNews(null, 1, count), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnProperNewsPage()
		{
			uint page = 2;

			await controller.GetManyNews(null, null, null, page);

			serviceMock.Verify(s => s.GetLatestNews(null, page, 20), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsOlderThanFirstId()
		{
			var firstId = 42;

			await controller.GetManyNews(firstId);

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
			Assert.IsType<NotFoundResult>(result.Result);
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

			var result = await controller.IncrementViews(id);

			serviceMock.Verify(s => s.IncrementViews(id), Times.Once);
			Assert.IsType<NotFoundResult>(result);
		}

		[Fact]
		public async Task ShouldReturn204IfViewsIncremented()
		{
			var id = 44000;

			serviceMock.Setup(s => s.IncrementViews(id)).ReturnsAsync(true);

			var result = await controller.IncrementViews(id);

			serviceMock.Verify(s => s.IncrementViews(id), Times.Once);
			Assert.IsType<NoContentResult>(result);
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

			serviceMock.Verify(s => s.GetNewsTags(1, 20), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsCategories()
		{
			await controller.GetTagCategories();

			serviceMock.Verify(s => s.GetNewsTagCategories(), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsTagsByCategoryId()
		{
			var categoryId = 40;

			await controller.GetTags(categoryId);

			serviceMock.Verify(s => s.GetNewsTagsByCategoryId(categoryId, 1, 20), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsByTypeId()
		{
			var typeId = 1;

			await controller.GetManyNews(null, null, typeId);

			serviceMock.Verify(s => s.GetNewsByTypeId(typeId, 1, 20), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnNewsByTagId()
		{
			var tagId = 4;

			await controller.GetManyNews(null, tagId);

			serviceMock.Verify(s => s.GetNewsByTagId(tagId, 1, 20), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnEmptyListOfNewsByTagId()
		{
			var tagId = 2;
			IEnumerable<NewsSummary> emptyResult = Enumerable.Empty<NewsSummary>();
			PagedResult<NewsSummary> emptyResponse = new PagedResult<NewsSummary>
			{
				CurrentPage = 1,
				PageCount = 0,
				PageSize = 0,
				RowCount = 0,
				Result = emptyResult
			};

			serviceMock.Setup(s => s.GetNewsByTagId(tagId, 1, 20)).ReturnsAsync(emptyResponse);

			var result = await controller.GetManyNews(null, tagId);

			serviceMock.Verify(s => s.GetNewsByTagId(tagId, 1, 20), Times.Once);
			Assert.Empty(result.Result);
		}

		[Fact]
		public async Task ShouldReturnEmptyListOfNewsByTypeId()
		{
			var typeId = 1;
			IEnumerable<NewsSummary> emptyResult = Enumerable.Empty<NewsSummary>();
			PagedResult<NewsSummary> emptyResponse = new PagedResult<NewsSummary>
			{
				CurrentPage = 1,
				PageCount = 0,
				PageSize = 0,
				RowCount = 0,
				Result = emptyResult
			};

			serviceMock.Setup(s => s.GetNewsByTypeId(typeId, 1, 20)).ReturnsAsync(emptyResponse);

			var result = await controller.GetManyNews(null, null, typeId);

			serviceMock.Verify(s => s.GetNewsByTypeId(typeId, 1, 20), Times.Once);
			Assert.Empty(result.Result);
		}

		[Fact]
		public async Task ShouldReturnEmptyListOfTagsByCategoryId()
		{
			var categoryId = 10;
			IEnumerable<NewsTag> emptyResult = Enumerable.Empty<NewsTag>();
			PagedResult<NewsTag> emptyResponse = new PagedResult<NewsTag>
			{
				CurrentPage = 1,
				PageCount = 0,
				PageSize = 0,
				RowCount = 0,
				Result = emptyResult
			};

			serviceMock.Setup(s => s.GetNewsTagsByCategoryId(categoryId, 1, 20)).ReturnsAsync(emptyResponse);

			var result = await controller.GetTags(categoryId);

			serviceMock.Verify(s => s.GetNewsTagsByCategoryId(categoryId, 1, 20), Times.Once);
			Assert.Empty(result.Result);
		}

		[Fact]
		public async Task ShouldReturnRelatedById()
		{
			int id = 12345;
			var results = fixture.Create<IEnumerable<NewsSummary>>();
			serviceMock.Setup(s => s.GetRelatedNews(id, null, null)).ReturnsAsync(results);

			var result = await controller.GetRelatedNews(id, null, null);

			serviceMock.Verify(s => s.GetRelatedNews(id, null, null), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(results);
		}

		[Fact]
		public async Task ShouldReturn404IfRelatedNewsNotFound()
		{
			var id = 54321;
			serviceMock.Setup(s => s.GetRelatedNews(id, null, null)).ReturnsAsync((IEnumerable<NewsSummary>) null);

			var result = await controller.GetRelatedNews(id, null, null);

			serviceMock.Verify(s => s.GetRelatedNews(id, null, null), Times.Once);
			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task ShouldReturnSearchResults()
		{
			var term = "maldonado";

			await controller.SearchNews(term, 1, 20, null);

			serviceMock.Verify(s => s.SearchNews(term, 1, 20, null), Times.Once);
		}

		[Fact]
		public async Task ShouldReturnEmptySearchResults()
		{
			var term = "mydli mydli";
			DateTime before = new DateTime(2017, 9, 19);
			IEnumerable<NewsSummary> emptyResult = Enumerable.Empty<NewsSummary>();
			PagedResult<NewsSummary> emptyResponse = new PagedResult<NewsSummary>
			{
				CurrentPage = 1,
				PageCount = 0,
				PageSize = 0,
				RowCount = 0,
				Result = emptyResult
			};

			serviceMock.Setup(s => s.SearchNews(term, 1, 20, before)).ReturnsAsync(emptyResponse);

			var result = await controller.SearchNews(term, 1, 20, before);

			serviceMock.Verify(s => s.SearchNews(term, 1, 20, before), Times.Once);
			Assert.Empty(result.Result);
		}
	}
}

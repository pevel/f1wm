using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DatabaseModel.Constants;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Narochno.BBCode;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class NewsServiceTests
	{
		private NewsService service;
		private Fixture fixture;
 		private Mock<INewsRepository> newsRepositoryMock;
		private Mock<IConfigRepository> configTextRepositoryMock;
		private Mock<IBBCodeParser> parserMock;
		private Mock<ITimeService> timeServiceMock;

		public NewsServiceTests()
		{
			fixture = new Fixture();
			newsRepositoryMock = new Mock<INewsRepository>();
			configTextRepositoryMock = new Mock<IConfigRepository>();
			parserMock = new Mock<IBBCodeParser>();
			timeServiceMock = new Mock<ITimeService>();
			service = new NewsService(
				newsRepositoryMock.Object,
				configTextRepositoryMock.Object,
				parserMock.Object,
				timeServiceMock.Object);
		}

		[Fact]
		public async Task ShouldGetNewsDetailsWithParsedText()
		{
			var id = 42;
			var text = "Test text";
			newsRepositoryMock.Setup(r => r.GetNewsDetails(id)).ReturnsAsync(new NewsDetails() { Text = text });

			await service.GetNewsDetails(id);

			newsRepositoryMock.Verify(r => r.GetNewsDetails(id), Times.Once);
			parserMock.Verify(p => p.ToHtml(text), Times.Once);
		}

		[Fact]
		public async Task ShouldGetNewsSummaryList()
		{
			uint count = 21;
			var firstId = 43;
			var news = fixture.Create<PagedResult<NewsSummary>>();
			newsRepositoryMock.Setup(r => r.GetLatestNews(firstId, 1, count)).ReturnsAsync(news);

			await service.GetLatestNews(firstId, 1, count);

			newsRepositoryMock.Verify(r => r.GetLatestNews(firstId, 1, count), Times.Once);
		}

		[Fact]
		public async Task ShouldGetNewsTypes()
		{
			await service.GetNewsTypes();

			newsRepositoryMock.Verify(r => r.GetNewsTypes(), Times.Once);
		}

		[Fact]
		public async Task ShouldGetNewsByTypeId()
		{
			var id = 2;
			uint page = 1;
			uint countPerPage = 20;
			await service.GetNewsByTypeId(id, page, countPerPage);

			newsRepositoryMock.Verify(r => r.GetNewsByTypeId(id, page, countPerPage), Times.Once);
		}

		[Fact]
		public async Task ShouldGetNewsCategories()
		{
			await service.GetNewsTagCategories();

			newsRepositoryMock.Verify(r => r.GetNewsTagCategories(), Times.Once);
		}

		[Fact]
		public async Task ShouldGetNewsTagsByCategoryId()
		{
			var id = 1;
			uint page = 1;
			uint countPerPage = 20;
			await service.GetNewsTagsByCategoryId(id, page, countPerPage);

			newsRepositoryMock.Verify(r => r.GetNewsTagsByCategoryId(id, page, countPerPage), Times.Once);
		}

		[Fact]
		public async Task ShouldGetNewsTags()
		{
			uint page = 1;
			uint countPerPage = 20;
			await service.GetNewsTags(page, countPerPage);

			newsRepositoryMock.Verify(r => r.GetNewsTags(page, countPerPage), Times.Once);
		}

		[Fact]
		public async Task ShouldGetNewsByTagId()
		{
			var id = 1;
			uint page = 1;
			uint countPerPage = 20;
			await service.GetNewsByTagId(id, page, countPerPage);

			newsRepositoryMock.Verify(r => r.GetNewsByTagId(id, page, countPerPage), Times.Once);
		}

		[Fact]
		public async Task ShouldGetImportantNews()
		{
			var newsIds = new List<uint>() { 101, 102, 103, 104 };
			var configText =
				$@"{newsIds[0]}|test0.png|test 0
				   {newsIds[1]}|test1.png|test 1
				   {newsIds[2]}|test2.png|test 2
				   {newsIds[3]}|test3.png|test 3";
			configTextRepositoryMock
				.Setup(r => r.GetConfigText(ConfigTextName.ImportantNews))
				.ReturnsAsync(new ConfigText() { Value = configText });

			await service.GetImportantNews();

			newsRepositoryMock.Verify(r => r.GetNews(It.Is<ICollection<uint>>(ids => ids.All(i => newsIds.Contains(i)))), Times.Once);
		}

		[Fact]
		public async Task ShouldIncrementViews()
		{
			var id = 44000;
			newsRepositoryMock.Setup(r => r.IncrementViews(id)).ReturnsAsync(true);

			await service.IncrementViews(id);

			newsRepositoryMock.Verify(r => r.IncrementViews(id), Times.Once);
		}
		
		[Fact]
		public async Task ShouldGetRelatedNews()
		{
			var id = 44757;
			var now = new DateTime(1992, 10, 14);
			var count = 5;
			
			timeServiceMock.SetupGet(t => t.Now).Returns(now);
			var news = fixture.Create<IEnumerable<NewsSummary>>();
			newsRepositoryMock.Setup(r => r.GetRelatedNews(id, now, count)).ReturnsAsync(news);
			
			await service.GetRelatedNews(id, now, count);

			newsRepositoryMock.Verify(r => r.GetRelatedNews(id, now, count), Times.Once);
		}

	}
}

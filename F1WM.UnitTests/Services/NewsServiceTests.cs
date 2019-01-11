using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		private Mock<INewsRepository> newsRepositoryMock;
		private Mock<IConfigTextRepository> configTextRepositoryMock;
		private Mock<IBBCodeParser> parserMock;

		public NewsServiceTests()
		{
			newsRepositoryMock = new Mock<INewsRepository>();
			configTextRepositoryMock = new Mock<IConfigTextRepository>();
			parserMock = new Mock<IBBCodeParser>();
			service = new NewsService(newsRepositoryMock.Object, configTextRepositoryMock.Object, parserMock.Object);
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
			var count = 21;
			var firstId = 43;

			await service.GetLatestNews(count, firstId);

			newsRepositoryMock.Verify(r => r.GetLatestNews(count, firstId), Times.Once);
		}

        [Fact]
        public async Task ShouldGetNewsTypes()
        {
            await service.GetNewsTypes();

            newsRepositoryMock.Verify(r => r.GetNewsTypes(), Times.Once);
        }

        [Fact]
        public async Task ShouldGetNewsTags()
        {
            await service.GetNewsTags();

            newsRepositoryMock.Verify(r => r.GetNewsTags(), Times.Once);
        }

        [Fact]
        public async Task ShouldGetNewsTagsByCategory()
        {
            var id = 1;
            await service.GetNewsTagsByCategory(id);

            newsRepositoryMock.Verify(r => r.GetNewsTagsByCategory(id), Times.Once);
        }

        [Fact]
        public async Task ShouldGetNewsCategories()
        {
            await service.GetNewsCategories();

            newsRepositoryMock.Verify(r => r.GetNewsCategories(), Times.Once);
        }

        [Fact]
        public async Task ShouldGetNewsByTag()
        {
            var id = 1;
            await service.GetNewsByTag(id);

            newsRepositoryMock.Verify(r => r.GetNewsByTag(id), Times.Once);
        }

        [Fact]
        public async Task ShouldGetNewsByType()
        {
            var id = 1;
            await service.GetNewsByType(id);

            newsRepositoryMock.Verify(r => r.GetNewsByType(id), Times.Once);
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
	}
}
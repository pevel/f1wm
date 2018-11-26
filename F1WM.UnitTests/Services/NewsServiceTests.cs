using System.Threading.Tasks;
using F1WM.ApiModel;
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
	}
}
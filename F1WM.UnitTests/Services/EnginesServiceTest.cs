using System.Threading.Tasks;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class EnginesServiceTest
	{
		private EnginesService service;
		private Mock<IEnginesRepository> enginesRepositoryMock;

		public EnginesServiceTest()
		{
			enginesRepositoryMock = new Mock<IEnginesRepository>();
			service = new EnginesService(enginesRepositoryMock.Object);
		}

		[Fact]
		public async Task ShouldGetEngines()
		{
			char letter = 'a';

			await service.GetEngines(letter);

			enginesRepositoryMock.Verify(r => r.GetEngines(letter), Times.Once);
		}
	}
}

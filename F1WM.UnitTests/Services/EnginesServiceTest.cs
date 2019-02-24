using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class EnginesServiceTest
	{
		private EnginesService service;
		private Fixture fixture;
		private Mock<IEnginesRepository> enginesRepositoryMock;

		public EnginesServiceTest()
		{
			fixture = new Fixture();
			enginesRepositoryMock = new Mock<IEnginesRepository>();
			service = new EnginesService(enginesRepositoryMock.Object);
		}

		[Fact]
		public async Task ShouldGetEngines()
		{
			char letter = 'a';
			var engines = fixture.Create<Engines>();
			enginesRepositoryMock.Setup(r => r.GetEngines(letter)).ReturnsAsync(engines);

			var actual = await service.GetEngines(letter);

			enginesRepositoryMock.Verify(r => r.GetEngines(letter), Times.Once);
			actual.Should().BeEquivalentTo(engines);
		}

		[Fact]
		public async Task ShouldGetEngine()
		{
			var engineId = 3333;
			var engine = fixture.Create<EngineDetails>();
			enginesRepositoryMock.Setup(r => r.GetEngine(engineId)).ReturnsAsync(engine);

			var actual = await service.GetEngine(engineId);

			enginesRepositoryMock.Verify(r => r.GetEngine(engineId), Times.Once);
			actual.Should().BeEquivalentTo(engine);
		}
	}
}

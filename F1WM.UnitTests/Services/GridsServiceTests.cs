using System;
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
	public class GridsServiceTests
	{
		private GridsService service;
		private Fixture fixture;
		private Mock<IGridsRepository> repositoryMock;

		public GridsServiceTests()
		{
			fixture = new Fixture();
			repositoryMock = new Mock<IGridsRepository>();
			service = new GridsService(repositoryMock.Object);
		}

		[Fact]
		public async Task ShouldGetGrid()
		{
			var raceId = 8000;
			var Grids = fixture.Create<GridInformation>();
			repositoryMock.Setup(r => r.GetGrid(raceId)).ReturnsAsync(Grids);

			var result = await service.GetGrid(raceId);

			repositoryMock.Verify(r => r.GetGrid(raceId), Times.Once);
			Grids.Should().BeEquivalentTo(result);
		}
	}
}

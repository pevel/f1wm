using System;
using System.Threading.Tasks;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
    public class ResultsServiceTests
	{
		private ResultsService service;
		private Mock<IResultsRepository> repositoryMock;

		public ResultsServiceTests()
		{
			repositoryMock = new Mock<IResultsRepository>();
			service = new ResultsService(repositoryMock.Object);
		}

		[Fact]
		public async Task ShouldGetRaceResult()
		{
			int raceId = 42;

			await service.GetRaceResult(raceId);

			repositoryMock.Verify(r => r.GetRaceResult(raceId), Times.Once);
		}
	}
}
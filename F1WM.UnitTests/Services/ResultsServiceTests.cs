using System.Threading.Tasks;
using F1WM.ApiModel;
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

		[Fact]
		public async Task ShouldGetQualifyingResult()
		{
			int raceId = 52;
			repositoryMock.Setup(r => r.GetQualifyingResult(raceId)).ReturnsAsync(new QualifyingResult());

			var result = await service.GetQualifyingResult(raceId);

			repositoryMock.Verify(r => r.GetQualifyingResult(raceId), Times.Once);
			Assert.Equal(QualifyingResultFormat.Unknown, result.Format);
		}

		[Fact]
		public async Task ShouldGetPracticeSessionResult()
		{
			int raceId = 62;
			string session = "t1";
			repositoryMock.Setup(r => r.GetPracticeSessionResult(raceId, session)).ReturnsAsync(new PracticeSessionResult());

			var result = await service.GetPracticeSessionResult(raceId, session);

			repositoryMock.Verify(r => r.GetPracticeSessionResult(raceId, session), Times.Once);
		}

		[Fact]
		public async Task ShouldGetOtherResult()
		{
			int eventId = 72;
			repositoryMock.Setup(r => r.GetOtherResult(eventId)).ReturnsAsync(new OtherResult());

			var result = await service.GetOtherResult(eventId);

			repositoryMock.Verify(r => r.GetOtherResult(eventId), Times.Once);
		}
	}
}
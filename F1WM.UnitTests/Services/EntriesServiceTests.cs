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
	public class EntriesServiceTests
	{
		private EntriesService service;
		private Fixture fixture;
		private Mock<IEntriesRepository> repositoryMock;

		public EntriesServiceTests()
		{
			fixture = new Fixture();
			repositoryMock = new Mock<IEntriesRepository>();
			service = new EntriesService(repositoryMock.Object);
		}

		[Fact]
		public async Task ShouldGetRaceEntries()
		{
			var raceId = 8000;
			var entries = fixture.Create<RaceEntriesInformation>();
			repositoryMock.Setup(r => r.GetRaceEntries(raceId)).ReturnsAsync(entries);

			var actual = await service.GetRaceEntries(raceId);

			repositoryMock.Verify(r => r.GetRaceEntries(raceId), Times.Once);
			actual.Should().BeEquivalentTo(entries);
		}
	}
}

using F1WM.Repositories;
using F1WM.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class DriversServiceTests
	{
		private DriversService service;
		private Mock<IDriversRepository> driversRepositoryMock;

		public DriversServiceTests()
		{
			driversRepositoryMock = new Mock<IDriversRepository>();
			service = new DriversService(driversRepositoryMock.Object);
		}

		[Fact]
		public async Task ShouldGetDrivers()
		{
			char letter = 'r';

			await service.GetDrivers(letter);

			driversRepositoryMock.Verify(r => r.GetDrivers(letter), Times.Once);
		}
	}
}

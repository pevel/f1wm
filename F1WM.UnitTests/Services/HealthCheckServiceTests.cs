using System;
using System.Data;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class HealthCheckServiceTests
	{
		private HealthCheckService service;
		private Mock<IHealthCheckRepository> repositoryMock;

		public HealthCheckServiceTests()
		{
			repositoryMock = new Mock<IHealthCheckRepository>();
			service = new HealthCheckService(repositoryMock.Object);
		}

		[Fact]
		public void ShouldReturnOkDatabaseStatus()
		{
			var expectedStatus = "OK";
			repositoryMock.Setup(r => r.GetConnectionState()).Returns(ConnectionState.Open);

			var actualStatus = service.GetDatabaseStatus();

			Assert.Equal(expectedStatus, actualStatus);
		}

		[Fact]
		public void ShouldReturnErrorDatabaseStatus()
		{
			var expectedStatus = "Down";
			repositoryMock.Setup(c => c.GetConnectionState()).Throws<Exception>();

			var actualStatus = service.GetDatabaseStatus();

			Assert.StartsWith(expectedStatus, actualStatus);
		}
	}
}
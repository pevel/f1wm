using System;
using System.Data;
using F1WM.Services;
using F1WM.Utilities;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class HealthCheckServiceTests
	{
		private HealthCheckService service;
		private Mock<IDbContext> dbMock;
		private Mock<IDbConnection> connectionMock;

		public HealthCheckServiceTests()
		{
			dbMock = new Mock<IDbContext>();
			connectionMock = new Mock<IDbConnection>();
			dbMock.SetupGet(d => d.Connection).Returns(connectionMock.Object);
			service = new HealthCheckService(dbMock.Object);
		}

		[Fact]
		public void ShouldReturnOkDatabaseStatus()
		{
			var expectedStatus = "OK";
			connectionMock.SetupGet(c => c.State).Returns(ConnectionState.Open);

			var actualStatus = service.GetDatabaseStatus();

			Assert.Equal(expectedStatus, actualStatus);
		}

		[Fact]
		public void ShouldReturnErrorDatabaseStatus()
		{
			var expectedStatus = "Down";
			connectionMock.Setup(c => c.Open()).Throws<Exception>();

			var actualStatus = service.GetDatabaseStatus();

			Assert.StartsWith(expectedStatus, actualStatus);
		}
	}
}
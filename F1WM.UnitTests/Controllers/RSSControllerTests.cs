using System;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using AutoFixture;
using F1WM.ApiModel;
using F1WM.Controllers;
using F1WM.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Controllers
{
	public class RSSControllerTests
	{
		private RSSController controller;
		private Fixture fixture;
		private Mock<IRSSService> serviceMock;
		private Mock<ICachingService> cachingServiceMock;

		public RSSControllerTests()
		{
			fixture = new Fixture();
			serviceMock = new Mock<IRSSService>();
			cachingServiceMock = new Mock<ICachingService>();
			controller = new RSSController(serviceMock.Object, cachingServiceMock.Object);
			SetupResponseMock();
		}

		[Fact]
		public async Task ShouldReturnNewRSS()
		{
			var fakeFeed = new SyndicationFeed("fake feed", "fake feed", new Uri("http://fake.feed"));
			serviceMock.Setup(s => s.GetFeed(null)).ReturnsAsync(fakeFeed);
			cachingServiceMock.Setup(c => c.Get<SyndicationFeed>(It.IsAny<string>())).Returns((SyndicationFeed) null);

			var result = await controller.GetFeed(null);

			serviceMock.Verify(s => s.GetFeed(null), Times.Once);
			cachingServiceMock.Verify(
				c => c.Set(
					It.IsAny<string>(),
					fakeFeed,
					It.Is<MemoryCacheEntryOptions>(o => o.AbsoluteExpirationRelativeToNow.Value.Minutes == 5)
				),
				Times.Once
			);
		}

		[Fact]
		public async Task ShouldReturnCachedRSS()
		{
			var fakeCachedFeed = new SyndicationFeed("fake cached", "fake cached", new Uri("http://fake.cached"));
			cachingServiceMock.Setup(c => c.Get<SyndicationFeed>(It.IsAny<string>())).Returns(fakeCachedFeed);

			var result = await controller.GetFeed(null);

			serviceMock.Verify(s => s.GetFeed(null), Times.Never);
			cachingServiceMock.Verify(c => c.Get<SyndicationFeed>(It.IsAny<string>()), Times.Once);
			cachingServiceMock.Verify(c => c.Set(It.IsAny<string>(), It.IsAny<SyndicationFeed>(), It.IsAny<MemoryCacheEntryOptions>()), Times.Never);
		}

		[Fact]
		public async Task ShouldAddOrUpdateRSSConfiguration()
		{
			var request = fixture.Create<RSSFeedConfigurationEditRequest>();
			var response = new RSSFeedConfiguration();

			var result = await controller.UpdateConfiguration(request);

			serviceMock.Verify(s => s.UpdateOrAddConfiguration(request), Times.Once);
			var okResult = Assert.IsType<OkObjectResult>(result.Result);
			okResult.Value.Should().BeEquivalentTo(response);
		}

		private void SetupResponseMock()
		{
			var contextMock = new Mock<HttpContext>();
			var responseMock = new Mock<HttpResponse>();
			contextMock.SetupGet(c => c.Response).Returns(responseMock.Object);
			controller.ControllerContext.HttpContext = contextMock.Object;
		}
	}
}

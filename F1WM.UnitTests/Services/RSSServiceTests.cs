using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DatabaseModel.Constants;
using F1WM.Mapping;
using F1WM.Repositories;
using F1WM.Services;
using Moq;
using Xunit;

namespace F1WM.UnitTests.Services
{
	public class RSSServiceTests
	{
		private RSSService service;
		private Fixture fixture;
		private Mock<ITimeService> timeServiceMock;
		private Mock<IConfigRepository> configRepositoryMock;
		private Mock<INewsRepository> newsRepositoryMock;
		private IMapper mapper;

		public RSSServiceTests()
		{
			fixture = new Fixture();
			timeServiceMock = new Mock<ITimeService>();
			configRepositoryMock = new Mock<IConfigRepository>();
			newsRepositoryMock = new Mock<INewsRepository>();
			Mapper.Initialize(options => options.AddProfile(new RSSMappingProfile()));
			mapper = new Mapper(Mapper.Configuration);
			service = new RSSService(
				timeServiceMock.Object,
				configRepositoryMock.Object,
				newsRepositoryMock.Object,
				mapper);
		}

		[Fact]
		public async Task ShouldAddOrUpdateRSSConfiguration()
		{
			var request = fixture.Create<RSSFeedConfigurationEditRequest>();

			var actual = await service.UpdateOrAddConfiguration(request);

			configRepositoryMock.Verify(
				r => r.UpdateOrAddConfigTexts("RSS", It.Is<IEnumerable<ConfigText>>(GetConfigurationValidator(request))),
				Times.Once);
		}

		private Expression<Func<IEnumerable<ConfigText>, bool>> GetConfigurationValidator(RSSFeedConfigurationEditRequest r)
		{
			return configs => configs.Any(c => c.Name == ConfigTextName.RssCopyright && c.Value == r.Copyright) &&
				configs.Any(c => c.Name == ConfigTextName.RssDescription && c.Value == r.Description) &&
				configs.Any(c => c.Name == ConfigTextName.RssImageUrl && c.Value == r.ImageUrl) &&
				configs.Any(c => c.Name == ConfigTextName.RssLanguage && c.Value == r.Language) &&
				configs.Any(c => c.Name == ConfigTextName.RssLink && c.Value == r.Link) &&
				configs.Any(c => c.Name == ConfigTextName.RssTitle && c.Value == r.Title);
		}
	}
}

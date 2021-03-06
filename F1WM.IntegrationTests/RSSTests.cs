using System.IO;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using F1WM.IntegrationTests.Utilities;
using FluentAssertions;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class RSSTests : IntegrationTestBase
	{
		[Fact]
		public async Task ShouldGetRSSFeed()
		{
			var firstId = 44000;
			var response = await CreateClient(false).GetAsync($"rss?firstId={firstId}");
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var expected = Read(File.ReadAllText(SharedTestUtilities.GetTestDataFilePath("RSS", "feed.xml")));
			var actual = Read(responseContent);
			actual.Should().BeEquivalentTo(expected, o => o.Excluding(f => f.LastUpdatedTime).Excluding(f => f.Copyright));
		}

		[Fact]
		public async Task ShouldNotUpdateRSSConfiguration()
		{
			var response = await CreateClient(false).PutAsync($"rss/configuration", new StringContent(""));
			Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
		}

		private SyndicationFeed Read(string from)
		{
			using (var s = new StringReader(from))
			{
				return SyndicationFeed.Load(XmlReader.Create(s));
			}
		}
	}
}

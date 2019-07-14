using System.IO;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
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
			var response = await client.GetAsync($"{baseAddress}/rss?firstId={firstId}");
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var expected = Read(File.ReadAllText(TestUtilities.GetTestDataFilePath("RSS", "feed.xml")));
			var actual = Read(responseContent);
			actual.Should().BeEquivalentTo(expected, o => o.Excluding(f => f.LastUpdatedTime));
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

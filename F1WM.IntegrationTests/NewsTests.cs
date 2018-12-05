using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class NewsTests : IntegrationTestBase
	{
		[Fact]
		public async Task GetSingleNewsTest()
		{
			var id = 42000;

			var response = await client.GetAsync($"{baseAddress}/news/{id}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var news = JsonConvert.DeserializeObject<NewsDetails>(responseContent);
			Assert.NotNull(news);
			Assert.NotNull(news.Title);
			Assert.NotNull(news.Text);
			Assert.NotNull(news.Subtitle);
			Assert.NotNull(news.PosterName);
			Assert.Equal(id, news.Id);
		}

		[Fact]
		public async Task GetManyNewsTest()
		{
			var firstId = 42001;
			var count = 5;

			var response = await client.GetAsync($"{baseAddress}/news?firstId={firstId}&count={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var newsList = JsonConvert.DeserializeObject<IEnumerable<NewsSummary>>(responseContent);
			Assert.NotNull(newsList);
			Assert.Equal(firstId, newsList.First().Id);
			Assert.Equal(count, newsList.Count());
			Assert.All(newsList, news =>
			{
				Assert.NotNull(news.Title);
				Assert.NotNull(news.Subtitle);
			});
		}

		[Fact]
		public async Task GetImportantNewsTest()
		{
			var response = await client.GetAsync($"{baseAddress}/news/important");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var newsList = JsonConvert.DeserializeObject<IEnumerable<ImportantNewsSummary>>(responseContent);
			Assert.NotNull(newsList);
			Assert.All(newsList, news =>
			{
				Assert.False(string.IsNullOrWhiteSpace(news.ImageUrl));
				Assert.False(string.IsNullOrWhiteSpace(news.ShortText));
				Assert.False(string.IsNullOrWhiteSpace(news.Title));
			});
		}
	}
}
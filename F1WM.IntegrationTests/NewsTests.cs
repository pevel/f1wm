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
		public async Task GetSingleNewsWithPracticeResultLinkTest()
		{
			var id = 42422;

			var response = await client.GetAsync($"{baseAddress}/news/{id}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var news = JsonConvert.DeserializeObject<NewsDetails>(responseContent);
			Assert.NotNull(news);
			Assert.NotNull(news.Title);
			Assert.NotNull(news.Text);
			Assert.NotNull(news.Subtitle);
			Assert.NotNull(news.PosterName);
			Assert.NotNull(news.ResultLink);
			Assert.Equal(ResultLinkType.Practice, news.ResultLink.Type);
			Assert.NotEqual(0, news.ResultLink.RaceId);
			Assert.False(string.IsNullOrWhiteSpace(news.ResultLink.Session));
			Assert.Equal(id, news.Id);
		}

		[Fact]
		public async Task GetSingleNewsWithRaceResultLinkTest()
		{
			var id = 2468;

			var response = await client.GetAsync($"{baseAddress}/news/{id}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var news = JsonConvert.DeserializeObject<NewsDetails>(responseContent);
			Assert.NotNull(news);
			Assert.NotNull(news.Title);
			Assert.NotNull(news.Text);
			Assert.NotNull(news.Subtitle);
			Assert.NotNull(news.PosterName);
			Assert.NotNull(news.ResultLink);
			Assert.Equal(ResultLinkType.Race, news.ResultLink.Type);
			Assert.NotEqual(0, news.ResultLink.RaceId);
			Assert.Equal(id, news.Id);
		}

		[Fact]
		public async Task GetSingleNewsWithQualifyingResultLinkTest()
		{
			var id = 2464;

			var response = await client.GetAsync($"{baseAddress}/news/{id}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var news = JsonConvert.DeserializeObject<NewsDetails>(responseContent);
			Assert.NotNull(news);
			Assert.NotNull(news.Title);
			Assert.NotNull(news.Text);
			Assert.NotNull(news.Subtitle);
			Assert.NotNull(news.PosterName);
			Assert.NotNull(news.ResultLink);
			Assert.Equal(ResultLinkType.Qualifying, news.ResultLink.Type);
			Assert.NotEqual(0, news.ResultLink.RaceId);
			Assert.Equal(id, news.Id);
		}

		[Fact]
		public async Task GetSingleNewsWithOtherResultLinkTest()
		{
			var id = 1010;

			var response = await client.GetAsync($"{baseAddress}/news/{id}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var news = JsonConvert.DeserializeObject<NewsDetails>(responseContent);
			Assert.NotNull(news);
			Assert.NotNull(news.Title);
			Assert.NotNull(news.Text);
			Assert.NotNull(news.Subtitle);
			Assert.NotNull(news.PosterName);
			Assert.NotNull(news.ResultLink);
			Assert.Equal(ResultLinkType.Other, news.ResultLink.Type);
			Assert.NotEqual(0, news.ResultLink.EventId);
			Assert.Equal(id, news.Id);
		}

		[Fact]
		public async Task GetManyNewsTest()
		{
			var firstId = 42001;
			var count = 5;

			var response = await client.GetAsync($"{baseAddress}/news?firstId={firstId}&countPerPage={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<NewsSummaryPaged>(responseContent);
			var newsList = result.Result;
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
		public async Task GetNewsTagsTest()
		{
			var response = await client.GetAsync($"{baseAddress}/news/tags");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var tagsList = JsonConvert.DeserializeObject<IEnumerable<NewsTag>>(responseContent);
			Assert.NotNull(tagsList);
			Assert.All(tagsList, tag =>
			{
				Assert.NotEqual((uint)0, tag.Id);
				Assert.NotEqual((uint)0, tag.CategoryId);
				Assert.False(string.IsNullOrWhiteSpace(tag.Title));
			});
		}

		[Fact]
		public async Task GetNewsTypesTest()
		{
			var response = await client.GetAsync($"{baseAddress}/news/types");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var typesList = JsonConvert.DeserializeObject<IEnumerable<NewsType>>(responseContent);
			Assert.NotNull(typesList);
			Assert.All(typesList, type =>
			{
				Assert.NotEqual((uint)0, type.Id);
				Assert.False(string.IsNullOrWhiteSpace(type.Title));
				Assert.False(string.IsNullOrWhiteSpace(type.AlternativeTitle));
			});
		}

		[Fact]
		public async Task GetNewsCategoriesTest()
		{
			var response = await client.GetAsync($"{baseAddress}/news/categories");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var categoriesList = JsonConvert.DeserializeObject<IEnumerable<NewsCategory>>(responseContent);
			Assert.NotNull(categoriesList);
			Assert.All(categoriesList, category =>
			{
				Assert.NotEqual((uint)0, category.Id);
				Assert.False(string.IsNullOrWhiteSpace(category.Title));
			});
		}

		[Fact]
		public async Task GetNewsTagsByCategoryIdTest()
		{
			var id = 2;

			var response = await client.GetAsync($"{baseAddress}/news/tags?categoryId={id}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var tagsList = JsonConvert.DeserializeObject<IEnumerable<NewsTag>>(responseContent);
			Assert.NotNull(tagsList);
			Assert.All(tagsList, tag =>
			{
				Assert.NotEqual((uint)0, tag.Id);
				Assert.False(string.IsNullOrWhiteSpace(tag.Title));
				Assert.Equal((uint)id, tag.CategoryId);
			});
		}

		[Fact]
		public async Task GetProperNewsCountByTypeIdTest()
		{
			var typeId = 1;
			var count = 7;

			var response = await client.GetAsync($"{baseAddress}/news?typeId={typeId}&countPerPage={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<NewsSummaryPaged>(responseContent);
			Assert.Equal(result.Result.Count(), count);
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
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class NewsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("news", "news-details.json")]
		public async Task ShouldGetSingleNews(NewsDetailsTestData data)
		{
			await TestResponse<NewsDetails>($"{baseAddress}/news/{data.NewsId}", data.Expected, data.Why);
		}

		[Theory]
		[JsonData("news", "news-summary.json")]
		public async Task ShouldGetManyNews(NewsSummaryTestData data)
		{
			await TestResponse<NewsSummaryPaged>(
				$"{baseAddress}/news?firstId={data.FirstId}&countPerPage={data.CountPerPage}&page={data.Page}",
				data.Expected);
		}

		[Fact]
		public async Task ShouldGetImportantNews()
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

		[Fact]
		public async Task ShouldIncrementViews()
		{
			var id = 30676;
			var response = await client.PostAsync($"{baseAddress}/news/{id}/views/increment", new StringContent(""));
			response.EnsureSuccessStatusCode();
		}

		[Fact]
		public async Task ShouldGetNewsTags()
		{
			var count = 5;
			var response = await client.GetAsync($"{baseAddress}/news/tags?countPerPage={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<NewsTagsPaged>(responseContent);
			Assert.NotNull(result.Result);
			Assert.Equal(count, result.PageSize);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal(1, result.CurrentPage);
			Assert.True(result.PageCount > 0);
			var tagsList = result.Result;
			Assert.NotNull(tagsList);
			Assert.Equal(count, tagsList.Count());
			Assert.All(tagsList, tag =>
			{
				Assert.NotEqual((uint)0, tag.Id);
				Assert.NotEqual((uint)0, tag.CategoryId);
				Assert.False(string.IsNullOrWhiteSpace(tag.Title));
			});
		}

		[Fact]
		public async Task ShouldGetNewsTypes()
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
		public async Task ShouldGetNewsCategories()
		{
			var response = await client.GetAsync($"{baseAddress}/news/categories");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var categoriesList = JsonConvert.DeserializeObject<IEnumerable<NewsTagCategory>>(responseContent);
			Assert.NotNull(categoriesList);
			Assert.All(categoriesList, category =>
			{
				Assert.NotEqual((uint)0, category.Id);
				Assert.False(string.IsNullOrWhiteSpace(category.Title));
			});
		}

		[Fact]
		public async Task ShouldGetNewsTagsByCategoryId()
		{
			var id = 2;
			var count = 5;

			var response = await client.GetAsync($"{baseAddress}/news/tags?categoryId={id}&countPerPage={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<NewsTagsPaged>(responseContent);
			Assert.NotNull(result.Result);
			Assert.Equal(count, result.PageSize);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal(1, result.CurrentPage);
			Assert.True(result.PageCount > 0);
			var tagsList = result.Result;
			Assert.NotNull(tagsList);
			Assert.Equal(count, tagsList.Count());
			Assert.All(tagsList, tag =>
			{
				Assert.NotEqual((uint)0, tag.Id);
				Assert.False(string.IsNullOrWhiteSpace(tag.Title));
				Assert.Equal((uint)id, tag.CategoryId);
			});
		}

		[Fact]
		public async Task ShouldGetNewsByTypeId()
		{
			var typeId = 5;
			var count = 7;

			var response = await client.GetAsync($"{baseAddress}/news?typeId={typeId}&countPerPage={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<NewsSummaryPaged>(responseContent);
			Assert.NotNull(result.Result);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal(count, result.PageSize);
			Assert.Equal(result.Result.Count(), count);
			Assert.Equal(1, result.CurrentPage);
			Assert.True(result.PageCount > 0);
			var newsList = result.Result;
			Assert.NotNull(newsList);
			Assert.All(newsList, news =>
			{
				Assert.NotNull(news.Title);
				Assert.NotNull(news.Subtitle);
				Assert.Equal(typeId, news.TypeId);
				Assert.False(string.IsNullOrWhiteSpace(news.MainTagIcon));
				Assert.True(0 <= news.CommentCount);
				Assert.NotEqual((uint)0, news.Id);
			});
		}

		[Fact]
		public async Task ShouldGetNewsByTagId()
		{
			var tagId = 2;
			var count = 7;

			var response = await client.GetAsync($"{baseAddress}/news?tagId={tagId}&countPerPage={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<NewsSummaryPaged>(responseContent);
			Assert.NotNull(result.Result);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal(count, result.PageSize);
			Assert.Equal(result.Result.Count(), count);
			Assert.Equal(1, result.CurrentPage);
			Assert.True(result.PageCount > 0);
			var newsList = result.Result;
			Assert.NotNull(newsList);
			Assert.All(newsList, news =>
			{
				Assert.NotNull(news.Title);
				Assert.NotNull(news.Subtitle);
				Assert.False(string.IsNullOrWhiteSpace(news.MainTagIcon));
				Assert.True(0 <= news.CommentCount);
				Assert.NotEqual((uint)0, news.Id);
			});
		}

		public class NewsDetailsTestData
		{
			public int NewsId { get; set; }
			public NewsDetails Expected { get; set; }
			public string Why { get; set; }
		}

		public class NewsSummaryTestData
		{
			public int FirstId { get; set; }
			public uint CountPerPage { get; set; }
			public uint Page { get; set; }
			public NewsSummaryPaged Expected { get; set; }
		}
	}
}

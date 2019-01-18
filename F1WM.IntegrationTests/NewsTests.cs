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
		[Fact]
		public async Task ShouldGetSingleNews()
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
		public async Task ShouldGetSingleNewsWithPracticeResultLink()
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
		public async Task ShouldGetSingleNewsWithRaceResultLink()
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
		public async Task ShouldGetSingleNewsWithQualifyingResultLink()
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
		public async Task ShouldGetSingleNewsWithOtherResultLink()
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
		public async Task ShouldGetManyNews()
		{
			var firstId = 42001;
			var count = 5;

			var response = await client.GetAsync($"{baseAddress}/news?firstId={firstId}&countPerPage={count}");
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<NewsSummaryPaged>(responseContent);
			Assert.NotNull(result);
			Assert.Equal(count, result.PageSize);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal(1, result.CurrentPage);
			Assert.True(result.PageCount > 0);
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
			Assert.NotNull(result);
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
			Assert.NotNull(result);
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
			Assert.NotNull(result);
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
			Assert.NotNull(result);
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
			});
		}
	}
}

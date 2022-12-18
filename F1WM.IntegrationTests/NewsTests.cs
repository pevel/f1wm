using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.IntegrationTests.Attributes;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class NewsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("news", "news-details.json")]
		public async Task ShouldGetSingleNews(NewsDetailsTestData data)
		{
			await TestResponse<NewsDetails>(
				$"news/{data.NewsId}",
				data.Expected,
				c => c.Excluding(n => n.Views),
				data.Why);
		}

		[Theory]
		[JsonData("news", "news-summary.json")]
		public async Task ShouldGetManyNews(NewsSummaryTestData data)
		{
			await TestResponse<PagedResult<NewsSummary>>(
				$"news?firstId={data.FirstId}&countPerPage={data.CountPerPage}&page={data.Page}",
				data.Expected,
				c => c.WithStrictOrderingFor(n => n.Result));
		}

		[Theory]
		[JsonData("news", "news-types.json")]
		public async Task ShouldGetNewsTypes(NewsTypesTestData data)
		{
			await TestResponse<IEnumerable<NewsType>>($"news/types", data.Expected);
		}

		[Theory]
		[JsonData("news", "news-tag-categories.json")]
		public async Task ShouldGetNewsCategories(NewsTagCategoriesTestData data)
		{
			await TestResponse<IEnumerable<NewsTagCategory>>($"news/categories", data.Expected);
		}

		[Theory]
		[JsonData("news", "news-related.json")]
		public async Task ShouldGetRelatedNews(RelatedNewsTestData data)
		{
			await TestResponse<IEnumerable<NewsSummary>>(
				$"news/related/{data.NewsId}?before={data.Before.ToString("yyyy-MM-dd")}&count={data.Count}", data.Expected);
		}

		[Theory]
		[JsonData("news", "search-news.json")]
		public async Task ShouldGetSearchResults(SearchNewsTestData data)
		{
			await TestResponse<PagedResult<NewsSummary>>($"news/search/{data.Term}?page={data.Page}&countPerPage={data.CountPerPage}&before={data.Before.ToString("yyyy-MM-dd")}", data.Expected);
		}

		[Fact]
		public async Task ShouldGetImportantNews()
		{
			var newsList = await Get<IEnumerable<ImportantNewsSummary>>("news/important");

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
			var response = await Post<string, string>($"news/{id}/views/increment", "", false);
		}

		[Fact]
		public async Task ShouldGetNewsTags()
		{
			int count = 5;
			var result = await Get<PagedResult<NewsTag>>($"news/tags?countPerPage={count}");

			Assert.NotNull(result.Result);
			Assert.Equal(count, result.PageSize);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal((int)1, result.CurrentPage);
			Assert.True(result.PageCount > 0);
			var tagsList = result.Result;
			Assert.NotNull(tagsList);
			Assert.Equal(count, (int)tagsList.Count());
			Assert.All(tagsList, tag =>
			{
				Assert.NotEqual((int)0, tag.Id);
				Assert.NotEqual((int)0, tag.CategoryId);
				Assert.False(string.IsNullOrWhiteSpace(tag.Title));
			});
		}

		[Fact]
		public async Task ShouldGetNewsTagsByCategoryId()
		{
			var id = 2;
			int count = 5;

			var result = await Get<PagedResult<NewsTag>>($"news/tags?categoryId={id}&countPerPage={count}");

			Assert.NotNull(result.Result);
			Assert.Equal(count, result.PageSize);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal((int)1, result.CurrentPage);
			Assert.True(result.PageCount > 0);
			var tagsList = result.Result;
			Assert.NotNull(tagsList);
			Assert.Equal(count, (int)tagsList.Count());
			Assert.All(tagsList, tag =>
			{
				Assert.NotEqual((int)0, tag.Id);
				Assert.False(string.IsNullOrWhiteSpace(tag.Title));
				Assert.Equal((int)id, tag.CategoryId);
			});
		}

		[Fact]
		public async Task ShouldGetNewsByTypeId()
		{
			var typeId = 5;
			int count = 7;

			var result = await Get<PagedResult<NewsSummary>>($"news?typeId={typeId}&countPerPage={count}");

			Assert.NotNull(result.Result);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal(count, result.PageSize);
			Assert.Equal(count, (int)result.Result.Count());
			Assert.Equal((int)1, result.CurrentPage);
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
				Assert.NotEqual((int)0, news.Id);
			});
		}

		[Fact]
		public async Task ShouldGetNewsByTagId()
		{
			var tagId = 2;
			int count = 7;

			var result = await Get<PagedResult<NewsSummary>>($"news?tagId={tagId}&countPerPage={count}");

			Assert.NotNull(result.Result);
			Assert.True(result.RowCount >= result.PageSize);
			Assert.Equal(count, result.PageSize);
			Assert.Equal(count, (int)result.Result.Count());
			Assert.Equal((int)1, result.CurrentPage);
			Assert.True(result.PageCount > 0);
			var newsList = result.Result;
			Assert.NotNull(newsList);
			Assert.All(newsList, news =>
			{
				Assert.NotNull(news.Title);
				Assert.NotNull(news.Subtitle);
				Assert.False(string.IsNullOrWhiteSpace(news.MainTagIcon));
				Assert.True(0 <= news.CommentCount);
				Assert.NotEqual((int)0, news.Id);
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
			public int CountPerPage { get; set; }
			public int Page { get; set; }
			public PagedResult<NewsSummary> Expected { get; set; }
		}

		public class RelatedNewsTestData
		{
			public int NewsId { get; set; }
			public DateTime Before { get; set; }
			public int Count { get; set; }
			public IEnumerable<NewsSummary> Expected { get; set; }
		}

		public class SearchNewsTestData
		{
			public DateTime Before { get; set; }
			public int CountPerPage { get; set; }
			public string Term { get; set; }
			public int Page { get; set; }
			public PagedResult<NewsSummary> Expected { get; set; }
		}

		public class NewsTypesTestData
		{
			public IEnumerable<NewsType> Expected { get; set; }
		}

		public class NewsTagCategoriesTestData
		{
			public IEnumerable<NewsTagCategory> Expected { get; set; }
		}
	}
}

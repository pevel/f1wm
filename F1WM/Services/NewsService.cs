using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel.Constants;
using F1WM.Repositories;
using F1WM.Utilities;
using Narochno.BBCode;

namespace F1WM.Services
{
	public class NewsService : INewsService
	{
		private readonly INewsRepository newsRepository;
		private readonly IConfigRepository config;
		private readonly IBBCodeParser bBCodeParser;
		private readonly ITimeService time;

		public Task<PagedResult<NewsSummary>> GetLatestNews(int? firstId, int page, int countPerPage)
		{
			return newsRepository.GetLatestNews(firstId, page, countPerPage);
		}

		public async Task<NewsDetails> GetNewsDetails(int id)
		{
			var news = await newsRepository.GetNewsDetails(id);
			if (news != null)
			{
				news.Text = WebUtility.HtmlDecode(bBCodeParser.ToHtml(news.Text.Cleanup()));
				news = news.ParseCustomFormatting();
			}
			return news;
		}

		public async Task<IEnumerable<ImportantNewsSummary>> GetImportantNews()
		{
			var configText = await config.GetConfigText(ConfigTextName.ImportantNews);
			if (configText != null && !string.IsNullOrWhiteSpace(configText.Value))
			{
				var summaries = new List<ImportantNewsSummary>();
				using (StringReader reader = new StringReader(configText.Value))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						summaries.Add(line.ParseImportantNews());
					}
				}
				foreach (var news in await newsRepository.GetNews(summaries.Select(s => (int)s.Id).ToList()))
				{
					summaries.First(s => s.Id == news.Id).Title = news.Title;
				}
				return summaries;
			}
			return new List<ImportantNewsSummary>();
		}

		public Task<PagedResult<NewsSummary>> GetNewsByTagId(int id, int page, int countPerPage)
		{
			return newsRepository.GetNewsByTagId(id, page, countPerPage);
		}

		public Task<PagedResult<NewsSummary>> GetNewsByTypeId(int id, int page, int countPerPage)
		{
			return newsRepository.GetNewsByTypeId(id, page, countPerPage);
		}

		public Task<IEnumerable<ApiModel.NewsType>> GetNewsTypes()
		{
			return newsRepository.GetNewsTypes();
		}

		public Task<PagedResult<ApiModel.NewsTag>> GetNewsTags(int page, int countPerPage)
		{
			return newsRepository.GetNewsTags(page, countPerPage);
		}

		public Task<PagedResult<ApiModel.NewsTag>> GetNewsTagsByCategoryId(int id, int page, int countPerPage)
		{
			return newsRepository.GetNewsTagsByCategoryId(id, page, countPerPage);
		}

		public Task<IEnumerable<ApiModel.NewsTagCategory>> GetNewsTagCategories()
		{
			return newsRepository.GetNewsTagCategories();
		}

		public async Task<bool> IncrementViews(int id)
		{
			var success = await newsRepository.IncrementViews(id);
			return success;
		}

		public async Task<IEnumerable<NewsSummary>> GetRelatedNews(int newsId, DateTime? before, int? count)
		{
			return await newsRepository.GetRelatedNews(newsId, before ?? time.Now, count ?? 5);
		}

		public async Task<PagedResult<NewsSummary>> SearchNews(string term, int page, int countPerPage, DateTime? before)
		{
			return await newsRepository.SearchNews(term, page, countPerPage, before ?? time.Now);
		}

		public NewsService(
			INewsRepository newsRepository,
			IConfigRepository config,
			IBBCodeParser bbCodeParser,
			ITimeService time)
		{
			this.newsRepository = newsRepository;
			this.config = config;
			this.bBCodeParser = bbCodeParser;
			this.time = time;
		}
	}
}

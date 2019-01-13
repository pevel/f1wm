using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DatabaseModel.Constants;
using F1WM.Repositories;
using F1WM.Utilities;
using Narochno.BBCode;

namespace F1WM.Services
{
	public class NewsService : INewsService
	{
		private readonly INewsRepository newsRepository;
		private readonly IConfigTextRepository configTextRepository;
		private readonly IBBCodeParser bBCodeParser;

		public async Task<IEnumerable<NewsSummary>> GetLatestNews(int count, int? firstId)
		{
			var news = await newsRepository.GetLatestNews(count, firstId);
			return news.Select(n => n.ResolveTopicIcon());
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

        public async Task<IEnumerable<NewsSummary>> GetNewsByTagId(int? id, int page, int countPerPage)
        {
            var news = await newsRepository.GetNewsByTagId(id, page, countPerPage);
            return news.Select(n => n.ResolveTopicIcon());
        }

        public async Task<IEnumerable<NewsSummary>> GetNewsByTypeId(int? id, int page, int countPerPage)
        {
            var news = await newsRepository.GetNewsByTypeId(id, page, countPerPage);
            return news.Select(n => n.ResolveTopicIcon());
        }

        public async Task<IEnumerable<NewsType>> GetNewsTypes()
        {
            return await newsRepository.GetNewsTypes();
        }

        public async Task<IEnumerable<NewsTag>> GetNewsTags()
        {
            return await newsRepository.GetNewsTags();
        }

        public async Task<IEnumerable<NewsTag>> GetNewsTagsByCategoryId(int? id)
        {
            return await newsRepository.GetNewsTagsByCategoryId(id);
        }
        
        public async Task<IEnumerable<NewsCategory>> GetNewsCategories()
        {
            return await newsRepository.GetNewsCategories();
        }

        public async Task<IEnumerable<ImportantNewsSummary>> GetImportantNews()
		{
			var configText = await configTextRepository.GetConfigText(ConfigTextName.ImportantNews);
			if (configText != null && !string.IsNullOrWhiteSpace(configText.Value))
			{
				var summaries = new List<ImportantNewsSummary>();
				using(StringReader reader = new StringReader(configText.Value))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						summaries.Add(line.ParseImportantNews());
					}
				}
				foreach (var news in await newsRepository.GetNews(summaries.Select(s => (uint)s.Id).ToList()))
				{
					summaries.First(s => s.Id == news.Id).Title = news.Title;
				}
				return summaries;
			}
			return new List<ImportantNewsSummary>();
		}

		public NewsService(INewsRepository newsRepository, IConfigTextRepository configTextRepository, IBBCodeParser bbCodeParser)
		{
			this.newsRepository = newsRepository;
			this.configTextRepository = configTextRepository;
			this.bBCodeParser = bbCodeParser;
		}
	}
}
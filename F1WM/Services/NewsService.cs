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

        public async Task<IEnumerable<NewsSummary>> GetNewsByTag(int id)
        {
            var news = await newsRepository.GetNewsByTag(id);
            return news.Select(n => n.ResolveTopicIcon());
        }

        public async Task<IEnumerable<NewsSummary>> GetNewsByType(int id)
        {
            var news = await newsRepository.GetNewsByType(id);
            return news.Select(n => n.ResolveTopicIcon());
        }

        public async Task<IEnumerable<NewsType>> GetNewsTypes()
        {
            var types = await newsRepository.GetNewsTypes();
            return types;
        }

        public async Task<IEnumerable<NewsTag>> GetNewsTags()
        {
            var types = await newsRepository.GetNewsTags();
            return types;
        }

        public async Task<IEnumerable<NewsTag>> GetNewsTagsByCategory(int id)
        {
            var types = await newsRepository.GetNewsTagsByCategory(id);
            return types;
        }
        
        public async Task<IEnumerable<NewsCategory>> GetNewsCategories()
        {
            var types = await newsRepository.GetNewsCategories();
            return types;
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
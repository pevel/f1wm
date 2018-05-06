using System.Collections.Generic;
using System.Linq;
using System.Net;
using F1WM.ApiModel;
using F1WM.Repositories;
using F1WM.Utilities;
using Narochno.BBCode;

namespace F1WM.Services
{
	public class NewsService : INewsService
	{
		private INewsRepository repository;
		private IBBCodeParser bBCodeParser;

		public IEnumerable<NewsSummary> GetLatestNews(int count, int? firstId)
		{
			return this.repository.GetLatestNews(count, firstId).Select(n => n.ResolveTopicIcon());
		}

		public NewsDetails GetNewsDetails(int id)
		{
			var news = this.repository.GetNewsDetails(id);
			if (news != null)
			{
				news.Text = WebUtility.HtmlDecode(this.bBCodeParser.ToHtml(news.Text.Cleanup()));
				news = news.ParseCustomFormatting();
			}
			return news;
		}

		public NewsService(INewsRepository repository, IBBCodeParser bbCodeParser)
		{
			this.repository = repository;
			this.bBCodeParser = bbCodeParser;
		}
	}
}
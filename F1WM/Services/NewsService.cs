using System.Collections.Generic;
using F1WM.Model;
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
			return this.repository.GetLatestNews(count, firstId);
		}

		public NewsDetails GetNewsDetails(int id)
		{
			var news = this.repository.GetNewsDetails(id);
			news.Text = this.bBCodeParser.ToHtml(news.Text).ParseImageInformation();
			return news;
		}

		public NewsService(INewsRepository repository, IBBCodeParser bbCodeParser)
		{
			this.repository = repository;
			this.bBCodeParser = bbCodeParser;
		}
	}
}
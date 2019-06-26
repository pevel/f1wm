using System;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class RSSService : IRSSService
	{
		private readonly ITimeService time;
		private readonly IConfigTextRepository config;
		private readonly INewsRepository news;

		public Task<SyndicationFeed> GetFeed(DateTime? before = null)
		{
			throw new NotImplementedException();
		}

		public RSSService(
			ITimeService time,
			IConfigTextRepository config,
			INewsRepository news)
		{
			this.time = time;
			this.config = config;
			this.news = news;
		}
	}
}

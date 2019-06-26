using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DatabaseModel.Constants;
using F1WM.Repositories;

namespace F1WM.Services
{
	public class RSSService : IRSSService
	{
		private readonly ITimeService time;
		private readonly IConfigRepository config;
		private readonly INewsRepository news;

		public Task<SyndicationFeed> GetFeed(DateTime? before = null)
		{
			return GetEmptyFeedWithMetadata();
		}

		public Task<RSSFeedConfiguration> AddConfiguration(RSSFeedConfigurationAddRequest request)
		{
			throw new NotImplementedException();
		}

		public RSSService(
			ITimeService time,
			IConfigRepository config,
			INewsRepository news)
		{
			this.time = time;
			this.config = config;
			this.news = news;
		}

		private async Task<SyndicationFeed> GetEmptyFeedWithMetadata()
		{
			var metadataKeys = new string[]
			{
				ConfigTextName.RssCopyright,
				ConfigTextName.RssDescription,
				ConfigTextName.RssLanguage,
				ConfigTextName.RssLink,
				ConfigTextName.RssTitle
			};
			var metadata = await config.GetConfigTexts(metadataKeys);
			if (metadata.Any(m => m.Value != null))
			{
				var feed = new SyndicationFeed();
				feed.Title = new TextSyndicationContent(metadata.Get(ConfigTextName.RssTitle));
				feed.Description = new TextSyndicationContent(metadata.Get(ConfigTextName.RssDescription));
				feed.Copyright = new TextSyndicationContent(metadata.Get(ConfigTextName.RssCopyright));
				feed.Links.Add(new SyndicationLink(new Uri(ConfigTextName.RssLink)));
				feed.Language = metadata.Get(ConfigTextName.RssLanguage);
				return feed;
			}
			else
			{
				throw new Exception("Misconfigured RSS");
			}
		}
	}
}

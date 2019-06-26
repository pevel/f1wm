using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using AutoMapper;
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
		private readonly IMapper mapper;

		public Task<SyndicationFeed> GetFeed(DateTime? before = null)
		{
			return GetEmptyFeedWithMetadata();
		}

		public async Task<RSSFeedConfiguration> AddConfiguration(RSSFeedConfigurationAddRequest request)
		{
			var configs = mapper.Map<IEnumerable<ConfigText>>(request);
			configs = await config.AddConfigTexts(ConfigSectionName.RSS, configs);
			return mapper.Map<RSSFeedConfiguration>(configs);
		}

		public RSSService(
			ITimeService time,
			IConfigRepository config,
			INewsRepository news,
			IMapper mapper)
		{
			this.time = time;
			this.config = config;
			this.news = news;
			this.mapper = mapper;
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

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
using F1WM.Utilities;

namespace F1WM.Services
{
	public class RSSService : IRSSService
	{
		private readonly ITimeService time;
		private readonly IConfigRepository config;
		private readonly INewsRepository news;
		private readonly IMapper mapper;
		private const int itemsCount = 20;

		public async Task<SyndicationFeed> GetFeed(int? firstId = null)
		{
			var feed = await GetEmptyFeedWithMetadata();
			feed.Items = await GetNewsItems(firstId, feed.Links.First().Uri.ToString());
			return feed;
		}

		public async Task<RSSFeedConfiguration> UpdateOrAddConfiguration(RSSFeedConfigurationEditRequest request)
		{
			var configs = mapper.Map<IEnumerable<ConfigText>>(request);
			configs = await config.UpdateOrAddConfigTexts(ConfigSectionName.RSS, configs);
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
				ConfigTextName.RssTitle,
				ConfigTextName.RssImageUrl
			};
			var metadata = await config.GetConfigTexts(metadataKeys);
			if (metadata.Any(m => m.Value != null))
			{
				var feed = new SyndicationFeed(
					metadata.Get(ConfigTextName.RssTitle),
					metadata.Get(ConfigTextName.RssDescription),
					new Uri(metadata.Get(ConfigTextName.RssLink))
				);
				feed.Copyright = new TextSyndicationContent(String.Format(metadata.Get(ConfigTextName.RssCopyright), time.Now.Year));
				feed.Language = metadata.Get(ConfigTextName.RssLanguage);
				feed.ImageUrl = new Uri(metadata.Get(ConfigTextName.RssImageUrl));
				feed.LastUpdatedTime = time.Now.ToUniversalTime();
				return feed;
			}
			else
			{
				throw new Exception("Misconfigured RSS");
			}
		}

		private async Task<IEnumerable<SyndicationItem>> GetNewsItems(int? firstId, string baseUrl)
		{
			var latestNews = await news.GetLatestNews(firstId, 1, itemsCount);
			return latestNews.Result.Select(news =>
			{
				var item = new SyndicationItem();
				item.Title = new TextSyndicationContent(news.Title);
				item.Summary = new TextSyndicationContent(news.Subtitle);
				item.PublishDate = news.Date.ToUniversalTime();
				item.Links.Add(news.GetLink(baseUrl));
				return item;
			});
		}
	}
}

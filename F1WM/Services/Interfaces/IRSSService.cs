using System;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IRSSService
	{
		Task<SyndicationFeed> GetFeed(DateTime? before = null);
		Task<RSSFeedConfiguration> AddConfiguration(RSSFeedConfigurationAddRequest request);
	}
}

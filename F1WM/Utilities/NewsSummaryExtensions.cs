using System;
using System.ServiceModel.Syndication;
using F1WM.ApiModel;

namespace F1WM.Utilities
{
	public static class NewsSummaryExtensions
	{
		public static SyndicationLink GetLink(this NewsSummary news, string baseUrl)
		{
			return new SyndicationLink(new Uri($"{baseUrl}news/{news.Id}"));
		}
	}
}

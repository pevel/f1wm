using System;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;

namespace F1WM.Services
{
	public interface IRSSService
	{
		Task<SyndicationFeed> GetFeed(DateTime? before = null);
	}
}

using System.Collections.Generic;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DatabaseModel.Constants;

namespace F1WM.Mapping
{
	public class RSSMappingProfile : Profile
	{
		public RSSMappingProfile()
		{
			CreateMap<RSSFeedConfigurationAddRequest, IEnumerable<ConfigText>>()
				.ConstructUsing(api => new List<ConfigText>()
				{
					new ConfigText() { Name = ConfigTextName.RssCopyright, Value = api.Copyright },
					new ConfigText() { Name = ConfigTextName.RssDescription, Value = api.Description },
					new ConfigText() { Name = ConfigTextName.RssLanguage, Value = api.Language },
					new ConfigText() { Name = ConfigTextName.RssLink, Value = api.Link },
					new ConfigText() { Name = ConfigTextName.RssTitle, Value = api.Title } 
				});
			CreateMap<IEnumerable<ConfigText>, RSSFeedConfiguration>()
				.ConstructUsing(db => new RSSFeedConfiguration()
				{
					Copyright = db.Get(ConfigTextName.RssCopyright),
					Description = db.Get(ConfigTextName.RssDescription),
					Language = db.Get(ConfigTextName.RssLanguage),
					Link = db.Get(ConfigTextName.RssLink),
					Title = db.Get(ConfigTextName.RssTitle) 
				});
		}
	}
}

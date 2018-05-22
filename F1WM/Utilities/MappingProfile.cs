using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<NewsComment, Comment>()
				.ForMember(api => api.Text, o => o.MapFrom(db => db.Text.CommText));
			CreateMap<News, NewsSummary>()
				.ForMember(api => api.TopicIcon, o => o.MapFrom(db => db.Topic.TopicIcon));
			CreateMap<News, NewsDetails>();
			CreateMap<ConstructorStandingsPosition, ConstructorPosition>();
		}
	}
}
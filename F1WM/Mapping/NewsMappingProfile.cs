using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Mapping
{
	public class NewsMappingProfile : Profile
	{
		public NewsMappingProfile()
		{
			CreateMap<News, NewsSummary>()
				.ForMember(api => api.TopicIcon, o => o.MapFrom(db => db.Topic.TopicIcon))
                .ForMember(api => api.IsHighlighted, o => o.MapFrom(db => db.NewsHighlight));
            CreateMap<News, NewsDetails>();
		}
	}
}
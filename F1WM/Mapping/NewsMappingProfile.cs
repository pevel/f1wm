using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class NewsMappingProfile : Profile
	{
		public NewsMappingProfile()
		{
			CreateMap<News, NewsSummary>()
				.ForMember(api => api.MainTagIcon, o => o.MapFrom(db => db.MainTag.Icon.GetGenericIconPath()));
			CreateMap<News, NewsDetails>()
				.ForMember(api => api.Text, o => o.MapFrom(db => db.Article != null ? db.Article.Text : db.Text));
		}
	}
}

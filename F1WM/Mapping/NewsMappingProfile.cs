using AutoMapper;
using Api = F1WM.ApiModel;
using Db = F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class NewsMappingProfile : Profile
	{
		public NewsMappingProfile()
		{
			CreateMap<Db.News, Api.NewsSummary>()
				.ForMember(api => api.MainTagIcon, o => o.MapFrom(db => db.MainTag.Icon.GetGenericIconPath()));
			CreateMap<Db.News, Api.NewsDetails>()
				.ForMember(api => api.Text, o => o.MapFrom(db => db.Article != null ? db.Article.Text : db.Text));
			CreateMap<Db.NewsTag, Api.NewsTag>();
			CreateMap<Db.NewsTagCategory, Api.NewsTagCategory>();
			CreateMap<Db.NewsType, Api.NewsType>();
		}
	}
}

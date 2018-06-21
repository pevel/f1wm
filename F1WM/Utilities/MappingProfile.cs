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
			CreateMap<ConstructorStandingsPosition, ConstructorPosition>()
				.ForMember(api => api.ConstructorName, o => o.MapFrom(db => db.CarMake.Name))
				.ForMember(api => api.Nationality, o =>
				{
					o.MapFrom(db => new ApiModel.Nationality()
					{
						Name = db.CarMake.Nationality.Name,
						FlagIcon = db.CarMake.NationalityKey.GetFlagIconPath()
					});
				});
			CreateMap<DriverStandingsPosition, DriverPosition>()
				.ForMember(api => api.DriverName, o => o.MapFrom(db => $"{db.Driver.Initial} {db.Driver.Surname}"))
				.ForMember(api => api.Nationality, o =>
				{
					o.MapFrom(db => new ApiModel.Nationality()
					{
						Name = db.Driver.Nationality.Name,
						FlagIcon = db.Driver.NationalityKey.GetFlagIconPath()
					});
				});
		}
	}
}
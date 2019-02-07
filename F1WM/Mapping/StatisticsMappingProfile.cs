using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Mapping
{
	public class StatisticsProfile : Profile
	{
		public StatisticsProfile()
		{
			CreateMap<DriverStandingsPosition, DriverSeason>()
				.ForMember(api => api.Points, o => o.Ignore());
			CreateMap<Season, DriverSeason>()
				.ForMember(api => api.Season, o => o.MapFrom(db => db));
			CreateMap<Season, TeamSeason>()
				.ForMember(api => api.Season, o => o.MapFrom(db => db));
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class StatisticsProfile : Profile
	{
		public StatisticsProfile()
		{
			CreateMap<Season, DriverSeason>()
				.ForMember(api => api.Season, o => o.MapFrom(db => db));
			CreateMap<Season, TeamSeason>()
				.ForMember(api => api.Season, o => o.MapFrom(db => db));
		}
	}
}

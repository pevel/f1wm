using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class SharedMappingProfile : Profile
	{
		public SharedMappingProfile()
		{
			CreateMap<Constructor, ConstructorSummary>();
			CreateMap<Driver, DriverSummary>();
			CreateMap<Driver, DriverBase>();
			CreateMap<DatabaseModel.Country, ApiModel.Country>()
				.ForMember(api => api.FlagIcon, o => o.MapFrom(db => db.Key.GetFlagIconPath()));
			CreateMap<DatabaseModel.Track, TrackSummary>()
				.ForMember(api => api.TrackIcon, o => o.MapFrom(db => db.Key.GetTrackIconPath()));
			CreateMap<Car, CarSummary>();
			CreateMap<Race, RaceSummary>()
				.ForMember(api => api.RaceId, o => o.MapFrom(db => db.Id))
				.ForMember(api => api.Name, o => o.MapFrom(db => db.Country.GenitiveName.GetGrandPrixName()));
			CreateMap<Team, TeamSummary>()
				.ForMember(api => api.Logo, o => o.MapFrom(db => db.Key.IgnoreEmpty().GetTeamLogoPath()));
			CreateMap<Season, SeasonSummary>();
		}
	}
}

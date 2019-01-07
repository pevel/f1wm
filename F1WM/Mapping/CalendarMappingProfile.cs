using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class CalendarMappingProfile : Profile
	{
		public CalendarMappingProfile()
		{
			CreateMap<Race, CalendarRace>()
				.ForMember(api => api.TranslatedName, o => o.MapFrom(db => db.Country.GenitiveName.GetGrandPrixName()))
				.ForMember(api => api.WinnerRaceResult, o => o.MapFrom(db => db.Results))
				.ForMember(api => api.FastestLapResult, o => o.MapFrom(db => db.FastestLap));
			CreateMap<Grid, LapResultSummary>()
				.ForMember(api => api.Driver, o => o.MapFrom(db => db.Entry.Driver));
		}
	}
}
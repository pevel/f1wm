using System;
using System.Linq;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class RacesMappingProfile : Profile
	{
		public RacesMappingProfile()
		{
			CreateMap<Race, NextRaceSummary>()
				.ForMember(api => api.TranslatedName, o => o.MapFrom(db => db.Country.GenitiveName.GetGrandPrixName()));
			CreateMap<Race, LastRaceSummary>()
				.ForMember(api => api.TranslatedName, o => o.MapFrom(db => db.Country.GenitiveName.GetGrandPrixName()))
				.ForMember(api => api.FastestLapResult, o => o.MapFrom(db => db.FastestLaps.FirstOrDefault()));
		}
	}
}

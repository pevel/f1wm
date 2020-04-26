using System.Linq;
using AutoMapper;
using Api = F1WM.ApiModel;
using Db = F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class RacesMappingProfile : Profile
	{
		public RacesMappingProfile()
		{
			CreateMap<Db.Race, Api.NextRaceSummary>()
				.ForMember(api => api.TranslatedName, o => o.MapFrom(db => db.Country.GenitiveName.GetGrandPrixName()));
			CreateMap<Db.Race, Api.LastRaceSummary>()
				.ForMember(api => api.TranslatedName, o => o.MapFrom(db => db.Country.GenitiveName.GetGrandPrixName()))
				.ForMember(api => api.FastestLapResult, o => o.MapFrom(db => db.FastestLaps.FirstOrDefault()));
			CreateMap<Db.FastestLap, Api.RaceFastestLap>()
				.ForMember(api => api.Car, o => o.MapFrom(db => db.Entry.Car))
				.ForMember(api => api.Driver, o => o.MapFrom(db => db.Entry.Driver))
				.ForMember(api => api.Number, o => o.MapFrom(db => db.Entry.Number))
				.ForMember(api => api.Tyres, o => o.MapFrom(db => db.Entry.Tyres));
			CreateMap<Db.Race, Api.RaceSummary>()
				.ForMember(api => api.RaceId, o => o.MapFrom(db => db.Id))
				.ForMember(api => api.Name, o => o.MapFrom(db => db.Country.GenitiveName.GetGrandPrixName()));
			CreateMap<Db.RaceNews, Api.RaceNews>();
			CreateMap<Db.Entry, Api.RaceResultSummary>();
		}
	}
}

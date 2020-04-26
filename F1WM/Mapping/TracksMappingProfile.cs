using System.Linq;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DomainModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class TracksMappingProfile : Profile
	{
		public TracksMappingProfile()
		{
			CreateMap<DatabaseModel.Track, ApiModel.Track>()
				.ForMember(api => api.Status, o => o.MapFrom(db => (TrackStatus)db.Status))
				.ForMember(api => api.TrackIcon, o => o.MapFrom(db => db.Key.GetTrackIconPath()));
			CreateMap<DatabaseModel.Track, ApiModel.TrackDetails>()
				.ForMember(api => api.Status, o => o.MapFrom(db => (TrackStatus)db.Status))
				.ForMember(api => api.LastRace, o => o.MapFrom(db => db.Races.OrderByDescending(r => r.Date).First()))
				.ForMember(api => api.Website, o => o.MapFrom(db => db.Website.Url))
				.ForMember(api => api.Image, o => o.MapFrom(db => db.Key.GetTrackImagePath()))
				.ForMember(api => api.TrackIcon, o => o.MapFrom(db => db.Key.GetTrackIconPath()));
			CreateMap<Race, TrackRaceSummary>()
				.ForMember(api => api.LapLength, o => o.MapFrom(db => (db.Distance + db.Offset) / db.Laps))
				.ForMember(api => api.RaceId, o => o.MapFrom(db => db.Id))
				.ForMember(api => api.TranslatedName, o => o.MapFrom(db => db.Country.GenitiveName.GetGrandPrixName()));
			CreateMap<Grid, TrackLapResultSummaryByYear>()
				.ForMember(domain => domain.Year, o => o.MapFrom(db => db.Race.Date.Year))
				.ForMember(domain => domain.Driver, o => o.MapFrom(db => db.Entry.Driver))
				.ForMember(domain => domain.Team, o => o.MapFrom(db => db.Entry.Team));
			CreateMap<FastestLap, TrackLapResultSummaryByYear>()
				.ForMember(domain => domain.Year, o => o.MapFrom(db => db.Race.Date.Year))
				.ForMember(domain => domain.Driver, o => o.MapFrom(db => db.Entry.Driver))
				.ForMember(domain => domain.Team, o => o.MapFrom(db => db.Entry.Team));
			CreateMap<Result, TrackRaceResultSummaryByYear>()
				.ForMember(domain => domain.Year, o => o.MapFrom(db => db.Race.Date.Year))
				.ForMember(domain => domain.Driver, o => o.MapFrom(db => db.Entry.Driver))
				.ForMember(domain => domain.Team, o => o.MapFrom(db => db.Entry.Team));
			CreateMap<DatabaseModel.Track, TrackSummary>()
				.ForMember(api => api.TrackIcon, o => o.MapFrom(db => db.Key.GetTrackIconPath()));
		}
	}
}

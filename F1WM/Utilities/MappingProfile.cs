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
			CreateMap<ConstructorStandingsPosition, ConstructorPosition>();
			CreateMap<Constructor, ConstructorSummary>();
			CreateMap<DriverStandingsPosition, DriverPosition>();
			CreateMap<Driver, DriverSummary>();
			CreateMap<DatabaseModel.Country, ApiModel.Country>()
				.ForMember(api => api.FlagIcon, o => o.MapFrom(db => db.Key.GetFlagIconPath()));
			CreateMap<Race, NextRaceSummary>()
				.ForMember(api => api.TranslatedName, o => o.MapFrom(db => db.Country.GenitiveName.GetGrandPrixName()));
			CreateMap<Track, TrackSummary>()
				.ForMember(api => api.TrackIcon, o => o.MapFrom(db => db.Ascid.GetTrackIconPath()));
			CreateMap<Entry, LapResultSummary>()
				.ForMember(api => api.Time, o => o.MapFrom(db => db.GetLapTime()));
			CreateMap<Entry, RaceResultSummary>()
				.ForMember(api => api.Time, o => o.MapFrom(db => db.Result.Time));
			CreateMap<Result, RaceResultPosition>()
				.ForMember(api => api.NotFinishedReason, o => o.MapFrom(db => db.Info))
				.ForMember(api => api.Status, o => o.MapFrom(db => db.Status.GetResultStatus()));
		}
	}
}
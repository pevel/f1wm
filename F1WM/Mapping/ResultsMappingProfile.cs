using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class ResultsMappingProfile : Profile
	{
		public ResultsMappingProfile()
		{
			CreateMap<Entry, LapResultSummary>()
				.ForMember(api => api.Time, o => o.MapFrom(db => db.GetLapTime()));
			CreateMap<Entry, RaceResultSummary>()
				.ForMember(api => api.Time, o => o.MapFrom(db => db.Result.Time));
			CreateMap<Result, RaceResultPosition>()
				.ForMember(api => api.Status, o => o.MapFrom(db => db.Status.GetResultStatus()))
				.ForMember(api => api.Driver, o => o.MapFrom(db => db.Entry.Driver))
				.ForMember(api => api.Car, o => o.MapFrom(db => db.Entry.Car))
				.ForMember(api => api.Number, o => o.MapFrom(db => db.Entry.Number))
				.ForMember(api => api.StartStatus, o => o.MapFrom(db => db.Entry.Grid.StartStatus.GetStartStatus()))
				.ForMember(api => api.StartPosition, o => o.MapFrom(db => db.Entry.Grid.StartPosition))
				.ForMember(api => api.Tyres, o => o.MapFrom(db => db.Entry.Tyres.Name));
			CreateMap<FastestLap, FastestLapResultSummary>()
				.ForMember(api => api.Car, o => o.MapFrom(db => db.Entry.Car))
				.ForMember(api => api.Driver, o => o.MapFrom(db => db.Entry.Driver));
			CreateMap<FastestLap, FastestLapResultSummary>()
				.ForMember(api => api.Car, o => o.MapFrom(db => db.Entry.Car))
				.ForMember(api => api.Driver, o => o.MapFrom(db => db.Entry.Driver));
			CreateMap<Qualifying, QualifyingResultPosition>()
				.ForMember(api => api.Driver, o => o.MapFrom(db => db.Entry.Driver))
				.ForMember(api => api.Car, o => o.MapFrom(db => db.Entry.Car))
				.ForMember(api => api.Number, o => o.MapFrom(db => db.Entry.Number))
				.ForMember(api => api.Status, o => o.MapFrom(db => db.Status.GetQualifyStatus()))
				.AfterMap((db, api) => db.FillSessionsInfo(api));
			CreateMap<Grid, QualifyingResultPosition>()
				.ForMember(api => api.Driver, o => o.MapFrom(db => db.Entry.Driver))
				.ForMember(api => api.Car, o => o.MapFrom(db => db.Entry.Car))
				.ForMember(api => api.Number, o => o.MapFrom(db => db.Entry.Number))
				.ForMember(api => api.FinishPosition, o => o.MapFrom(db => db.StartPosition))
				.ForMember(api => api.Status, o => o.MapFrom(db => db.StartStatus.GetQualifyStatus()))
				.AfterMap((db, api) => db.FillSessionsInfo(api));
			CreateMap<OtherSession, PracticeSessionResultPosition>()
				.ForMember(api => api.Driver, o => o.MapFrom(db => db.Entry.Driver))
				.ForMember(api => api.Car, o => o.MapFrom(db => db.Entry.Car))
				.ForMember(api => api.Number, o => o.MapFrom(db => db.Entry.Number));
		}
	}
}
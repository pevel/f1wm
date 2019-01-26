using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class DriversMappingProfile : Profile
	{
		public DriversMappingProfile()
		{
			CreateMap<Driver, DriverDetails>()
				.ForMember(api => api.Picture, o => o.MapFrom(db => db.Key.GetDriverPicturePath()))
				.ForMember(api => api.Residence, o => o.MapFrom(db => db.Residence.IgnoreEmpty()))
				.ForMember(api => api.Height, o => o.MapFrom(db => db.Height.IgnoreEmpty()))
				.ForMember(api => api.Weight, o => o.MapFrom(db => db.Weight.IgnoreEmpty()))
				.ForMember(api => api.MaritalStatus, o => o.MapFrom(db => db.MaritalStatus.IgnoreEmpty()))
				.ForMember(api => api.DeathPlace, o => o.MapFrom(db => db.DeathPlace.IgnoreEmpty()))
				.ForMember(api => api.Kids, o => o.MapFrom(db => db.Kids.IgnoreEmpty()))
				.ForMember(api => api.ChampionAtSeries, o => o.MapFrom(db => db.GetSeriesChampionInfo()))
				.ForMember(api => api.CareerYears, o => o.MapFrom(db => db.ParseCareerInfo()))
				.ForMember(api => api.Website, o => o.MapFrom(db => db.Link.Url));
			CreateMap<Race, RaceSummary>()
				.ForMember(api => api.RaceId, o => o.MapFrom(db => db.Id))
				.ForMember(api => api.Name, o => o.MapFrom(db => db.Country.GenitiveName.GetGrandPrixName()));
		}
	}
}

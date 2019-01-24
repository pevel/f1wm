using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class GridsMappingProfile : Profile
	{
		public GridsMappingProfile()
		{
			CreateMap<Grid, GridPosition>()
				.ForMember(api => api.Car, o => o.MapFrom(db => db.Entry.Car))
				.ForMember(api => api.Driver, o => o.MapFrom(db => db.Entry.Driver));
			CreateMap<Driver, GridDriverSummary>()
				.ForMember(api => api.Picture, o => o.MapFrom(db => db.Key.GetDriverPicturePath()));
		}
	}
}

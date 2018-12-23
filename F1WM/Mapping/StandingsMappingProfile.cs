using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Mapping
{
	public class StandingsMappingProfile : Profile
	{
		public StandingsMappingProfile()
		{
			CreateMap<ConstructorStandingsPosition, ConstructorPosition>();
			CreateMap<DriverStandingsPosition, DriverPosition>();
		}
	}
}
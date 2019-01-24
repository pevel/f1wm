using System;
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
			CreateMap<Driver, DriverDetails>();
		}
	}
}

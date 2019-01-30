using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class EnginesMappingProfile : Profile
	{
		public EnginesMappingProfile()
		{
			CreateMap<Engine, EngineDetails>()
				.ForMember(api => api.Specifications, o => o.MapFrom(db => db.EngineSpecification.Parse()));
		}
	}
}

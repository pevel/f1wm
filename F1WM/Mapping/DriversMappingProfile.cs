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
				.ForMember(api => api.DeathPlace, o => o.MapFrom(db => db.DeathPlace.IgnoreEmpty()))
				.ForMember(api => api.Kids, o => o.MapFrom(db => db.Kids.IgnoreEmpty()))
				.ForMember(api => api.Website, o => o.MapFrom(db => db.Link.Url));
		}
	}
}

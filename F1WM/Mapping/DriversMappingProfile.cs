using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Mapping
{
	public class DriversMappingProfile : Profile
	{
		public DriversMappingProfile()
		{
			CreateMap<Driver, DriverDetails>()
				.ForMember(api => api.Website, o => o.MapFrom(db => db.Link.Url));
		}
	}
}

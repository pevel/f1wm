using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DomainModel;

namespace F1WM.Mapping
{
	public class SeasonsMappingProfile : Profile
	{
		public SeasonsMappingProfile()
		{
			CreateMap<Season, SeasonRules>();
			CreateMap<Season, SeasonRaces>();
		}
	}
}

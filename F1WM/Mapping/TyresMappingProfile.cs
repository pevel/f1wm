using System.Linq;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class TyresMappingProfile : Profile
	{
		public TyresMappingProfile()
		{
			CreateMap<Tyres, TyresSummary>();
		}
	}
}

using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace F1WM.Mapping
{
	public class SharedMappingProfile : Profile
	{
		public SharedMappingProfile()
		{
			CreateMap<Constructor, ConstructorSummary>();
			CreateMap<DatabaseModel.Country, ApiModel.Country>()
				.ForMember(api => api.FlagIcon, o => o.MapFrom(db => db.Key.GetFlagIconPath()));
			CreateMap<Car, CarSummary>();
			CreateMap<Season, SeasonSummary>();
			CreateMap(typeof(JsonPatchDocument<>), typeof(JsonPatchDocument<>));
			CreateMap(typeof(Operation<>), typeof(Operation<>));
		}
	}
}

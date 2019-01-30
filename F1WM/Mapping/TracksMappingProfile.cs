using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class TracksMappingProfile : Profile
	{
		public TracksMappingProfile()
		{
			CreateMap<Track, TrackSummary>()
			.ForMember(api => api.Country, o => o.MapFrom(db => db.Country.Name))
			.ForMember(api => api.CountryIcon, o => o.MapFrom(db => db.Country.Key.GetFlagIconPath()))
			.ForMember(api => api.TrackIcon, o => o.MapFrom(db => db.Ascid.GetTrackIconPath()));
		}
	}
}

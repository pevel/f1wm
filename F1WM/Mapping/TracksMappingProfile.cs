using System;
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
			CreateMap<DatabaseModel.Track, ApiModel.Track>()
				.ForMember(api => api.TrackIcon, o => o.MapFrom(db => db.Key.GetTrackIconPath()));
			CreateMap<DatabaseModel.Track, ApiModel.TrackDetails>()
				.ForMember(api => api.Website, o => o.MapFrom(db => db.Website.Url))
				.ForMember(api => api.TrackIcon, o => o.MapFrom(db => db.Key.GetTrackIconPath()));
		}
	}
}

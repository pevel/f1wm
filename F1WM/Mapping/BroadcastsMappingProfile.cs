using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class BroadcastsMappingProfile : Profile
	{
		public BroadcastsMappingProfile()
		{
			CreateMap<DatabaseModel.Broadcast, ApiModel.Broadcast>().ReverseMap();
			CreateMap<DatabaseModel.Broadcast, ApiModel.BroadcastAddRequest>().ReverseMap();
			CreateMap<DatabaseModel.Broadcaster, BroadcasterAddRequest>().ReverseMap();
			CreateMap<DatabaseModel.Broadcaster, ApiModel.Broadcaster>().ReverseMap();
			CreateMap<DatabaseModel.BroadcastedSession, ApiModel.BroadcastedSession>().ReverseMap();
			CreateMap<DatabaseModel.BroadcastedSession, ApiModel.BroadcastedSessionAddRequest>().ReverseMap();
			CreateMap<DatabaseModel.BroadcastedSessionType, ApiModel.BroadcastSessionType>().ReverseMap();
			CreateMap<DatabaseModel.BroadcastedSessionType, ApiModel.BroadcastSessionTypeAddRequest>().ReverseMap();
			CreateMap<Race, ApiModel.BroadcastsInformation>()
				.ForMember(api => api.RaceId, o => o.MapFrom(db => db.Id))
				.ForMember(api => api.Sessions, o => o.MapFrom(db => db.BroadcastedSessions))
				.ForMember(api => api.Broadcasters, o => o.MapFrom(db => db.BroadcastedSessions.GetBroadcasters()));
		}
	}
}

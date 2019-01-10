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
			CreateMap<DatabaseModel.Broadcaster, BroadcasterAddRequest>().ReverseMap();
		}
	}
}
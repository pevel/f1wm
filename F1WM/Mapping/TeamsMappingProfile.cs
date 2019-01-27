using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class TeamsMappingProfile : Profile
	{
		public TeamsMappingProfile()
		{
			CreateMap<Team, TeamDetails>()
				.ForMember(api => api.Management, o => o.MapFrom(db => db.GetManagementInfo()))
				.ForMember(api => api.Website, o => o.MapFrom(db => db.Link.Url));
		}
	}
}

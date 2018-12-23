using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Mapping
{
	public class CommentsMappingProfile : Profile
	{
		public CommentsMappingProfile()
		{
			CreateMap<NewsComment, Comment>()
				.ForMember(api => api.Text, o => o.MapFrom(db => db.Text.CommText));
		}
	}
}
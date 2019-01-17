using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Mapping
{
	public class NewsMappingProfile : Profile
	{
		public NewsMappingProfile()
		{
			CreateMap<News, NewsSummary>();
			CreateMap<News, NewsDetails>();
		}
	}
}

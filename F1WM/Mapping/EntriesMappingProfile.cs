using System;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

namespace F1WM.Mapping
{
	public class EntriesMappingProfile : Profile
	{
		public EntriesMappingProfile()
		{
			CreateMap<Entry, RaceEntry>();
			CreateMap<Driver, EntryDriverSummary>();
		}
	}
}

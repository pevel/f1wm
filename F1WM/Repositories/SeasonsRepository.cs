using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class SeasonsRepository : RepositoryBase, ISeasonsRepository
	{
		private readonly IMapper mapper;

		public async Task<SeasonRules> GetSeasonRules(int year)
		{
			return await mapper.ProjectTo<SeasonRules>(context.Seasons
				.Where(s => s.Year == year))
				.FirstOrDefaultAsync();
		}

		public async Task<SeasonRaces> GetCurrentSeasonRaces(DateTime now)
		{
			return await mapper.ProjectTo<SeasonRaces>(context.Seasons
				.Where(s => s.Year == now.Year))
				.FirstOrDefaultAsync();
		}

		public SeasonsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

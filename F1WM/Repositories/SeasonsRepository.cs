using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.Repositories
{
    public class SeasonsRepository : RepositoryBase, ISeasonsRepository
    {
        private readonly IMapper mapper;

        public async Task<SeasonRules> GetSeasonRules(int year)
        {
            await SetDbEncoding();
            var seasonRules = await context.Seasons
                .SingleOrDefaultAsync(s => s.Year == year);

            var result = mapper.Map<SeasonRules>(seasonRules);

            return result;
        }

        public SeasonsRepository(F1WMContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}

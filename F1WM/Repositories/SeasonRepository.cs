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
    public class SeasonRepository : RepositoryBase, ISeasonRepository
    {
        private readonly IMapper mapper;

        public async Task<SeasonRules> GetSeasonRules(int year)
        {
            await SetDbEncoding();
            var seasonRules = await context.Seasons
                .SingleOrDefaultAsync(s => s.Year == year);

            if (seasonRules == null) return null;

            var result = mapper.Map<SeasonRules>(seasonRules);

            result.QualRules = result.QualRules.Replace("\r\n", "<br>");

            return result;
        }

        public SeasonRepository(F1WMContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}

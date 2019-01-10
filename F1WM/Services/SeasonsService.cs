using F1WM.ApiModel;
using F1WM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.Services
{
    public class SeasonsService : ISeasonsService
    {
        private readonly ISeasonsRepository repository;
        private readonly ITimeService timeService;
        public async Task<SeasonRules> GetSeasonRules(int? year)
        {
            var seasonRules = await repository.GetSeasonRules(year.HasValue ? year.Value : timeService.Now.Year);

            if (seasonRules == null) return null;

            seasonRules.QualRules = seasonRules.QualRules.Replace("\r\n", "<br>");
            seasonRules.QualRules = seasonRules.QualRules.Replace("\r", "<br>");
            return seasonRules;
        }

        public SeasonsService(ISeasonsRepository repository, ITimeService timeService)
        {
            this.repository = repository;
            this.timeService = timeService;
        }
    }
}

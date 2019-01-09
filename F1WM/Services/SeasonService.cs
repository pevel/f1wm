using F1WM.ApiModel;
using F1WM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository repository;
        private readonly ITimeService timeService;
        public async Task<SeasonRules> GetSeasonRules(int? year)
        {
            var seasonRules = await repository.GetSeasonRules(year.HasValue ? year.Value : timeService.Now.Year);
            return seasonRules;
        }

        public SeasonService(ISeasonRepository repository, ITimeService timeService)
        {
            this.repository = repository;
            this.timeService = timeService;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DomainModel;

namespace F1WM.Repositories
{
	public interface ISeasonsRepository
	{
		Task<SeasonRules> GetSeasonRules(int year);
		Task<SeasonRaces> GetCurrentSeasonRaces(DateTime now);
	}
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class ResultsRepository : RepositoryBase, IResultsRepository
	{
		private readonly IMapper mapper;

		public async Task<RaceResult> GetRaceResult(int raceId)
		{
			await SetDbEncoding();
			var model = new RaceResult();
			var dbResults = await context.Results
				.Where(r => r.RaceId == raceId)
				.Include(r => r.Entry).ThenInclude(e => e.Driver)
				.Include(r => r.Entry).ThenInclude(e => e.Car)
				.Include(r => r.Entry).ThenInclude(e => e.Tyres)
				.Include(r => r.Entry).ThenInclude(e => e.Grid)
				.ToListAsync();
			var dbFastestLap = await context.FastestLaps
				.Include(r => r.Entry).ThenInclude(e => e.Driver)
				.Include(r => r.Entry).ThenInclude(e => e.Car)
				.SingleAsync(f => f.RaceId == raceId && f.Frlpos == "1");
			model.RaceId = raceId;
			model.FastestLap = mapper.Map<FastestLapResultSummary>(dbFastestLap);
			model.Results = mapper.Map<IEnumerable<RaceResultPosition>>(dbResults.Select(r =>
			{
				r.FillFinishPositionInfo();
				r.Entry.Grid.FillStartPositionInfo();
				return r;
			}).OrderBy(r => r.FinishPosition == null).ThenBy(r => r.FinishPosition));
			return model;
		}

		public ResultsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}
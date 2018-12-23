using System;
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

		private const int searchInGridBeforeRaceId = 598;

		public async Task<RaceResult> GetRaceResult(int raceId)
		{
			await SetDbEncoding();
			var model = new RaceResult();
			var dbResults = await GetDbRaceResults(raceId);
			var dbFastestLap = await context.FastestLaps
				.Include(r => r.Entry).ThenInclude(e => e.Driver)
				.Include(r => r.Entry).ThenInclude(e => e.Car)
				.SingleAsync(f => f.RaceId == raceId && f.Frlpos == "1");
			model.RaceId = raceId;
			model.FastestLap = mapper.Map<FastestLapResultSummary>(dbFastestLap);
			model.Results = GetRaceResultPositions(dbResults);
			return model;
		}

		public async Task<IEnumerable<RaceResultPosition>> GetShortRaceResult(int raceId)
		{
			await SetDbEncoding();
			var dbResults = await GetDbRaceResults(raceId);
			return GetRaceResultPositions(dbResults).Take(10);
		}

		public async Task<QualifyingResult> GetQualifyingResult(int raceId)
		{
			await SetDbEncoding();
			var model = new QualifyingResult();
			model.RaceId = raceId;
			if (raceId >= searchInGridBeforeRaceId)
			{
				var dbResults = await context.Qualifying
					.Where(q => q.RaceId == raceId)
					.Include(q => q.Entry).ThenInclude(e => e.Driver)
					.Include(q => q.Entry).ThenInclude(e => e.Car)
					.ToListAsync();
				model.Results = mapper.Map<IEnumerable<QualifyingResultPosition>>(dbResults.Select(r => r.FillFinishPositionInfo()))
					.OrderBy(r => r.FinishPosition == null).ThenBy(r => r.FinishPosition);
			}
			else
			{
				var dbResults = await context.Grids
					.Where(g => g.RaceId == raceId)
					.Include(q => q.Entry).ThenInclude(e => e.Driver)
					.Include(q => q.Entry).ThenInclude(e => e.Car)
					.ToListAsync();
				model.Results = mapper.Map<IEnumerable<QualifyingResultPosition>>(dbResults.Select(r => r.FillStartPositionInfo()))
					.OrderBy(r => r.FinishPosition == null).ThenBy(r => r.FinishPosition);
			}
			return model;
		}

		public async Task<PracticeSessionResult> GetPracticeSessionResult(int raceId, string session)
		{
			await SetDbEncoding();
			var model = new PracticeSessionResult();
			model.RaceId = raceId;
			model.Session = session;
			var dbResults = await context.OtherSessions
				.Where(s => s.RaceId == raceId && s.Session == session)
				.Include(s => s.Entry).ThenInclude(e => e.Driver)
				.Include(s => s.Entry).ThenInclude(e => e.Car)
				.ToListAsync();
			model.Results = mapper.Map<IEnumerable<PracticeSessionResultPosition>>(dbResults)
				.OrderBy(r => r.FinishPosition);
			return model;
		}

		public ResultsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		private IEnumerable<RaceResultPosition> GetRaceResultPositions(IEnumerable<Result> dbResults)
		{
			return mapper.Map<IEnumerable<RaceResultPosition>>(dbResults.Select(r =>
			{
				r.FillFinishPositionInfo();
				r.Entry.Grid.FillStartPositionInfo();
				return r;
			}).OrderBy(r => r.FinishPosition == null).ThenBy(r => r.FinishPosition));
		}

		private async Task<IEnumerable<Result>> GetDbRaceResults(int raceId)
		{
			return await context.Results
				.Where(r => r.RaceId == raceId)
				.Include(r => r.Entry).ThenInclude(e => e.Driver)
				.Include(r => r.Entry).ThenInclude(e => e.Car)
				.Include(r => r.Entry).ThenInclude(e => e.Tyres)
				.Include(r => r.Entry).ThenInclude(e => e.Grid)
				.ToListAsync();
		}
	}
}
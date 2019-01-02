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
			var model = new RaceResult() { RaceId = raceId };
			var dbResults = GetDbRaceResults(raceId);
			var dbFastestLap = context.FastestLaps
				.Include(r => r.Entry).ThenInclude(e => e.Driver)
				.Include(r => r.Entry).ThenInclude(e => e.Car)
				.Single(f => f.RaceId == raceId && f.Frlpos == "1");
			model.FastestLap = mapper.Map<FastestLapResultSummary>(dbFastestLap);
			model.Results = GetRaceResultPositions(dbResults);
			return model.Results.Any() ? model : null;
		}

		public async Task<IEnumerable<RaceResultPosition>> GetShortRaceResult(int raceId)
		{
			await SetDbEncoding();
			var dbResults = GetDbRaceResults(raceId);
			return GetRaceResultPositions(dbResults).Take(10);
		}

		public async Task<QualifyingResult> GetQualifyingResult(int raceId)
		{
			await SetDbEncoding();
			var model = new QualifyingResult() { RaceId = raceId };
			if (raceId >= searchInGridBeforeRaceId)
			{
				var dbResults = context.Qualifying
					.Where(q => q.RaceId == raceId)
					.Include(q => q.Entry).ThenInclude(e => e.Driver)
					.Include(q => q.Entry).ThenInclude(e => e.Car);
				model.Results = mapper.Map<IEnumerable<QualifyingResultPosition>>(dbResults.Select(r => r.FillFinishPositionInfo()))
					.OrderBy(r => r.FinishPosition == null).ThenBy(r => r.FinishPosition);
			}
			else
			{
				var dbResults = context.Grids
					.Where(g => g.RaceId == raceId)
					.Include(q => q.Entry).ThenInclude(e => e.Driver)
					.Include(q => q.Entry).ThenInclude(e => e.Car);
				model.Results = mapper.Map<IEnumerable<QualifyingResultPosition>>(dbResults.Select(r => r.FillStartPositionInfo()))
					.OrderBy(r => r.FinishPosition == null).ThenBy(r => r.FinishPosition);
			}
			return model.Results.Any() ? model : null;
		}

		public async Task<PracticeSessionResult> GetPracticeSessionResult(int raceId, string session)
		{
			await SetDbEncoding();
			var model = new PracticeSessionResult() { RaceId = raceId, Session = session };
			var dbResults = context.OtherSessions
				.Where(s => s.RaceId == raceId && s.Session == session)
				.Include(s => s.Entry).ThenInclude(e => e.Driver)
				.Include(s => s.Entry).ThenInclude(e => e.Car);
			model.Results = mapper.Map<IEnumerable<PracticeSessionResultPosition>>(dbResults)
				.OrderBy(r => r.FinishPosition);
			return model.Results.Any() ? model : null;
		}

		public async Task<ApiModel.OtherResult> GetOtherResult(int eventId)
		{
			await SetDbEncoding();
			var model = new ApiModel.OtherResult() { EventId = eventId };
			var dbResults = await context.OtherResults
				.Where(r => r.EventId == eventId)
				.Include(r => r.Entry).ThenInclude(e => e.Series)
				.Include(r => r.Entry).ThenInclude(e => e.Driver).ThenInclude(d => d.Nationality)
				.ToListAsync();
			var resultsOrdered = mapper.Map<IEnumerable<OtherResultPosition>>(dbResults)
				.OrderBy(r => r.FinishPosition).ToList();
			model.Series = mapper.Map<SeriesSummary>(dbResults.FirstOrDefault()?.Entry?.Series);
			model.Results = resultsOrdered.Take(resultsOrdered.Count >= 2 ? resultsOrdered.Count - 2 : 0);
			model.PolePositionLapResult = mapper.Map<OtherLapResultSummary>(resultsOrdered.ElementAtOrDefault(resultsOrdered.Count - 2));
			model.FastestLapResult = mapper.Map<OtherFastestLapResultSummary>(resultsOrdered.LastOrDefault());
			return model.Results.Any() ? model : null;
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

		private IEnumerable<Result> GetDbRaceResults(int raceId)
		{
			return context.Results
				.Where(r => r.RaceId == raceId)
				.Include(r => r.Entry).ThenInclude(e => e.Driver)
				.Include(r => r.Entry).ThenInclude(e => e.Car)
				.Include(r => r.Entry).ThenInclude(e => e.Tyres)
				.Include(r => r.Entry).ThenInclude(e => e.Grid);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DatabaseModel.Constants;
using F1WM.Utilities;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class ResultsRepository : RepositoryBase, IResultsRepository
	{
		private readonly IMapper mapper;

		public async Task<RaceResult> GetRaceResult(int raceId)
		{
			var model = new RaceResult() { RaceId = raceId };
			var dbResults = await GetDbRaceResults(raceId)
				.OrderBy(r => r.Ord).ToListAsync();
			model.Results = GetRaceResultPositions(dbResults);
			if (model.Results.Any())
			{
				model.FastestLap = await mapper.ProjectTo<FastestLapResultSummary>(context.FastestLaps
						.Where(f => f.RaceId == raceId && f.PositionOrStatus == "1")
					).FirstOrDefaultAsync();
				model.Distance = GetDbRaces(raceId)
					.Select(r => r.Distance)
					.FirstOrDefault();
				return model;
			}
			else
			{
				return null;
			}
		}

		public async Task<IEnumerable<RaceResultPosition>> GetShortRaceResult(int raceId)
		{
			var dbResults = await GetDbRaceResults(raceId).ToListAsync();
			return GetRaceResultPositions(dbResults).Take(10);
		}

		public async Task<QualifyingResult> GetQualifyingResult(int raceId)
		{
			var model = new QualifyingResult() { RaceId = raceId };
			if (raceId >= ResultsConstants.SearchInGridBeforeRaceId)
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
			return model.Results.Any() ? model : null;
		}

		public async Task<PracticeSessionResult> GetPracticeSessionResult(int raceId, string session)
		{
			var model = new PracticeSessionResult() { RaceId = raceId, Session = session };
			model.Results = await mapper.ProjectTo<PracticeSessionResultPosition>(context.OtherSessions
					.Where(s => s.RaceId == raceId && s.Session == session))
					.OrderBy(s => s.FinishPosition)
				.ToListAsync();
			return model.Results.Any() ? model : null;
		}

		public async Task<ApiModel.OtherResult> GetOtherResult(int eventId)
		{
			var model = new ApiModel.OtherResult() { EventId = eventId };
			var dbResults = await context.OtherResults
				.Where(r => r.EventId == eventId)
				.Include(r => r.Event)
				.Include(r => r.Entry).ThenInclude(e => e.Series)
				.Include(r => r.Entry).ThenInclude(e => e.Driver).ThenInclude(d => d.Nationality)
				.Include(r => r.AdditionalPointsReason)
				.ToListAsync();
			model.EventName = dbResults.FirstOrDefault()?.Event?.Name;
			model.Series = mapper.Map<SeriesSummary>(dbResults.FirstOrDefault()?.Entry?.Series);
			model.Results = mapper.Map<IEnumerable<OtherResultPosition>>(dbResults)
				.OrderBy(r => r.FinishPosition)
				.Where(r => r.Status != ApiModel.OtherResultStatus.Other);
			if (model.Results.Any())
			{
				model.FastestLapResult = mapper.Map<OtherFastestLapResultSummary>(dbResults.SingleOrDefault(r => r.Status.IsFastestLapStatus()));
				model.PolePositionLapResult = mapper.Map<OtherLapResultSummary>(dbResults.SingleOrDefault(r => r.Status.IsPolePositionStatus()));
				model.AdditionalPoints = mapper.Map<IEnumerable<OtherAdditionalPoints>>(dbResults.Where(r => r.Status.HasAdditionalPoints() && !r.AdditionalPointsReason.IsHidden));
				return model;
			}
			else
			{
				return null;
			}
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
				r.Entry?.Grid?.FillStartPositionInfo();
				return r;
			}).OrderBy(r => r.FinishPosition == null).ThenBy(r => r.FinishPosition));
		}

		private IQueryable<Result> GetDbRaceResults(int raceId)
		{
			return context.Results
				.Where(r => r.RaceId == raceId)
				.Include(r => r.Entry).ThenInclude(e => e.Driver)
				.Include(r => r.Entry).ThenInclude(e => e.Car)
				.Include(r => r.Entry).ThenInclude(e => e.Tyres)
				.Include(r => r.Entry).ThenInclude(e => e.Grid);
		}

		private IQueryable<Race> GetDbRaces(int raceId)
		{
			var dbResult = context.Races
				.Include(r => r.RaceNews)
				.Where(r => r.Id == raceId);
			return dbResult;
		}
	}
}

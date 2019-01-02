using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace F1WM.Repositories
{
    public class CalendarRepository : RepositoryBase, ICalendarRepository
    {
        private readonly IMapper mapper;

        public async Task<Calendar> GetCalendar(int year)
        {
            await SetDbEncoding();
            var dbRace = context.Races
                .OrderBy(r => r.Id)
                .Include(r => r.FastestLap)
                .Where(r => r.Date.Year == year)
                .Join(context.Results, ra => ra.Id, rc => rc.RaceId, (ra, rc) => new {ra, rc});
                //.Where(res=>res.rc.RaceId == res.ra.Id && res.rc.FinishPosition == 1);
            var race = mapper.Map<IQueryable<Race>, List<CalendarRace>>(dbRace);
            var result = new Calendar();
            result.seasonid = (int) dbRace.FirstOrDefault().Seasonid;
            result.Races = race;
            return result;
        }

        
//       seasonId = await context.Seasons
//            .Join(context.ConstructorStandingsPositions, s => s.Id, c => c.SeasonId, (s, c) => new { s, c })
//        .Where(g => g.c != null)
//        .Select(g => g.s)
//            .OrderByDescending(s => s.Year)
//            .Select(s => (int)s.Id)
//            .FirstAsync();
        
        
//        
//        public async Task<NextRaceSummary> GetFirstRaceAfter(DateTime afterDate)
//        {
//            await SetDbEncoding();
//            var dbNextRace = await context.Races
//                .OrderBy(r => r.Date)
//                .Include(r => r.Track)
//                .Include(r => r.Country)
//                .FirstOrDefaultAsync(r => r.Date > afterDate);
//            var apiNextRace = mapper.Map<NextRaceSummary>(dbNextRace);
//            await IncludeLastPolePositionResult(dbNextRace, apiNextRace);
//            await IncludeLastWinnerResult(dbNextRace, apiNextRace);
//            await IncludeFastestResult(dbNextRace, apiNextRace);
//            return apiNextRace;
//        }
//
//        public RacesRepository(F1WMContext context, IMapper mapper)
//		{
//			this.context = context;
//			this.mapper = mapper;
//		}
//
//		private async Task IncludeLastWinnerResult(Race dbNextRace, NextRaceSummary apiNextRace)
//        {
//            var dbLastWinnerResult = await context.Results
//                .Include(r => r.Race)
//                .Where(r => r.Race.TrackId == dbNextRace.TrackId && r.Race.Date < dbNextRace.Date && r.FinishPosition == "1")
//                .Include(r => r.Entry)
//                .ThenInclude(e => e.Driver)
//                .ThenInclude(d => d.Nationality)
//                .OrderByDescending(r => r.Race.Date)
//                .FirstAsync();
//           apiNextRace.LastWinnerRaceResult = mapper.Map<RaceResultSummary>(dbLastWinnerResult.Entry);
//        }
//
//        private async Task IncludeLastPolePositionResult(Race dbNextRace, NextRaceSummary apiNextRace)
//        {
//            var dbLastPolePositionResult = await context.Grids
//                .Include(g => g.Race)
//                .Where(g => g.Race.TrackId == dbNextRace.TrackId && g.Race.Date < dbNextRace.Date && g.StartingPosition == "1")
//                .Include(g => g.Entry)
//                .ThenInclude(e => e.Driver)
//                .ThenInclude(d => d.Nationality)
//                .OrderByDescending(g => g.Race.Date)
//                .FirstAsync();
//            apiNextRace.LastPolePositionLapResult = mapper.Map<LapResultSummary>(dbLastPolePositionResult.Entry);
//        }
//
//		private async Task IncludeFastestResult(Race dbNextRace, NextRaceSummary apiNextRace)
//		{
//			var dbFastestResult = await context.Entries
//				.Include(e => e.Race)
//				.Include(e => e.FastestLap)
//				.Where(e => e.Race.TrackId == dbNextRace.TrackId && e.Race.Date < dbNextRace.Date && e.FastestLap.Frlpos == "1")
//				.Include(e => e.Driver)
//				.ThenInclude(d => d.Nationality)
//				.OrderByDescending(e => e.Race.Date)
//				.FirstAsync();
//			apiNextRace.LastFastestLapResult = mapper.Map<LapResultSummary>(dbFastestResult);
//		}	
        public CalendarRepository(F1WMContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
    public class RacesRepository : RepositoryBase, IRacesRepository
    {
        private readonly IMapper mapper;

        public async Task<NextRaceSummary> GetFirstRaceAfter(DateTime afterDate)
        {
            await SetDbEncoding();
            var dbNextRace = await context.Races
                .OrderBy(r => r.Date)
                .Include(r => r.Track)
                .Include(r => r.Country)
                .FirstOrDefaultAsync(r => r.Date > afterDate);
            var apiNextRace = mapper.Map<NextRaceSummary>(dbNextRace);
            await IncludeLastPolePositionResult(dbNextRace, apiNextRace);
            await IncludeLastWinnerResult(dbNextRace, apiNextRace);
            await IncludeLastFastestResult(dbNextRace, apiNextRace);
            return apiNextRace;
        }

        public async Task<LastRaceSummary> GetMostRecentRaceBefore(DateTime beforeDate)
        {
            await SetDbEncoding();
            var dbLastRace = await context.Races
                .OrderByDescending(r => r.Date)
                .Include(r => r.Track)
                .Include(r => r.FastestLap).ThenInclude(f => f.Entry).ThenInclude(e => e.Driver)
                .Include(r => r.FastestLap).ThenInclude(f => f.Entry).ThenInclude(e => e.Car)
                .Include(r => r.Country)
                .Include(r => r.RaceNews)
                .FirstOrDefaultAsync(r => r.Date < beforeDate);
            var apiLastRace = mapper.Map<LastRaceSummary>(dbLastRace);
            await IncludePolePositionResult(dbLastRace, apiLastRace);
            return apiLastRace;
        }

        public RacesRepository(F1WMContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        private async Task IncludeLastWinnerResult(Race dbNextRace, NextRaceSummary apiNextRace)
        {
            var dbLastWinnerResult = await context.Results
                .Include(r => r.Race)
                .Where(r => r.Race.TrackId == dbNextRace.TrackId && r.Race.Date < dbNextRace.Date && r.PositionOrStatus == "1")
                .Include(r => r.Entry)
                .ThenInclude(e => e.Driver)
                .ThenInclude(d => d.Nationality)
                .OrderByDescending(r => r.Race.Date)
                .FirstAsync();
            apiNextRace.LastWinnerRaceResult = mapper.Map<RaceResultSummary>(dbLastWinnerResult.Entry);
        }

        private async Task IncludeLastPolePositionResult(Race dbNextRace, NextRaceSummary apiNextRace)
        {
            var dbLastPolePositionResult = await context.Grids
                .Include(g => g.Race)
                .Where(g => g.Race.TrackId == dbNextRace.TrackId && g.Race.Date < dbNextRace.Date && g.StartPositionOrStatus == "1")
                .Include(g => g.Entry)
                .ThenInclude(e => e.Driver)
                .ThenInclude(d => d.Nationality)
                .OrderByDescending(g => g.Race.Date)
                .FirstAsync();
            apiNextRace.LastPolePositionLapResult = mapper.Map<LapResultSummary>(dbLastPolePositionResult.Entry);
        }

        private async Task IncludeLastFastestResult(Race dbNextRace, NextRaceSummary apiNextRace)
        {
            var dbFastestResult = await context.Entries
                .Include(e => e.Race)
                .Include(e => e.FastestLap)
                .Where(e => e.Race.TrackId == dbNextRace.TrackId && e.Race.Date < dbNextRace.Date && e.FastestLap.Frlpos == "1")
                .Include(e => e.Driver)
                .ThenInclude(d => d.Nationality)
                .OrderByDescending(e => e.Race.Date)
                .FirstAsync();
            apiNextRace.LastFastestLapResult = mapper.Map<LapResultSummary>(dbFastestResult);
        }

        private async Task IncludePolePositionResult(Race dbLastRace, LastRaceSummary apiLastRace)
        {
            var dbPolePositionResult = await context.Grids
                .Include(g => g.Race)
                .Include(g => g.Entry)
                .ThenInclude(e => e.Driver)
                .SingleAsync(g => g.Race.Id == dbLastRace.Id && g.StartPositionOrStatus == "1");
            apiLastRace.PolePositionLapResult = mapper.Map<LapResultSummary>(dbPolePositionResult.Entry);
        }
    }
}
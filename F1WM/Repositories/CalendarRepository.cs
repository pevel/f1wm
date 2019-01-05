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
            var dbRace = await context.Races
                .Include(r => r.FastestLap)
                    .ThenInclude(r => r.Entry)
                    .ThenInclude(r => r.Driver)
                    .ThenInclude(d => d.Nationality)
                    .Where(r => r.FastestLap.Frlpos == "1")
                .Include(r => r.Track)
                .OrderBy(r => r.Date)
                .Where(r => r.Date.Year == year)
                .ToListAsync();

            var race = mapper.Map<List<Race>, List<CalendarRace>>(dbRace);
            await IncludeLastPolePositionResult(year, race);
            await IncludeLastRaceResult(year, race);
            var result = new Calendar();
            await GetSeasonId(year, result);
            result.Races = race;
            CalculateLap(result);
            return result;
        }

        public CalendarRepository(F1WMContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        private async Task IncludeLastPolePositionResult(int year, List<CalendarRace> calendar)
        {
            var dbPolePositionResults = await context.Grids
                            .Include(g => g.Race)
                            .Where(g => g.Race.Date.Year == year && g.StartPositionOrStatus == "1")
                            .Include(g => g.Entry)
                                .ThenInclude(e => e.Driver)
                                .ThenInclude(d => d.Nationality)
                            .ToListAsync();

            foreach (CalendarRace calendarRace in calendar)
            {
                calendarRace.PolePositionLapResult = mapper.Map<LapResultSummary>(dbPolePositionResults.FirstOrDefault(q => q.RaceId == calendarRace.Id));
            }
        }

        private async Task IncludeLastRaceResult(int year, List<CalendarRace> calendar)
        {
            var dbRaceResults = await context.Results
                .Include(r => r.Entry)
                    .ThenInclude(r => r.Driver)
                    .ThenInclude(r => r.Nationality)
                .Where(r => r.PositionOrStatus == "1" && r.Race.Date.Year == year )
                .ToListAsync();
            
            foreach (CalendarRace calendarRace in calendar)
            {
                calendarRace.WinnerRaceResult = mapper.Map<RaceResultPosition>(dbRaceResults.FirstOrDefault(q => q.RaceId == calendarRace.Id));
            }
            
        }

        private async Task GetSeasonId(int year, Calendar calendar)
        {
            var season = await context.Seasons.SingleAsync(s => s.Year == year);
            calendar.SeasonId = (int)season.Id;
        }

        private void CalculateLap(Calendar calendar)
        {
            foreach (CalendarRace calendarRace in calendar.Races)
            {
                calendarRace.LapLength = calendarRace.Distance / calendarRace.Laps;
            }
        }
    }
}
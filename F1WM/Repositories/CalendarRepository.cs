using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.ApiModel.Results;
using F1WM.DatabaseModel;
using F1WM.Utilities;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class CalendarRepository : RepositoryBase, ICalendarRepository
	{
		private readonly IMapper mapper;

		public async Task<Calendar> GetCalendar(int year)
		{
			var dbRaces = await context.Races
				.Include(r => r.Track)
				.Include(r => r.Country)
				.OrderBy(r => r.Date)
				.Where(r => r.Date.Year == year)
				.ToListAsync();

			if (dbRaces.Count() == 0)return null;

			var races = mapper.Map<List<Race>, List<CalendarRace>>(dbRaces);
			await IncludeLastPolePositionResult(year, races);
			await IncludeLastRaceResult(year, races);
			await IncludeFastestLaps(year, races);
			var apiCalendar = new Calendar();
			await GetSeasonId(year, apiCalendar);
			apiCalendar.Races = races;
			CalculateLap(apiCalendar);
			return apiCalendar;
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
				.Include(g => g.Entry).ThenInclude(e => e.Car)
				.Include(g => g.Entry).ThenInclude(e => e.Driver).ThenInclude(d => d.Nationality)
				.ToListAsync();

			foreach (CalendarRace calendarRace in calendar)
			{
				calendarRace.PolePositionLapResult = mapper.Map<LapResultSummary>(dbPolePositionResults.FirstOrDefault(r => r.RaceId == calendarRace.Id));
			}
		}

		private async Task IncludeLastRaceResult(int year, List<CalendarRace> calendar)
		{
			var dbRaceResults = await context.Results
				.Include(r => r.Entry).ThenInclude(e => e.Grid)
				.Include(r => r.Entry).ThenInclude(e => e.Car)
				.Include(r => r.Entry).ThenInclude(e => e.Driver).ThenInclude(d => d.Nationality)
				.Where(r => r.PositionOrStatus == "1" && r.Race.Date.Year == year)
				.ToListAsync();
			
			foreach (var r in dbRaceResults)
			{
				r.Entry.Grid.FillStartPositionInfo();
			}

			foreach (CalendarRace calendarRace in calendar)
			{
				calendarRace.WinnerRaceResult = mapper.Map<WinnerRaceResultSummary>(dbRaceResults
					.FirstOrDefault(r => r.RaceId == calendarRace.Id));
			}

		}

		private async Task IncludeFastestLaps(int year, List<CalendarRace> calendar)
		{
			var dbFastestLaps = await context.FastestLaps
				.Include(f => f.Entry).ThenInclude(e => e.Race)
				.Include(f => f.Entry).ThenInclude(e => e.Car)
				.Include(f => f.Entry).ThenInclude(e => e.Driver).ThenInclude(d => d.Nationality)
				.Where(f => f.PositionOrStatus == "1" && f.Entry.Race.Date.Year == year)
				.ToListAsync();

			foreach (CalendarRace calendarRace in calendar)
			{
				calendarRace.FastestLapResult = mapper.Map<FastestLapResultSummary>(dbFastestLaps.FirstOrDefault(r => r.RaceId == calendarRace.Id));
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
				calendarRace.LapLength = (calendarRace.Distance + calendarRace.Offset) / calendarRace.Laps;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class CalendarTests : IntegrationTestBase
	{
		[Fact]
		public async Task GetCalendarTest()
		{
			var nowAtRequestTime = DateTime.Now;
			var response = await client.GetAsync($"{baseAddress}/Calendar?year=2016");
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			var calendar = JsonConvert.DeserializeObject<Calendar>(responseContent);
			Assert.Equal(67, calendar.SeasonId);
			Assert.Equal(21, calendar.Races.Count());
			Assert.All(calendar.Races, calendarRace =>
			{
				Assert.True(calendarRace.Date < nowAtRequestTime);
				Assert.NotEqual(0, calendarRace.Distance);
				Assert.NotNull(calendarRace.PolePositionLapResult);
				Assert.NotEqual(0, calendarRace.PolePositionLapResult.Time.TotalMilliseconds);
				Assert.False(string.IsNullOrWhiteSpace(calendarRace.PolePositionLapResult.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(calendarRace.PolePositionLapResult.Driver.Surname));
				Assert.NotNull(calendarRace.WinnerRaceResult);
				Assert.NotEqual(0, calendarRace.WinnerRaceResult.Time.TotalMilliseconds);
				Assert.False(string.IsNullOrWhiteSpace(calendarRace.WinnerRaceResult.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(calendarRace.WinnerRaceResult.Driver.Surname));
				Assert.NotNull(calendarRace.FastestLapResult);
				Assert.NotEqual(0, calendarRace.FastestLapResult.Time.TotalMilliseconds);
				Assert.False(string.IsNullOrWhiteSpace(calendarRace.FastestLapResult.Driver.FirstName));
				Assert.False(string.IsNullOrWhiteSpace(calendarRace.FastestLapResult.Driver.Surname));
				Assert.False(string.IsNullOrWhiteSpace(calendarRace.Name));
				Assert.False(string.IsNullOrWhiteSpace(calendarRace.TranslatedName));
				Assert.NotEqual(0, calendarRace.LapLength);
				Assert.NotEqual(0, calendarRace.Laps);
				Assert.NotNull(calendarRace.Track);
				Assert.NotEqual(0, calendarRace.Id);
				Assert.NotEqual(0, calendarRace.TrackId);
				Assert.NotNull(calendarRace.Country);
			});
		}
	}
}
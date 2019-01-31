using System.Threading.Tasks;
using F1WM.ApiModel;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class CalendarTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("calendar", "calendar.json")]
		public async Task ShouldGetCalendar(CalendarTestData data)
		{
			await TestResponse<Calendar>($"{baseAddress}/Calendar?year={data.Year}", data.Expected);
		}

		public class CalendarTestData
		{
			public int Year { get; set; }
			public Calendar Expected { get; set; }
		}
	}
}

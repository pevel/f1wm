using System.Threading.Tasks;
using F1WM.ApiModel;
using Xunit;

namespace F1WM.IntegrationTests
{
	public class ResultsTests : IntegrationTestBase
	{
		[Theory]
		[JsonData("results", "race-results.json")]
		public async Task ShouldGetRaceResult(RaceResultsTestData data)
		{
			await TestResponse<RaceResult>(
				$"{baseAddress}/results/race/{data.RaceId}",
				data.Expected,
				data.Why);
		}

		[Theory]
		[JsonData("results", "qualifying-results.json")]
		public async Task ShouldGetQualifyingResult(QualifyingResultsTestData data)
		{
			await TestResponse<QualifyingResult>(
				$"{baseAddress}/results/qualifying/{data.RaceId}",
				data.Expected,
				data.Why);
		}

		[Theory]
		[JsonData("results", "practice-session-results.json")]
		public async Task ShouldGetPracticeSessionResult(PracticeSessionResultsTestData data)
		{
			await TestResponse<PracticeSessionResult>(
				$"{baseAddress}/results/practice/{data.RaceId}/sessions/{data.Session}",
				data.Expected);
		}

		[Theory]
		[JsonData("results", "other-results.json")]
		public async Task ShouldGetOtherResult(OtherResultsTestData data)
		{
			await TestResponse<OtherResult>(
				$"{baseAddress}/results/other/{data.EventId}",
				data.Expected,
				data.Why);
		}

		public class RaceResultsTestData
		{
			public int RaceId { get; set; }
			public string Why { get; set; }
			public RaceResult Expected { get; set; }
		}

		public class QualifyingResultsTestData
		{
			public int RaceId { get; set; }
			public string Why { get; set; }
			public QualifyingResult Expected { get; set; }
		}

		public class PracticeSessionResultsTestData
		{
			public int RaceId { get; set; }
			public string Session { get; set; }
			public PracticeSessionResult Expected { get; set; }
		}

		public class OtherResultsTestData
		{
			public int EventId { get; set; }
			public string Why { get; set; }
			public OtherResult Expected { get; set; }
		}
	}
}

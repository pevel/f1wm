using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class DriverSummary
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string Surname { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public Country Nationality { get; set; }
	}
}
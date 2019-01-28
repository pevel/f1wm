using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class Management
	{
		public PersonSummary Founder { get; set; }
		public PersonSummary TeamPrincipal { get; set; }
		public PersonSummary FirstTeamPrincipal { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public PersonSummary TechnicalDirector { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public PersonSummary EngineeringDirector { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public OtherPersonSummary OtherDirector { get; set; }
	}
}

using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class ApiVersion
	{
		public string Version { get; set; }
		public string Branch { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string LastMainDatabaseMigrationId { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string LastIdentityDatabaseMigrationId { get; set; }
	}
}
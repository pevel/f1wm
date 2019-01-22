using System;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class EngineSummary
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? Id { get; set; }
		public string Name { get; set; }
	}
}

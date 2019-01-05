using System;
using Newtonsoft.Json;

namespace F1WM.ApiModel
{
	public class CarSummary
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? Id { get; set; }
		public string Name { get; set; }
	}
}
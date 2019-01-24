using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F1WM.ApiModel
{
	public class GridPosition
	{
		public int? StartPosition { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public StartStatus StartStatus { get; set; }
		public TimeSpan Time { get; set; }
		public GridDriverSummary Driver { get; set; }
		public CarSummary Car { get; set; }
	}
}

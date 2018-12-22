using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F1WM.ApiModel
{
	public class QualifyingResult
	{
		public int RaceId { get; set; }
		public IEnumerable<QualifyingResultPosition> Results { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public QualifyingResultFormat Format { get; set; }
	}
}
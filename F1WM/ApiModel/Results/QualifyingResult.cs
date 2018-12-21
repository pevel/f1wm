using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F1WM.ApiModel
{
	public class QualifyingResult
	{
		public IEnumerable<QualifyingResultPosition> Results { get; set; }
		public LapResultSummary FastestLap { get; set; }
		public QualifyingResultFormat Format { get; set; }
	}
}
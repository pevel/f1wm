using System.Collections.Generic;
using F1WM.DatabaseModel;

namespace F1WM.ApiModel.Engines
{
	public class Engines
	{
		public IEnumerable<EngineSummary> EnginesList { get; set; }
	}
}

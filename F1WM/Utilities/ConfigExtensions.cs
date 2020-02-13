using System.Collections.Generic;
using System.Linq;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class ConfigExtensions
	{
		public static string Get(this IEnumerable<ConfigText> config, string key)
		{
			return config.SingleOrDefault(c => c.Name == key)?.Value;
		}
	}
}

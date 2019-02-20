using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class EngineSpecificationExtensions
	{
		public static Dictionary<string, Dictionary<string, string>> Parse(this EngineSpecification specification)
		{
			if (specification != null && !string.IsNullOrWhiteSpace(specification.Text))
			{
				var sections = new Dictionary<string, Dictionary<string, string>>();
				using(var reader = new StringReader(specification.Text))
				{
					string sectionName = "default";
					while (reader.Peek() != -1)
					{
						var line = reader.ReadLine();
						var tokens = line.Split('|');
						if (tokens.Count() == 2)
						{
							if (sections.TryGetValue(sectionName, out var keyValues))
							{
								keyValues.Add(tokens[0].Trim(), tokens[1].Trim());
							}
							else
							{
								sections.Add(sectionName, new Dictionary<string, string>());
							}
						}
						else if (!string.IsNullOrWhiteSpace(tokens[0]))
						{
							sectionName = tokens[0].Trim();
						}
					}
				}
				return sections;
			}
			else
			{
				return null;
			}
		}
	}
}

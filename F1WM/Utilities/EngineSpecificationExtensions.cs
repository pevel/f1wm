using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class EngineSpecificationExtensions
	{
		public static Dictionary<string, string> Parse(this EngineSpecification specification)
		{
			if (specification != null && !string.IsNullOrWhiteSpace(specification.Text))
			{
				var keyValues = new Dictionary<string, string>();
				using(var reader = new StringReader(specification.Text))
				{
					while (reader.Peek() != -1)
					{
						var line = reader.ReadLine();
						var tokens = line.Split('|');
						if (tokens.Count() == 2)
						{
							keyValues.Add(tokens[0], tokens[1]);
						}
						else
						{
							throw new ArgumentException(
								"Attempted to parse specification text in an unknown format (it's expected to be: key|value",
								nameof(specification)
							);
						}
					}
				}
				return keyValues;
			}
			else
			{
				return null;
			}
		}
	}
}

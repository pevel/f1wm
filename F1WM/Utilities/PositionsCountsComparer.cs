using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using F1WM.DomainModel;

namespace F1WM.Utilities
{
	public class PositionsCountsComparer : IComparer<PositionsCounts>
	{
		private const int positionsLimit = 100;

		public int Compare([AllowNull] PositionsCounts x, [AllowNull] PositionsCounts y)
		{
			if (IsEmpty(x) && IsEmpty(y))
			{
				return 0;
			}
			else if (IsEmpty(x))
			{
				return -1;
			}
			else if (IsEmpty(y))
			{
				return 1;
			}
			int result = 0;
			for (int comparedPosition = 1; comparedPosition <= positionsLimit; comparedPosition++)
			{
				if (!x.Positions.Any(p => p.Key == comparedPosition) && y.Positions.Any(p => p.Key == comparedPosition))
				{
					continue;
				}
				int xPositions = x.Positions.GetValueOrDefault(comparedPosition);
				int yPositions = x.Positions.GetValueOrDefault(comparedPosition);
				result = xPositions.CompareTo(yPositions);
				if (result != 0)
				{
					break;
				}
			}
			return result;
		}

		private bool IsEmpty(PositionsCounts x)
		{
			return x == null || x.Positions == null || !x.Positions.Any();
		}
	}
}

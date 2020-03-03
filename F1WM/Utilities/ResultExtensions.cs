using System;
using System.Globalization;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class ResultExtensions
	{
		public static Result FillFinishPositionInfo(this Result dbResult)
		{
			if (int.TryParse(dbResult.PositionOrStatus, NumberStyles.Integer, CultureInfo.InvariantCulture, out int position))
			{
				dbResult.FinishPosition = position;
				dbResult.Status = null;
			}
			else
			{
				dbResult.FinishPosition = null;
				dbResult.Status = dbResult.PositionOrStatus;
			}
			return dbResult;
		}

		public static double CalculateAverageSpeed(this Result dbResult)
		{
			if (dbResult?.Race?.Distance != null)
			{
				return dbResult.Race.Distance / dbResult.Time.TotalHours;
			}
			else
			{
				throw new ArgumentException("Cannot calculate average speed.", nameof(dbResult));
			}
		}
	}
}

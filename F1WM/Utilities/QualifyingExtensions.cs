using System;
using System.Globalization;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

public static class QualifyingExtensions
{
	public static Qualifying FillFinishPositionInfo(this Qualifying dbResult)
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
}
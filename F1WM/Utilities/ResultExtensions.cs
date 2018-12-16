using System;
using System.Globalization;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

public static class ResultExtensions
{
	public static Result FillPositionInfo(this Result dbResult)
	{
		if (int.TryParse(dbResult.PositionOrStatus, NumberStyles.Integer, CultureInfo.InvariantCulture, out int position))
		{
			dbResult.Position = position;
			dbResult.Status = null;
		}
		else
		{
			dbResult.Position = null;
			dbResult.Status = dbResult.PositionOrStatus;
		}
		return dbResult;
	}
}
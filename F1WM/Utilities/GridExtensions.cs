using System;
using System.Globalization;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;

public static class GridExtensions
{
	public static Grid FillStartPositionInfo(this Grid dbGrid)
	{
		if (int.TryParse(dbGrid.StartPositionOrStatus, NumberStyles.Integer, CultureInfo.InvariantCulture, out int position))
		{
			dbGrid.StartPosition = position;
			dbGrid.StartStatus = null;
		}
		else
		{
			dbGrid.StartPosition = null;
			dbGrid.StartStatus = dbGrid.StartPositionOrStatus;
		}
		return dbGrid;
	}

	public static void FillSessionsInfo(this Grid dbResult, QualifyingResultPosition apiResult)
	{
		apiResult.Session1 = dbResult.Time == TimeSpan.Zero ? null : new QualifyingSessionResultPosition()
		{
			FinishPosition = dbResult.StartPosition,
			FinishedLaps = null,
			Time = dbResult.Time
		};
	}
}
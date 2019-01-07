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

	public static void FillSessionsInfo(this Qualifying dbResult, QualifyingResultPosition apiResult)
	{
		apiResult.Session1 = dbResult.Session1Time == TimeSpan.Zero && dbResult.Session1Laps == 0 ? null : new QualifyingSessionResultPosition()
		{
			FinishPosition = dbResult.Session1Position,
				FinishedLaps = dbResult.Session1Laps,
				Time = dbResult.Session1Time
		};
		apiResult.Session2 = dbResult.Session2Time == TimeSpan.Zero && dbResult.Session2Laps == 0 ? null : new QualifyingSessionResultPosition()
		{
			FinishPosition = dbResult.Session2Position,
				FinishedLaps = dbResult.Session2Laps,
				Time = dbResult.Session2Time
		};
		apiResult.Session3 = dbResult.Session3Time == TimeSpan.Zero && dbResult.Session3Laps == 0 ? null : new QualifyingSessionResultPosition()
		{
			FinishPosition = dbResult.Session3Position,
				FinishedLaps = dbResult.Session3Laps,
				Time = dbResult.Session3Time
		};
	}
}
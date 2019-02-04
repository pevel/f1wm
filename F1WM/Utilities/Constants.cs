using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.Utilities;
using Microsoft.EntityFrameworkCore;
using Database = F1WM.DatabaseModel.Constants;

public static class Constants
{
	public readonly static Dictionary<string, ResultStatus> TextToResultStatus =
		new Dictionary<string, ResultStatus>()
	{
		{ String.Empty, ResultStatus.Classified },
		{ Database.ResultStatus.DidNotStart, ResultStatus.DidNotStart },
		{ Database.ResultStatus.DidNotStartAgain, ResultStatus.DidNotStartAgain },
		{ Database.ResultStatus.Disqualified, ResultStatus.Disqualified },
		{ Database.ResultStatus.Excluded, ResultStatus.Excluded },
		{ Database.ResultStatus.NotClassified, ResultStatus.NotClassified }
	};

	public readonly static Dictionary<string, StartStatus> TextToStartStatus =
		new Dictionary<string, StartStatus>()
	{
		{ String.Empty, StartStatus.FromGrid },
		{ Database.StartStatus.NotClassified, StartStatus.NotClassified },
		{ Database.StartStatus.Excluded, StartStatus.Excluded },
		{ Database.StartStatus.FromPitLane, StartStatus.FromPitLane },
		{ Database.StartStatus.NotPreQualified, StartStatus.NotPreQualified },
		{ Database.StartStatus.NotQualified, StartStatus.NotQualified }
	};

	public readonly static Dictionary<string, QualifyStatus> TextToQualifyStatus =
		new Dictionary<string, QualifyStatus>()
	{
		{ String.Empty, QualifyStatus.Qualified },
		{ Database.QualifyStatus.DidNotStart, QualifyStatus.DidNotStart },
		{ Database.QualifyStatus.Excluded, QualifyStatus.Excluded },
		{ Database.QualifyStatus.NotQualified, QualifyStatus.NotQualified },
		{ Database.QualifyStatus.NotPreQualified, QualifyStatus.NotPreQualified }
	};

	public readonly static Dictionary<string, OtherResultStatus> TextToOtherResultStatus =
		new Dictionary<string, OtherResultStatus>()
	{
		{ String.Empty, OtherResultStatus.Classified },
		{ Database.OtherResultStatus.DidNotStart, OtherResultStatus.DidNotStart },
		{ Database.OtherResultStatus.Disqualified, OtherResultStatus.Disqualified },
		{ Database.OtherResultStatus.NotClassified, OtherResultStatus.NotClassified },
		{ Database.OtherResultStatus.NotQualified, OtherResultStatus.NotQualified }
	};

	public readonly static Dictionary<string, Func<string, string>> TokenToParser =
		new Dictionary<string, Func<string, string>>()
	{
		{ "#", line => $"<span class=\"news-text-center\">{line.Substring(1)}</span>" },
		{ "*", line => $"<h2 class=\"news-text-center\">{line.Substring(1)}</h2>" },
		{ ">", line => $"<h3>{line.Substring(1)}</h3>" },
		{ "=", line => $"<span class=\"news-text-title\">{line.Substring(1)}</span>" },
		{ "@", line => line.ParseImageInformation() }
	};

	public readonly static Dictionary<Database.ResultType, ResultLinkType> ResultTypeToLinkType =
		new Dictionary<Database.ResultType, ResultLinkType>()
	{
		{ Database.ResultType.QualifyingComments, ResultLinkType.Qualifying },
		{ Database.ResultType.QualifyingSummary, ResultLinkType.Qualifying },
		{ Database.ResultType.Race, ResultLinkType.Race },
		{ Database.ResultType.FastestLaps, ResultLinkType.FastestLaps },
		{ Database.ResultType.PitStops, ResultLinkType.Unknown },
		{ Database.ResultType.Tyres, ResultLinkType.Unknown },
		{ Database.ResultType.RaceCharts, ResultLinkType.Unknown }
	};

	public readonly static Dictionary<ResultLinkType, Func<F1WMContext, ResultRedirectLink, Task<ResultLink>>> LinkTypeToAction =
		new Dictionary<ResultLinkType, Func<F1WMContext, ResultRedirectLink, Task<ResultLink>>>()
	{
		{ ResultLinkType.Race, (c, l) => getRaceIdResultLinkByYearAndNumber(c, l) },
		{ ResultLinkType.Qualifying, (c, l) => getRaceIdResultLinkByYearAndNumber(c, l) },
		{ ResultLinkType.FastestLaps, (c, l) => getRaceIdResultLinkByYearAndNumber(c, l) }
	};

	private readonly static Func<F1WMContext, ResultRedirectLink, Task<ResultLink>> getRaceIdResultLinkByYearAndNumber =
		async (context, link) => 
		{
			var resultLink = new ResultLink() { Type = ResultTypeToLinkType[link.ResultType] };
			resultLink.RaceId = (int?)(await context.Races
					.Where(r => r.Date.Year == link.Year && r.Numinseason == link.Number)
					.Select(r => r.Id)
					.FirstOrDefaultAsync());
			return resultLink;
		};
}

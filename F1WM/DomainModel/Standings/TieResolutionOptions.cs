using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using F1WM.DatabaseModel;

namespace F1WM.DomainModel
{
	public class TieResolutionOptions
	{
		public uint SeasonId { get; set; }
		public DateTime BeforeDate { get; set; }
		public Func<IEnumerable<uint>, Expression<Func<Result, bool>>> IdPredicateFactory { get; set; }
		public Expression<Func<Result, RacePosition>> PositionSelector { get; set; }
	}
}

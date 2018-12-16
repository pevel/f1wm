using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class ResultsRepository : RepositoryBase, IResultsRepository
	{
		private readonly IMapper mapper;
		
		public async Task<RaceResult> GetRaceResult(int id)
		{
			await SetDbEncoding();
			var model = new RaceResult();
			var dbResults = await context.Results
				.Where(r => r.RaceId == id)
				.Include(r => r.Entry).ThenInclude(e => e.Driver)
				.Include(r => r.Entry).ThenInclude(e => e.Car)
				.Include(r => r.Entry).ThenInclude(e => e.Grid)
				.ToListAsync();
			model.RaceId = id;
			model.Results = mapper.Map<IEnumerable<RaceResultPosition>>(dbResults.Select(r => r.FillPositionInfo()));
			return model;
		}

		public ResultsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}
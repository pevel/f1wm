using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class GridsRepository : RepositoryBase, IGridsRepository
	{
		private readonly IMapper mapper;

		public async Task<GridInformation> GetGrid(int raceId)
		{
			var apiGrid = new GridInformation() { RaceId = raceId };
			var dbGrid = await context.Grids
				.Where(g => g.RaceId == raceId)
				.Include(g => g.Entry).ThenInclude(e => e.Driver)
				.Include(g => g.Entry).ThenInclude(e => e.Car)
				.ToListAsync();
			if (dbGrid.Any())
			{
				apiGrid.GridPositions = mapper.Map<IEnumerable<GridPosition>>(dbGrid
					.Select(g => g.FillStartPositionInfo())
					.Where(g => g.StartPosition != null)
					.OrderBy(g => g.StartPosition)
				);
				return apiGrid;
			}
			else
			{
				return null;
			}
		}

		public GridsRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

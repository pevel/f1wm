using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Api = F1WM.ApiModel;
using Database = F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public class BroadcastRepository : RepositoryBase, IBroadcastsRepository
	{
		private readonly IMapper mapper;

		public async Task<Api.BroadcastsInformation> AddBroadcasts(Api.BroadcastsAddRequest request)
		{
			var dbSessions = mapper.Map<IEnumerable<Database.BroadcastedSession>>(request.Sessions);
			context.BroadcastedSessions.AddRange(dbSessions);
			context.Races.Single(r => r.Id == request.RaceId).BroadcastedSessions = dbSessions;
			await context.SaveChangesAsync();
			var dbRace = await context.Races
				.Include(r => r.BroadcastedSessions).ThenInclude(s => s.Broadcasts).ThenInclude(b => b.Broadcaster)
				.Include(r => r.BroadcastedSessions).ThenInclude(s => s.Type)
				.SingleOrDefaultAsync(r => r.Id == request.RaceId);
			return mapper.Map<Api.BroadcastsInformation>(dbRace);
		}

		public async Task<Api.Broadcaster> AddBroadcaster(Api.BroadcasterAddRequest request)
		{
			var dbBroadcaster = mapper.Map<Database.Broadcaster>(request);
			context.Broadcasters.Add(dbBroadcaster);
			await context.SaveChangesAsync();
			return mapper.Map<Api.Broadcaster>(dbBroadcaster);
		}

		public async Task<IEnumerable<Api.Broadcaster>> GetBroadcasters()
		{
			var dbBroadcasters = await context.Broadcasters.ToListAsync();
			return mapper.Map<IEnumerable<Api.Broadcaster>>(dbBroadcasters);
		}

		public async Task<Api.BroadcastsInformation> GetBroadcastsAfter(DateTime now)
		{
			var dbRace = await context.Races
				.Include(r => r.BroadcastedSessions).ThenInclude(s => s.Broadcasts).ThenInclude(b => b.Broadcaster)
				.Include(r => r.BroadcastedSessions).ThenInclude(s => s.Type)
				.OrderBy(r => r.Date)
				.FirstOrDefaultAsync(r => r.Date > now);
			return mapper.Map<Api.BroadcastsInformation>(dbRace);
		}

		public async Task<IEnumerable<Api.BroadcastSessionType>> GetSessionTypes()
		{
			var dbTypes = await context.BroadcastedSessionTypes.ToListAsync();
			return mapper.Map<IEnumerable<Api.BroadcastSessionType>>(dbTypes);
		}

		public async Task<Api.BroadcastSessionType> AddSessionType(Api.BroadcastSessionTypeAddRequest request)
		{
			var dbType = mapper.Map<Database.BroadcastedSessionType>(request);
			context.BroadcastedSessionTypes.Add(dbType);
			await context.SaveChangesAsync();
			return mapper.Map<Api.BroadcastSessionType>(dbType);
		}

		public BroadcastRepository(Database.F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

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

		public async Task<Api.BroadcastsInformation> AddBroadcast(Api.BroadcastsAddRequest request)
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

		public Task<Api.BroadcastsInformation> GetBroadcastsAfter(DateTime now)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Api.BroadcastSessionType>> GetSessionNames()
		{
			var dbNames = await context.BroadcastedSessionTypes.ToListAsync();
			return mapper.Map<IEnumerable<Api.BroadcastSessionType>>(dbNames);
		}

		public async Task<Api.BroadcastSessionType> AddSessionName(Api.BroadcastSessionTypeAddRequest request)
		{
			var dbName = mapper.Map<Database.BroadcastedSessionType>(request);
			context.BroadcastedSessionTypes.Add(dbName);
			await context.SaveChangesAsync();
			return mapper.Map<Api.BroadcastSessionType>(dbName);
		}

		public BroadcastRepository(Database.F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

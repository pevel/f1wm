using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using F1WM.DomainModel;
using F1WM.Utilities;
using Microsoft.AspNetCore.JsonPatch;
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
			context.Races.Single(r => r.Id == request.RaceId).BroadcastedSessions = dbSessions.ToList();
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

		public async Task<Api.BroadcastsInformation> GetNextBroadcasts(SeasonRaces currentSeason)
		{
			if (currentSeason != null)
			{
				Expression<Func<Race, bool>> filter = currentSeason.GetNextRaceFilter();
				var dbRace = await context.Races
					.Include(r => r.BroadcastedSessions).ThenInclude(s => s.Broadcasts).ThenInclude(b => b.Broadcaster)
					.Include(r => r.BroadcastedSessions).ThenInclude(s => s.Type)
					.OrderBy(r => r.Date)
					.FirstOrDefaultAsync(filter);
				return mapper.Map<Api.BroadcastsInformation>(dbRace);
			}
			return null;
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

		public async Task<Api.BroadcastedRace> UpdateBroadcasts(Api.BroadcastsUpdateRequest request)
		{
			var race = await context.Races
				.Include(r => r.BroadcastedSessions).ThenInclude(s => s.Broadcasts)
				.Include(r => r.BroadcastedSessions).ThenInclude(s => s.Type)
				.SingleOrDefaultAsync(r => r.Id == request.RaceId);
			if (race != null)
			{
				mapper.Map<JsonPatchDocument<Race>>(request.PatchDocument).ApplyTo(race);
				context.Races.Update(race);
				await context.SaveChangesAsync();
				return mapper.Map<Api.BroadcastedRace>(race);
			}
			return null;
		}

		public async Task<IEnumerable<BroadcastsInformation>> GetBroadcasts(int? raceId = null)
		{
			var raceIdFilter = raceId.HasValue ? (Expression<Func<Database.BroadcastedSession, bool>>)(b => b.RaceId == raceId.Value) : r => true;
			var dbBroadcastedSessions = await context.BroadcastedSessions
				.Where(raceIdFilter)
				.Include(s => s.Type)
				.Include(s => s.Broadcasts).ThenInclude(b => b.Broadcaster)
				.OrderBy(s => s.RaceId)
				.GroupBy(s => s.RaceId)
				.ToListAsync();
			return mapper.Map<IEnumerable<Api.BroadcastsInformation>>(dbBroadcastedSessions);
		}

		public async Task<Api.Broadcaster> UpdateBroadcaster(BroadcasterUpdateRequest request)
		{
			var dbBroadcaster = await context.Broadcasters.SingleOrDefaultAsync(b => b.Id == request.Id);
			if (dbBroadcaster != null)
			{
				mapper.Map<JsonPatchDocument<Database.Broadcaster>>(request.PatchDocument).ApplyTo(dbBroadcaster);
				context.Broadcasters.Update(dbBroadcaster);
				await context.SaveChangesAsync();
				return mapper.Map<Api.Broadcaster>(dbBroadcaster);
			}
			else
			{
				return null;
			}
		}

		public async Task<BroadcastSessionType> UpdateSessionType(BroadcastSessionTypeUpdateRequest request)
		{
			var dbType = await context.BroadcastedSessionTypes.SingleOrDefaultAsync(b => b.Id == request.Id);
			if (dbType != null)
			{
				mapper.Map<JsonPatchDocument<BroadcastedSessionType>>(request.PatchDocument).ApplyTo(dbType);
				context.BroadcastedSessionTypes.Update(dbType);
				await context.SaveChangesAsync();
				return mapper.Map<BroadcastSessionType>(dbType);
			}
			else
			{
				return null;
			}
		}

		public Task DeleteBroadcasts(int raceId)
		{
			var dbRace = context.Races.Include(r => r.BroadcastedSessions).SingleOrDefault(r => r.Id == raceId);
			dbRace.BroadcastedSessions.Clear();
			return context.SaveChangesAsync();
		}

		public Task DeleteBroadcaster(int id)
		{
			var dbBroadcaster = context.Broadcasters.SingleOrDefault(b => b.Id == id);
			context.Broadcasters.Remove(dbBroadcaster);
			return context.SaveChangesAsync();
		}

		public Task DeleteSessionType(int id)
		{
			var dbSessionType = context.BroadcastedSessionTypes.SingleOrDefault(t => t.Id == id);
			context.BroadcastedSessionTypes.Remove(dbSessionType);
			return context.SaveChangesAsync();
		}

		public Task<BroadcastedRace> GetBroadcastedRace(int raceId)
		{
			return mapper.ProjectTo<BroadcastedRace>(context.Races.Where(r => r.Id == raceId)).SingleOrDefaultAsync();
		}

		public BroadcastRepository(Database.F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

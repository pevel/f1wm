using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Api = F1WM.ApiModel;
using Database = F1WM.DatabaseModel;

namespace F1WM.Repositories
{
	public class BroadcastRepository : RepositoryBase, IBroadcastsRepository
	{
		private readonly IMapper mapper;

		public Task<Api.BroadcastsInformation> AddBroadcast(Api.BroadcastsAddRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task<Api.Broadcaster> AddBroadcaster(Api.BroadcasterAddRequest request)
		{
			var dbBroadcaster = mapper.Map<Database.Broadcaster>(request);
			await context.Broadcasters.AddAsync(dbBroadcaster);
			context.SaveChanges();
			return mapper.Map<Api.Broadcaster>(dbBroadcaster);
		}

		public Task<IEnumerable<Api.Broadcaster>> GetBroadcasters()
		{
			throw new NotImplementedException();
		}

		public Task<Api.BroadcastsInformation> GetBroadcastsAfter(DateTime now)
		{
			throw new NotImplementedException();
		}

		public BroadcastRepository(Database.F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}
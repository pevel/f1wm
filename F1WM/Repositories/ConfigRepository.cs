using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class ConfigRepository : RepositoryBase, IConfigRepository
	{
		private readonly IMapper mapper;

		public async Task<ConfigText> GetConfigText(string name)
		{
			var dbConfigText = await context.ConfigTexts.FirstOrDefaultAsync(c => c.Name == name);
			return dbConfigText;
		}

		public async Task<IEnumerable<ConfigText>> GetConfigTexts(ICollection<string> names)
		{
			var dbConfigTexts = await context.ConfigTexts
				.Where(c => names.Contains(c.Name))
				.ToListAsync();
			return dbConfigTexts;
		}

		public async Task<IEnumerable<ConfigText>> AddConfigTexts(IEnumerable<ConfigText> configs)
		{
			context.ConfigTexts.AddRange(configs);
			await context.SaveChangesAsync();
			return configs;
		}

		public ConfigRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}

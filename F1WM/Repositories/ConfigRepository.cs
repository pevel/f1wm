using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using F1WM.DatabaseModel;
using F1WM.Utilities;
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

		public async Task<IEnumerable<ConfigText>> UpdateOrAddConfigTexts(string sectionName, IEnumerable<ConfigText> configs)
		{
			await AddSection(sectionName, configs);
			foreach (var config in configs)
			{
				var existing = context.ConfigTexts.SingleOrDefault(c => c.Name == config.Name && c.SectionId == config.SectionId);
				if (existing != null)
				{
					config.Id = existing.Id;
					context.Entry(existing).CurrentValues.SetValues(config);
				}
				else
				{
					context.ConfigTexts.Add(config);
				}
			}
			await context.SaveChangesAsync();
			return configs;
		}

		public ConfigRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		private async Task AddSection(string sectionName, IEnumerable<ConfigText> configs)
		{
			var section = await context.ConfigSections.SingleOrDefaultAsync(c => c.Name == sectionName);
			foreach (var c in configs)
			{
				c.SectionId = section.Id;
			}
		}
	}
}

using System.Threading.Tasks;
using AutoMapper;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace F1WM.Repositories
{
	public class ConfigTextRepository : RepositoryBase, IConfigTextRepository
	{
		private readonly IMapper mapper;

		public async Task<ConfigText> GetConfigText(string name)
		{
			await SetDbEncoding();
			var dbConfigText = await context.ConfigTexts.FirstOrDefaultAsync(c => c.Name == name);
			return mapper.Map<ConfigText>(dbConfigText);
		}

		public ConfigTextRepository(F1WMContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
	}
}
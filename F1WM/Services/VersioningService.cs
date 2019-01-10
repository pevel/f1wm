using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using F1WM.ApiModel;
using F1WM.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace F1WM.Services
{
	public class VersioningService : IVersioningService
	{
		private readonly F1WMContext f1wmContext;
		private readonly F1WMIdentityContext identityContext;

		public ApiVersion GetApiVersion()
		{
			var version = new ApiVersion();
			var assembly = Assembly.GetEntryAssembly();
			var resourceStream = assembly.GetManifestResourceStream("F1WM.version.json");
			using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
			{
				version = JsonConvert.DeserializeObject<ApiVersion>(reader.ReadToEnd());
			}
			version.LastMainDatabaseMigrationId = f1wmContext.Database.GetAppliedMigrations().LastOrDefault();
			version.LastIdentityDatabaseMigrationId = identityContext.Database.GetAppliedMigrations().LastOrDefault();
			return version;
		}

		public VersioningService(F1WMContext f1wmContext, F1WMIdentityContext identityContext)
		{
			this.f1wmContext = f1wmContext;
			this.identityContext = identityContext;
		}
	}
}
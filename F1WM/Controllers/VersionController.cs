using System;
using System.IO;
using System.Reflection;
using System.Text;
using F1WM.Model;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class VersionController : ControllerBase
	{
		private ILoggingService logger;

		[HttpGet]
		public ApiVersion GetVersion()
		{
			try
			{
				var assembly = Assembly.GetEntryAssembly();
				var resourceStream = assembly.GetManifestResourceStream("F1WM.version.json");
				using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
				{
					return JsonConvert.DeserializeObject<ApiVersion>(reader.ReadToEnd());
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		public VersionController(ILoggingService logger)
		{
			this.logger = logger;
		}
	}
}
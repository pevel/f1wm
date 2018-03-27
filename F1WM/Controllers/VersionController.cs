using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using F1WM.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace F1WM.Controllers
{
	[Route("api/[controller]")]
	public class VersionController : Controller
	{
		[HttpGet]
		public ApiVersion GetVersion()
		{
			var assembly = Assembly.GetEntryAssembly();
			var resourceStream = assembly.GetManifestResourceStream("F1WM.version.json");
			using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
			{
				return JsonConvert.DeserializeObject<ApiVersion>(reader.ReadToEnd());
			}
		}
	}
}
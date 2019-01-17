using F1WM.ApiModel;

namespace F1WM.Services
{
	public interface IVersioningService
	{
		ApiVersion GetApiVersion();
	}
}
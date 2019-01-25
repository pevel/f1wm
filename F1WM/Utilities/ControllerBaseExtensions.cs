using Microsoft.AspNetCore.Mvc;

namespace F1WM.Utilities
{
	public static class ControllerBaseExtensions
	{
		public static IActionResult NotFoundResultIfNull<T>(this ControllerBase controller, T serviceResult)
		{
			return serviceResult != null ? (IActionResult)controller.Ok(serviceResult) : (IActionResult)controller.NotFound();
		}
	}
}

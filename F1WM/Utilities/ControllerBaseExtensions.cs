using Microsoft.AspNetCore.Mvc;

namespace F1WM.Utilities
{
	public static class ControllerBaseExtensions
	{
		public static ActionResult<T> NotFoundResultIfNull<T>(this ControllerBase controller, T serviceResult)
		{
			return serviceResult != null ? (ActionResult)controller.Ok(serviceResult) : (ActionResult)controller.NotFound();
		}
	}
}

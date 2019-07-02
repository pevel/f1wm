using System;
using System.Threading.Tasks;
using F1WM.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace F1WM.Middlewares
{
	public class CacheResponseMiddleware
	{
		private readonly RequestDelegate next;

		public CacheResponseMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			httpContext.Request.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
			{
				Public = true,
				MaxAge = TimeSpan.FromSeconds(Constants.DefaultCacheDurationInSeconds)
			};
			await next(httpContext);
		}
	}
}

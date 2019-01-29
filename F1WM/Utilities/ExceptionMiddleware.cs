using System;
using System.Net;
using System.Threading.Tasks;
using F1WM.Services;
using Microsoft.AspNetCore.Http;

namespace F1WM.Utilities
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate next;
		private readonly ILoggingService logger;

		public ExceptionMiddleware(RequestDelegate next, ILoggingService logger)
		{
			this.logger = logger;
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

			return context.Response.WriteAsync(new
			{
				StatusCode = context.Response.StatusCode,
				Message = "Internal Server Error from the custom middleware."
			}.ToString());
		}
	}
}

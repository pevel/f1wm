using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using F1WM.Services;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace F1WM.Middlewares
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

			var message = ExceptionTypeToMessage().GetValueOrDefault(exception.GetType());
			return context.Response.WriteAsync(JsonConvert.SerializeObject(new
			{
				Message = message ?? "Unknown error"
			}));
		}

		private static Dictionary<Type, string> ExceptionTypeToMessage()
		{
			return new Dictionary<Type, string>()
			{
				{ typeof(Exception), "Internal server error" },
				{ typeof(NotImplementedException), "Not implemented" },
				{ typeof(MySqlException), "Database error" }
			};
		}
	}
}

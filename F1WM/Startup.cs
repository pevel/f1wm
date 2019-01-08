using System;
using System.Collections.Generic;
using System.Linq;
using F1WM.Services;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.AspNetCore;

namespace F1WM
{
	public class Startup
	{
		private readonly IConfiguration configuration;

		private readonly IHostingEnvironment environment;

		private const string corsPolicy = "DefaultPolicy";
		private LoggingService logger;

		public Startup(IConfiguration configuration, IHostingEnvironment environment)
		{
			this.configuration = configuration;
			this.environment = environment;
			logger = new LoggingService(configuration);
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			try
			{
				services
					.AddMvcCore()
					.AddApiExplorer()
					.AddAuthorization()
					.AddDataAnnotations()
					.AddFormatterMappings()
					.AddCors(o => o.AddPolicy(corsPolicy, GetCorsPolicyBuilder()))
					.AddJsonFormatters()
					.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

				services
					.AddLogging()
					.AddSwagger()
					.AddTransient<ILoggingService, LoggingService>(provider => this.logger)
					.AddMemoryCache()
					.ConfigureRepositories(configuration)
					.ConfigureLogicServices()
					.AddAuthentication("Bearer").AddIdentityServerAuthentication(GetIdentityServerOptions());

				services
					.AddIdentityServer()
					.AddDeveloperSigningCredential()
					.AddInMemoryClients(GetTestClients())
					.AddInMemoryApiResources(GetApiResources())
					.AddTestUsers(GetTestUsers().ToList());
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder application,
			IHostingEnvironment environment,
			IServiceProvider serviceProvider,
			IConfigurationBuilder configurationBuilder)
		{
			try
			{
				if (environment.IsDevelopment())
				{
					application.UseDeveloperExceptionPage();
					configurationBuilder.AddUserSecrets<Startup>();
				}
				configurationBuilder.AddEnvironmentVariables();

				application
					.UseForwardedHeaders(GetForwardedHeadersOptions())
					.UseCors(corsPolicy)
					.UseSwaggerUi3WithApiExplorer(GetSwaggerUiSettings(!environment.IsDevelopment()))
					.UseMvc()
					.UseIdentityServer();
			}
			catch (Exception ex)
			{
				logger.LogError(ex);
				throw ex;
			}
		}

		private Action<CorsPolicyBuilder> GetCorsPolicyBuilder()
		{
			return builder =>
			{
				builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials();
			};
		}

		private ForwardedHeadersOptions GetForwardedHeadersOptions()
		{
			return new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			};
		}

		private Action<SwaggerUi3Settings<AspNetCoreToSwaggerGeneratorSettings>> GetSwaggerUiSettings(bool httpsEnabled)
		{
			return settings =>
			{
				if (httpsEnabled)
				{
					settings.PostProcess = (document) => document.Schemes = new [] { SwaggerSchema.Https };
				}
				settings.GeneratorSettings.Title = "F1WM web API";
				settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
			};
		}

		private Action<IdentityServerAuthenticationOptions> GetIdentityServerOptions()
		{
			return options => 
			{
				options.Authority = "http://localhost:5000";
				options.RequireHttpsMetadata = false;
				options.ApiName = "f1wm-api";
			};
		}

		private IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>()
			{
				new ApiResource("f1wm-api", "F1WM web API")
			};
		}

		private IEnumerable<TestUser> GetTestUsers()
		{
			return new List<TestUser>()
			{
				new TestUser() { Username = "test", Password = "test" }
			};
		}

		private IEnumerable<Client> GetTestClients()
		{
			return new List<Client>()
			{
				new Client()
				{
					ClientId = "test-client",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets = { new Secret("test-secret".Sha256()) },
					AllowedScopes = { "f1wm-api" }
				}
			};
		}
	}
}
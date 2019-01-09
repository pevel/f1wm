using System;
using System.IdentityModel.Tokens.Jwt;
using F1WM.DatabaseModel;
using F1WM.Services;
using F1WM.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.AspNetCore;
using NSwag.SwaggerGeneration.Processors.Security;

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
				JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
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
					.AddIdentity<F1WMUser, IdentityRole>()
					.AddEntityFrameworkStores<F1WMIdentityContext>()
					.AddDefaultTokenProviders();
				services
					.AddAuthentication(GetAuthenticationOptions())
					.AddJwtBearer(GetJwtBearerOptions());
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
					.UseAuthentication();
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
				settings.GeneratorSettings.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
				settings.GeneratorSettings.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token",
					new SwaggerSecurityScheme
					{
						Type = SwaggerSecuritySchemeType.ApiKey,
						Name = "Authorization",
						Description = "Copy 'Bearer ' + valid JWT token into field",
						In = SwaggerSecurityApiKeyLocation.Header
					}));
			};
		}

		private Action<AuthenticationOptions> GetAuthenticationOptions()
		{
			return options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			};
		}

		private Action<JwtBearerOptions> GetJwtBearerOptions()
		{
			return options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidIssuer = configuration[Configuration.JwtIssuerKey],
					IssuerSigningKey = Auth.GetJwtKey(configuration),
					ClockSkew = TimeSpan.Zero
				};
			};
		}
	}
}
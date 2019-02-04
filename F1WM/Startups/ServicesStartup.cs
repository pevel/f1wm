using System;
using F1WM.Services;
using Microsoft.Extensions.DependencyInjection;
using Narochno.BBCode;

namespace F1WM.Startups
{
	public static class ServicesStartup
	{
		public static IServiceCollection ConfigureLogicServices(this IServiceCollection services)
		{
			return services
				.AddSingleton<IBBCodeParser, BBCodeParser>(BuildBBCodeParser)
				.AddSingleton<ICachingService, CachingService>()
				.AddTransient<INewsService, NewsService>()
				.AddTransient<IHealthCheckService, HealthCheckService>()
				.AddTransient<ICommentsService, CommentsService>()
				.AddTransient<IStandingsService, StandingsService>()
				.AddTransient<IRacesService, RacesService>()
				.AddTransient<ITimeService, TimeService>()
				.AddTransient<ICalendarService, CalendarService>()
				.AddTransient<IResultsService, ResultsService>()
				.AddTransient<IAuthService, AuthService>()
				.AddTransient<ITimeService, TimeService>()
				.AddTransient<IVersioningService, VersioningService>()
				.AddTransient<IBroadcastsService, BroadcastsService>()
				.AddTransient<IGuidService, GuidService>()
				.AddTransient<ISeasonsService, SeasonsService>()
				.AddTransient<IGridsService, GridsService>()
				.AddTransient<ITracksService, TracksService>()
				.AddTransient<IDriversService, DriversService>()
				.AddTransient<ITeamsService, TeamsService>()
				.AddTransient<IEntriesService, EntriesService>()
				.AddTransient<IEnginesService, EnginesService>()
				.AddTransient<IStatisticsService, StatisticsService>();
		}

		private static BBCodeParser BuildBBCodeParser(IServiceProvider serviceProvider)
		{
			return new BBCodeParser(new []
			{
				new BBTag("b", "<b>", "</b>"),
					new BBTag("i", "<span style=\"font-style:italic;\">", "</span>"),
					new BBTag("u", "<span style=\"text-decoration:underline;\">", "</span>"),
					new BBTag("ul", "<ul>", "</ul>"),
					new BBTag("ol", "<ol>", "</ol>"),
					new BBTag("li", "<li>", "</li>"),
					new BBTag("url", "<a href=\"${href}\">", "</a>", new BBAttribute("href", ""), new BBAttribute("href", "href")),
					new BBTag("cyt", "<q>", "</q>"),
					new BBTag("red", "<span class=\"news-text-red\">", "</span>")
			});
		}
	}
}

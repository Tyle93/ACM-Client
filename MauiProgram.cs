using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiApp1.Data;
using ACM.Context;
using System.ServiceProcess;
using ACM.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		builder.Services.AddLogging((options) =>
		{
			options.ClearProviders();
			options.AddEventLog();
			options.AddFilter("Microsoft", LogLevel.None);
		});
		
		return builder.Build();
	}
}

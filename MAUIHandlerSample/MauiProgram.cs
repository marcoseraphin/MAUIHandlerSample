﻿using Microsoft.Extensions.Logging;

namespace MAUIHandlerSample;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.ConfigureMauiHandlers(handlers =>
				{
#if __IOS__ || __ANDROID__
					handlers.AddHandler<CustomEntry, CustomEntryHandler>();
#endif
				});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

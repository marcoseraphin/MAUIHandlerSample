using Microsoft.Extensions.Logging;

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

		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
		{
			if (view is BorderlessEntry)
			{
#if __ANDROID__
        handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
		// handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToNative());
#elif __IOS__
				handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
				handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
			}
		});

		return builder.Build();
	}
}

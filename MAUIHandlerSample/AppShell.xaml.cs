namespace MAUIHandlerSample;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

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
	}
}

using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Handlers;

namespace MAUIHandlerSample;

public partial class CustomEntryHandler : ViewHandler<ICustomEntry, AppCompatEditText>
{
    public CustomEntryHandler() : base(CustomEntryMapper)
    {

    }
    public static PropertyMapper<ICustomEntry, CustomEntryHandler> CustomEntryMapper = new PropertyMapper<ICustomEntry, CustomEntryHandler>(ViewHandler.ViewMapper)
    {
        [nameof(ICustomEntry.Text)] = MapText,
        [nameof(ICustomEntry.TextColor)] = MapTextColor,
        [nameof(ICustomEntry.ContentBackgroundColor)] = ContentBackgroundColor
    };
    protected override AppCompatEditText CreatePlatformView()
    {
        return new AppCompatEditText(Context);
    }
    private static void ContentBackgroundColor(CustomEntryHandler handler, ICustomEntry entry)
    {
        if (handler.PlatformView != null)
        {
            handler.PlatformView.SetBackgroundColor(entry.ContentBackgroundColor.ToAndroid());
        }
    }
    static void MapText(CustomEntryHandler handler, ICustomEntry entry)
    {
        handler.PlatformView.Text = entry.Text + " (Android)";
    }
    static void MapTextColor(CustomEntryHandler handler, ICustomEntry entry)
    {
        handler.PlatformView?.SetTextColor(entry.TextColor.ToAndroid());
    }
}

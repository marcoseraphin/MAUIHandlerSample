using MAUIHandlerSample;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace MAUIHandlerSample;

public class CustomEntryHandler : ViewHandler<ICustomEntry, UITextField>
{
    // public CustomEntryHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
    // {
    // }

    public CustomEntryHandler() : base(CustomEntryMapper)
    {

    }

    public static PropertyMapper<ICustomEntry, CustomEntryHandler> CustomEntryMapper = new PropertyMapper<ICustomEntry, CustomEntryHandler>(ViewHandler.ViewMapper)
    {
        [nameof(ICustomEntry.Text)] = MapText,
        [nameof(ICustomEntry.TextColor)] = MapTextColor,
        [nameof(ICustomEntry.ContentBackgroundColor)] = ContentBackgroundColor,
    };

    private static void ContentBackgroundColor(CustomEntryHandler handler, ICustomEntry entry)
    {
        if (handler.PlatformView != null)
        {
            handler.PlatformView.BackgroundColor = entry.ContentBackgroundColor.ToPlatform();
        }
    }

    private static void MapTextColor(CustomEntryHandler handler, ICustomEntry entry)
    {
        if (handler.PlatformView != null)
        {
            handler.PlatformView.TextColor = entry.TextColor.ToPlatform();
        }
    }

    private static void MapText(CustomEntryHandler handler, ICustomEntry entry)
    {
        if (handler.PlatformView != null)
        {
            handler.PlatformView.Text = entry.Text + " (iOS)";
        }
    }

    protected override UITextField CreatePlatformView()
    {
        return new UITextField();
    }
}

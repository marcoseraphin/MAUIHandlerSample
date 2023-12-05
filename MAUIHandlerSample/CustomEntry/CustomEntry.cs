
namespace MAUIHandlerSample;

public class CustomEntry : View, ICustomEntry
{
    public required string Text { get; set; }
    public required Color TextColor { get; set; }

    public static readonly BindableProperty ContentBackgroundColorProperty = BindableProperty.Create(nameof(CustomEntry), typeof(Color), typeof(CustomEntry), Colors.Transparent);

    public Color ContentBackgroundColor
    {
        get => (Color)GetValue(ContentBackgroundColorProperty);
        set => SetValue(ContentBackgroundColorProperty, value);
    }

}

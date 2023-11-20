using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace UWP.Toolkit.Controls.Interfaces;

[ExclusiveTo(typeof(PreviewPopup))]
public interface IPreviewPopup
{
    bool IsOpen { get; }
    bool IsLightDismissEnabled { get; set; }
    Style OverlayStyle { get; set; }
    Thickness? Padding { get; set; }
    Brush Background { get; set; }

    Style CloseButtonStyle { get; set; }
    string CloseButtonToolTip { get; set; }
    Visibility IsCloseButtonVisible { get; set; }

    UIElement Content { get; set; }
    Style ContentStyle { get; set; }
    CornerRadius? ContentCornerRadius { get; set; }
    Thickness? ContentPadding { get; set; }
    Brush ContentBackground { get; set; }
    Thickness? ContentBorderThickness { get; set; }
    Brush ContentBorderBrush { get; set; }

    void Show();
    void Hide();
}

using UWP.Toolkit.Controls.Enum;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;

namespace UWP.Toolkit.Controls.Interfaces;

[ExclusiveTo(typeof(ContentOverlayPopup))]
internal interface IContentOverlayPopup
{
    TitleBarSize TitleBarHeight { get; set; }
    object TitleContent { get; set; }
    string CloseButtonToolTip { get; set; }
    Visibility IsCloseButtonVisible { get; set; }
    object BodyContent { get; set; }
    bool IsOpen { get; set; } // FIX: private set
    bool IsLightDismissEnabled { get; set; }
    double ColumnSpacing { get; set; }
    double RowSpacing { get; set; }

    Thickness Padding { get; set; }
    string Background { get; set; }

    void Show();
    void Hide();
}

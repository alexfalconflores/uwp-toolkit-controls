using System.Collections.Generic;
using System.Diagnostics;
using UWP.Markup;
using UWP.Markup.IconElement;
using UWP.Markup.Transition;
using UWP.Toolkit.Controls.Interfaces;
using UWP_Toolkit.Extensions;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace UWP.Toolkit.Controls;

/// <summary>
/// Represents a full-screen popup with content overlay functionality.
/// </summary>
public sealed class PreviewPopup : UserControl, IPreviewPopup
{
    #region private fields
    private Popup popup;
    private Grid overlay;
    #endregion private fields

    #region public properties
    /// <summary>
    /// Gets or sets the toolTip to be displayed on the overlay's close button.
    /// The default value is an <see cref="string.Empty"/>
    /// </summary>
    public string CloseButtonToolTip { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the visibility of the overlay's close button.
    /// The default value is <see cref="Visibility.Visible"/>.
    /// </summary>
    public Visibility IsCloseButtonVisible { get; set; } = Visibility.Visible;

    /// <summary>
    /// Gets a value that indicates whether the <see cref="PreviewPopup"/> is open.
    /// The default value is <see langword="false"/>.
    /// </summary>
    public bool IsOpen { get; private set; } = false;

    /// <summary>
    /// Gets or sets a value that indicates whether the <see cref="PreviewPopup"/> can be dismissed
    /// by clicking in the light-dismiss region or by pressing the ESC key.
    /// The default value is <see langword="false"/>.
    /// </summary>
    public bool IsLightDismissEnabled { get; set; } = false;

    /// <summary>
    /// Gets or sets the padding inside the control.
    /// The default value is 0/>. When the <see cref="PreviewPopup.Show"/> method is called.
    /// </summary>
    public Thickness? ContentPadding { get; set; }

    /// <summary>
    /// Gets or sets the corner radius of the overlay's content.
    /// The default value is "OverlayCornerRadius". When the <see cref="PreviewPopup.Show"/> method is called.
    /// </summary>
    public CornerRadius? ContentCornerRadius { get; set; }

    /// <summary>
    /// Gets or sets the background of the overlay's content.
    /// The default value is "CardBackgroundFillColorSecondaryBrush". When the <see cref="PreviewPopup.Show"/> method is called.
    /// </summary>
    public Brush ContentBackground { get; set; }

    /// <summary>
    /// Gets or sets the border thickness of the overlay's content.
    /// The default value is 1. When the <see cref="PreviewPopup.Show"/> method is called.
    /// </summary>
    public Thickness? ContentBorderThickness { get; set; }

    /// <summary>
    /// Gets or sets the border brush of the overlay's content.
    /// The default value is "SurfaceStrokeColorDefaultBrush". When the <see cref="PreviewPopup.Show"/> method is called.
    /// </summary>
    public Brush ContentBorderBrush { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Style"/> of the overlay.
    /// It's applied to the <see cref="Grid"/> that contains the overlay's content.
    /// The default value is "DefaultPreviewPopupOverlayStyle".
    /// 
    /// </summary>
    public Style OverlayStyle { get; set; } = "DefaultPreviewPopupOverlayStyle".GetStyle();

    /// <summary>
    /// Gets or sets the <see cref="Style"/> of the Content.
    /// It's applied to the <see cref="Grid"/> that contains the content.
    /// The default value is "DefaultPreviewPopupContentStyle".
    /// </summary>
    public Style ContentStyle { get; set; } = "DefaultPreviewPopupContentStyle".GetStyle();

    /// <summary>
    /// Gets or sets the <see cref="Style"/> of the close button.
    /// It's applied to the <see cref="Button"/> that contains the close button.
    /// </summary>
    public Style CloseButtonStyle { get; set; } = "DefaultPreviewPopupCloseButtonStyle".GetStyle();
    #endregion public properties

    #region overrides properties
    /// <summary>
    /// Gets the overlay's padding. The default value is 26,36,11,36. when the <see cref="PreviewPopup.Show"/> method is called.
    /// </summary>
    public new Thickness? Padding { get; set; }

    /// <summary>
    /// Gets the overlay's background. The default value is "AcrylicBackgroundFillColorBaseBrush" when the <see cref="PreviewPopup.Show"/> method is called.
    /// </summary>
    public new Brush Background { get; set; }

    /// <summary>
    /// Gets or sets the Content.
    /// </summary>
    public new UIElement Content { get; set; }
    #endregion overrides properties

    #region constructor
    public PreviewPopup()
    {
        Window.Current.CoreWindow.KeyDown += (s, e) =>
        {
            if (e.VirtualKey == Windows.System.VirtualKey.Escape && IsLightDismissEnabled) Hide();
        };
    }
    #endregion constructor

    #region public methods
    public void Hide()
    {
        if (IsOpen)
        {
            IsOpen = false;
            popup.IsOpen = false;
            popup = null;
        }
    }

    public void Show()
    {
        IsOpen = true;
        TransitionCollection popupTransitionCollection = new TransitionCollection().AddTransition(new PopupThemeTransition());

        popup = new Popup()
           .IsLightDismissEnabled(false)
           .ShouldConstrainToRootBounds(true)
           .ChildTransitions(popupTransitionCollection);

        overlay = new Grid()
            .Style(OverlayStyle)
            .BackgroundProperty(Background)
            .PaddingProperty(Padding)
            .EffectiveViewport()
            .Rows("*")
            .Columns("*")
            .Parent(popup)
            .OnPointerPressed((sender, args) =>
            {
                if (IsLightDismissEnabled && args.OriginalSource == sender) Hide();
            });

        Grid wrapper = new Grid()
            .Alignment(VerticalAlignment.Stretch, HorizontalAlignment.Center)
            .Spacing(8)
            .Rows("*")
            .Columns("Auto", "Auto")
            .Parent(overlay);

        Grid content = new Grid()
            .Style(ContentStyle)
            .PaddingProperty(ContentPadding)
            .BackgroundProperty(ContentBackground)
            .BorderThicknessProperty(ContentBorderThickness)
            .BorderBrushProperty(ContentBorderBrush)
            .CornerRadiusProperty(ContentCornerRadius)
            .Rows("*")
            .Columns("*")
            .AddChild(Content)
            .Parent(wrapper);

        FontIcon closeIcon = new FontIcon()
            .Glyph("\uE8BB")
            .FontSize(12);

        Button closeButton = new Button()
            .Style(CloseButtonStyle)
            .VerticalAlignment(VerticalAlignment.Top)
            .Visibility(IsCloseButtonVisible)
            .Content(closeIcon)
            .ToolTip(CloseButtonToolTip)
            .Column(1)
            .OnClick(() => Hide())
            .Parent(wrapper);
        popup.IsOpen(true);
    }
    #endregion public methods
}

// Extensions
public static class BrushExtensions
{
    public static SolidColorBrush ToSolidColorBrush(this Color color)
    {
        return new SolidColorBrush(color);
    }
}


// ResourceExtensions
public static class CornerRadiusExtensions
{
    public static CornerRadius GetCornerRadius(this string key)
    {
        if (!Application.Current.Resources.ContainsKey(key)) throw new KeyNotFoundException();
        return (CornerRadius)Application.Current.Resources[key];
    }
}

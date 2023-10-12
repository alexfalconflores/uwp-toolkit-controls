using UWP.Toolkit.Controls.Enum;
using UWP.Toolkit.Controls.Interfaces;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;

using UWP.Markup;
using UWP.Markup.Transition;
using UWP.Markup.IconElement;
using UWP_Toolkit.Extensions;

namespace UWP.Toolkit.Controls;

/// <summary>
/// Represents a full-screen popup with content overlay functionality, typically used for
/// displaying content that should cover the entire screen while respecting the TitleBar height.
/// </summary>
public sealed class ContentOverlayPopup : UserControl, IContentOverlayPopup
{
    #region private fields
    private Popup popup;
    private Grid overlay;
    #endregion private fields

    #region public properties
    /// <summary>
    /// Gets or sets the height of the TitleBar in the overlay.
    /// The default value is <see cref="TitleBarSize.Short"/>.
    /// </summary>
    public TitleBarSize TitleBarHeight { set; get; } = TitleBarSize.Short;

    /// <summary>
    /// Gets or sets the content to be displayed in the overlay's title area.
    /// The default value is null.
    /// </summary>
    public object TitleContent { set; get; } = null;

    /// <summary>
    /// Gets or sets the toolTip to be displayed on the overlay's close button.
    /// The default value is an <see cref="string.Empty"/>
    /// </summary>
    public string CloseButtonToolTip { set; get; } = string.Empty;

    /// <summary>
    /// Gets or sets the visibility of the overlay's close button.
    /// The default value is <see cref="Visibility.Visible"/>.
    /// </summary>
    public Visibility IsCloseButtonVisible { set; get; } = Visibility.Visible;

    /// <summary>
    /// Gets or sets the content to be displayed in the overlay's body area.
    /// The default value is null.
    /// </summary>
    public object BodyContent { set; get; } = null;

    /// <summary>
    /// Gets a value that indicates whether the <see cref="ContentOverlayPopup"/> is open.
    /// The default value is false.
    /// </summary>
    public bool IsOpen { set; get; } = false; // FIX: private set

    /// <summary>
    /// Gets or sets a value that indicates whether the <see cref="ContentOverlayPopup"/> can be dismissed
    /// by clicking in the light-dismiss region or by pressing the ESC key.
    /// The default value is false.
    /// </summary>
    public bool IsLightDismissEnabled { set; get; } = false;

    /// <summary>
    /// Gets or sets the spacing between the overlay's columns.
    /// If the close button is visible, the spacing is applied to the right of the title content.
    /// The default value is 8.
    /// </summary>
    public double ColumnSpacing { set; get; } = 8;

    /// <summary>
    /// Gets or sets the spacing between the overlay's rows.
    /// The default value is 8.
    /// </summary>
    public double RowSpacing { set; get; } = 8;
    #endregion public properties

    #region override properties
    /// <summary>
    /// Gets or sets the padding inside the control.
    /// The default value is 40,30,40,20.
    /// </summary>
    public new Thickness Padding { set; get; } = new Thickness(40, 30, 40, 20);

    /// <summary>
    /// Gets or sets the background color resources name of the control.
    /// <list type="bullet">
    /// <item>Only support AcrylicBrush Resource.</item>
    /// </list>
    /// The default value is "AcrylicInAppFillColorDefaultBrush".
    /// </summary>
    public new string Background { set; get; } = "AcrylicInAppFillColorDefaultBrush";
    #endregion override properties

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the ContentOverlayPopup class.
    /// </summary>
    public ContentOverlayPopup()
    {
        ActualThemeChanged += OnRequestedThemeChanged;
        Window.Current.CoreWindow.KeyDown += (coreWindowSender, coreWindowArgs) =>
        {
            if (coreWindowArgs.VirtualKey == Windows.System.VirtualKey.Escape && IsLightDismissEnabled)
                Hide();
        };
    }
    #endregion Constructor

    #region override methods
    // Event handler for the ActualThemeChanged event.
    private void OnRequestedThemeChanged(FrameworkElement sender, object args)
    {
        overlay.Background = Background.GetAcrylicBrush();
    }
    #endregion override methods

    #region public methods
    /// <summary>
    /// Hides the <see cref="ContentOverlayPopup"/>.
    /// </summary>
    public void Hide()
    {
        if (IsOpen)
        {
            IsOpen = false;
            popup.IsOpen(false);
            popup = null;
        }
    }

    /// <summary>
    /// Displays the <see cref="ContentOverlayPopup"/>, covering the entire screen while respecting the TitleBar height.
    /// </summary>
    public void Show()
    {
        IsOpen = true;
        TransitionCollection popupTransitionCollection = new TransitionCollection()
            .AddTransition(new PopupThemeTransition());

        popup = new Popup()
            .IsLightDismissEnabled(false)
            .ShouldConstrainToRootBounds(true)
            .VerticalOffset(TitleBarHeight.ToDouble())
            .ChildTransitions(popupTransitionCollection);

        overlay = new Grid()
            .Background(Background.GetAcrylicBrush())
            .Rows("auto", "*")
            .Columns("*", "auto")
            .ColumnSpacing(IsCloseButtonVisible == Visibility.Visible ? ColumnSpacing : 0)
            .RowSpacing(RowSpacing)
            .Padding(Padding);
        overlay.PointerPressed += (gridSender, gridArgs) =>
        {
            if (IsLightDismissEnabled && gridArgs.OriginalSource == gridSender) Hide();
        };
        #region  tapped event overlay
        //overlay.Tapped += (gridSender, gridArgs) =>
        //{
        //    // Check if the event occurred in the overlay.
        //    if (gridArgs.OriginalSource == gridSender)
        //    {
        //        gridArgs.Handled = true;
        //        Hidden();
        //    }
        //};
        #endregion tapped event overlay
        overlay.EffectiveViewportChanged += (gridSender, gridArgs) =>
        {
            overlay.Width = gridArgs.EffectiveViewport.Width;
            overlay.Height = gridArgs.EffectiveViewport.Height - TitleBarHeight.ToDouble();
        };
        popup.Child = overlay;

        ContentPresenter titleContentPresenter = new ContentPresenter().Content(TitleContent);
        overlay.AddChild(titleContentPresenter);

        FontIcon closeIcon = new FontIcon()
            .Glyph("\uE8BB")
            .FontSize(12);

        Button closeButton = new Button()
            .Padding(10)
            .Background(Colors.Transparent)
            .BorderBrush(Colors.Transparent)
            .Content(closeIcon)
            .Visibility(IsCloseButtonVisible)
            .ToolTip(CloseButtonToolTip)
            .HorizontalAlignment(HorizontalAlignment.Right)
            .Column(1);
        closeButton.Click += (buttonPopupSender, popupArgs) => Hide();
        overlay.AddChild(closeButton);

        ContentPresenter bodyContentPresenter = new ContentPresenter()
            .Row(1)
            .ColumnSpan(2)
            .Content(BodyContent);
        overlay.AddChild(bodyContentPresenter);
        popup.IsOpen(true);
    }
    #endregion public methods
}

/// <summary>
/// Represents a full-screen popup with content overlay functionality, typically used for displaying
/// content that should cover the entire screen while respecting the TitleBar height.
/// Provides extension methods for the <see cref="ContentOverlayPopup"/> in XAML markup.
/// </summary>
public static class ContentOverlayPopupMarkup
{
    #region v0.0.2
    /// <summary>
    /// Sets the height of the TitleBar in the overlay.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="titleBarSize"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified TitleBarHeight. </returns>
    public static ContentOverlayPopup TitleBarHeight(this ContentOverlayPopup element, TitleBarSize titleBarSize)
    {
        element.TitleBarHeight = titleBarSize;
        return element;
    }

    /// <summary>
    /// Sets the content to be displayed in the overlay's title area.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="titleContent"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified TitleContent.</returns>
    public static ContentOverlayPopup TitleContent(this ContentOverlayPopup element, object titleContent)
    {
        element.TitleContent = titleContent;
        return element;
    }

    /// <summary>
    /// Sets the toolTip to be displayed on the overlay's close button.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="closeButtonToolTip"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified CloseButtonToolTip.</returns>
    public static ContentOverlayPopup CloseButtonToolTip(this ContentOverlayPopup element, string closeButtonToolTip)
    {
        element.CloseButtonToolTip = closeButtonToolTip;
        return element;
    }

    /// <summary>
    /// Sets the visibility of the overlay's close button.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="isCloseButtonVisible"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified BodyContent.</returns>
    public static ContentOverlayPopup IsCloseButtonVisible(this ContentOverlayPopup element, Visibility isCloseButtonVisible)
    {
        element.IsCloseButtonVisible = isCloseButtonVisible;
        return element;
    }

    /// <summary>
    /// Sets the content to be displayed in the overlay's body area.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="bodyContent"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified BodyContent.</returns>
    public static ContentOverlayPopup BodyContent(this ContentOverlayPopup element, object bodyContent)
    {
        element.BodyContent = bodyContent;
        return element;
    }

    /// <summary>
    /// Sets a value that indicates whether the <see cref="ContentOverlayPopup"/> is open.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="isOpen"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified IsOpen.</returns>
    public static ContentOverlayPopup IsOpen(this ContentOverlayPopup element, bool isOpen)
    {
        element.IsOpen = isOpen;
        return element;
    }

    /// <summary>
    /// Sets a value that indicates whether the <see cref="ContentOverlayPopup"/> can be dismissed
    /// by clicking in the light-dismiss region or by pressing the ESC key.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="isLightDismissEnabled"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified BodyContent.</returns>
    public static ContentOverlayPopup IsLightDismissEnabled(this ContentOverlayPopup element, bool isLightDismissEnabled)
    {
        element.IsLightDismissEnabled = isLightDismissEnabled;
        return element;
    }

    /// <summary>
    /// Sets the spacing between the overlay's columns.
    /// If the close button is visible, the spacing is applied to the right of the title content.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="columnSpacing"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified BodyContent.</returns>
    public static ContentOverlayPopup ColumnSpacing(this ContentOverlayPopup element, double columnSpacing)
    {
        element.ColumnSpacing = columnSpacing;
        return element;
    }

    /// <summary>
    /// Sets the spacing between the overlay's rows.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="rowSpacing"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified BodyContent.</returns>
    public static ContentOverlayPopup RowSpacing(this ContentOverlayPopup element, double rowSpacing)
    {
        element.RowSpacing = rowSpacing;
        return element;
    }

    /// <summary>
    /// Sets the background color resources name of the control.
    /// <list type="bullet">
    /// <item>Only support AcrylicBrush Resource.</item>
    /// </list>
    /// The default value is "AcrylicInAppFillColorDefaultBrush".
    /// </summary>
    /// <param name="element"></param>
    /// <param name="background"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified BodyContent.</returns>
    public static ContentOverlayPopup Background(this ContentOverlayPopup element, string background)
    {
        element.Background = background;
        return element;
    }

    /// <summary>
    /// Sets the padding inside a control. The default is a Thickness with values of 0 on all four sides.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="padding"></param>
    /// <returns>The modified <see cref="ContentOverlayPopup"/> with the specified BodyContent.</returns>
    public static ContentOverlayPopup Padding(this ContentOverlayPopup element, Thickness padding)
    {
        element.Padding = padding;
        return element;
    }

    /// <summary>
    /// Sets the padding inside a control. The default value is 0.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="padding"></param>
    /// <returns>The <see cref="ContentOverlayPopup"/> instance for method chaining</returns>
    public static ContentOverlayPopup Padding(this ContentOverlayPopup element, double padding = 0)
    {
        element.Padding = new Thickness(padding);
        return element;
    }

    /// <summary>
    /// Sets the padding inside a control. The default value is left: 0, top: 0, right: 0, bottom: 0.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="left"></param>
    /// <param name="top"></param>
    /// <param name="right"></param>
    /// <param name="bottom"></param>
    /// <returns>The <see cref="ContentOverlayPopup"/> instance for method chaining</returns>
    public static ContentOverlayPopup Padding(this ContentOverlayPopup element, double left = 0, double top = 0, double right = 0, double bottom = 0)
    {
        element.Padding = new Thickness(left, top, right, bottom);
        return element;
    }

    /// <summary>
    /// Sets the padding inside a control. The default value is horizontal: 0, vertical: 0.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    /// <returns>The <see cref="ContentOverlayPopup"/> instance for method chaining</returns>
    public static ContentOverlayPopup Padding(this ContentOverlayPopup element, double horizontal = 0, double vertical = 0)
    {
        element.Padding = new Thickness(horizontal, vertical, horizontal, vertical);
        return element;
    }
    #endregion v0.0.2
}

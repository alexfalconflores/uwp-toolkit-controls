using System.Windows.Input;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

using UWP.Toolkit.Controls.Helper;
using UWP.Toolkit.Controls.Enum;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP.Toolkit.Controls;

/// <summary>
/// Represents a Title Bar that can be used in a UWP APP.
/// </summary>
public sealed partial class TitleBar : UserControl
{
    #region private fields
    private ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
    private static bool _isInitialized = false;
    #endregion private fields

    #region Size
    /// <summary>
    /// Gets or sets the size of the TitleBar.
    /// </summary>
    /// <returns>
    /// A value of the enumeration. The default is **Short**.
    /// </returns>
    public TitleBarSize Size
    {
        get { return (TitleBarSize)GetValue(SizeProperty); }
        set { SetValue(SizeProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="Size"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(
        nameof(Size),
        typeof(TitleBarSize),
        typeof(TitleBar),
        new PropertyMetadata(TitleBarSize.Short));
    //new PropertyMetadata(TitleBarSize.Short, OnSizePropertyChanged)
    #endregion Size

    #region Background
    /// <summary>
    /// Gets or sets a brush that provides the background of the TitleBar.
    /// </summary>
    /// <returns>
    /// The brush that provides the background of the TitleBar. The default is **Transparent**.
    /// </returns>
    public Brush TitleBarBackground
    {
        get { return (Brush)GetValue(TitleBarBackgroundProperty); }
        set { SetValue(TitleBarBackgroundProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="TitleBarBackground"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty TitleBarBackgroundProperty = DependencyProperty.Register(
        nameof(TitleBarBackground),
        typeof(Brush),
        typeof(TitleBar),
        new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));
    #endregion Background

    #region App Icon
    /// <summary>
    /// Gets or sets the source for the App Icon on the TitleBar.
    /// </summary>
    /// <returns>
    /// An object that represents the image source file for the drawn image. Typically you set this with a BitmapImage object.
    /// constructed with a the Uniform Resource Identifier (URI) that describes the path to a valid image source file.
    /// Or, you can initialize a BitmapSource with a stream, perhaps a stream from a storage file.
    /// </returns>
    public ImageSource AppIconSource
    {
        get { return (ImageSource)GetValue(AppIconSourceProperty); }
        set { SetValue(AppIconSourceProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="AppIconSource"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty AppIconSourceProperty = DependencyProperty.Register(
        nameof(AppIconSource),
        typeof(ImageSource),
        typeof(TitleBar),
        new PropertyMetadata(null));
    //new PropertyMetadata(null, OnAppIconSourcePropertyChanged)

    /// <summary>
    /// Gets or sets the visibility of the App Icon on the TitleBar.
    /// </summary>
    /// <returns>
    /// A value of the enumeration. The default is **Visible**.
    /// </returns>
    public Visibility IsAppIconVisible
    {
        get { return (Visibility)GetValue(IsAppIconVisibleProperty); }
        set { SetValue(IsAppIconVisibleProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="IsAppIconVisible"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsAppIconVisibleProperty = DependencyProperty.Register(
        nameof(IsAppIconVisible),
        typeof(Visibility),
        typeof(TitleBar),
        new PropertyMetadata(Visibility.Visible));
    //new PropertyMetadata(Visibility.Visible, OnAppIconVisiblePropertyChanged)
    #endregion App Icon

    #region App Name
    /// <summary>
    /// Gets or sets the text of the App Name.
    /// </summary>
    /// <returns>
    /// A string that specifies the text of the App Name. The default is an empty string.
    /// </returns>
    public string AppName
    {
        get { return (string)GetValue(AppNameProperty); }
        set { SetValue(AppNameProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="AppName"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty AppNameProperty = DependencyProperty.Register(
        nameof(AppName),
        typeof(string),
        typeof(TitleBar),
        new PropertyMetadata(string.Empty));
    //new PropertyMetadata(null, OnAppTitlePropertyChanged)

    /// <summary>
    /// Gets or sets the visibility of the App Name on the TitleBar.
    /// </summary>
    /// <returns>
    /// A value of the enumeration. The default is **Visible**.
    /// </returns>
    public Visibility IsAppNameVisible
    {
        get { return (Visibility)GetValue(IsAppNameVisibleProperty); }
        set { SetValue(IsAppNameVisibleProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="IsAppNameVisible"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsAppNameVisibleProperty = DependencyProperty.Register(
        nameof(IsAppNameVisible),
        typeof(Visibility),
        typeof(TitleBar),
        new PropertyMetadata(Visibility.Visible));
    #endregion App Name

    #region Release Tag
    /// <summary>
    /// Gets or sets Gets or sets the text of the Release Tag.
    /// </summary>
    /// /// <returns>
    /// A string that specifies the text  of the Release Tag. The default is an empty string.
    /// </returns>
    public string ReleaseTag
    {
        get { return (string)GetValue(ReleaseTagProperty); }
        set { SetValue(ReleaseTagProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="ReleaseTag"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty ReleaseTagProperty = DependencyProperty.Register(
        nameof(ReleaseTag),
        typeof(string),
        typeof(TitleBar),
        new PropertyMetadata(string.Empty));
    //new PropertyMetadata(null, OnReleaseTagPropertyChanged)

    /// <summary>
    /// Gets or sets the visibility of the Release Tag on the TitleBar.
    /// </summary>
    /// <returns>
    /// A value of the enumeration. The default is **Visible**.
    /// </returns>
    public Visibility IsReleaseTagVisible
    {
        get { return (Visibility)GetValue(IsReleaseTagVisibleProperty); }
        set { SetValue(IsReleaseTagVisibleProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="IsReleaseTagVisible"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsReleaseTagVisibleProperty = DependencyProperty.Register(
        nameof(IsReleaseTagVisible),
        typeof(Visibility),
        typeof(TitleBar),
        new PropertyMetadata(Visibility.Collapsed));
    //new PropertyMetadata(Visibility.Collapsed, OnReleaseTagVisiblePropertyChanged)

    #endregion Release Tag

    #region Back Button
    /// <summary>
    /// Gets or sets the command to invoke when this back button is pressed.
    /// </summary>
    /// <returns>
    /// The command to invoke when this back button is pressed. The default is null.
    /// </returns>
    public ICommand BackButtonCommand
    {
        get { return (ICommand)GetValue(BackButtonCommandProperty); }
        set { SetValue(BackButtonCommandProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="BackButtonCommand"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty BackButtonCommandProperty = DependencyProperty.Register(
        nameof(BackButtonCommand),
        typeof(ICommand),
        typeof(TitleBar),
        new PropertyMetadata(null));
    //new PropertyMetadata(null, OnIsBackButtonVisiblePropertyChanged)

    /// <summary>
    /// Gets or sets the parameter to pass to the <see cref="BackButtonCommand"/> property.
    /// </summary>
    /// <returns>
    /// The parameter to pass to the <see cref="BackButtonCommand"/> property. The default is null.
    /// </returns>
    public object BackButtonCommandParameter
    {
        get { return (object)GetValue(BackButtonCommandParameterProperty); }
        set { SetValue(BackButtonCommandParameterProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="BackButtonCommandParameter"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty BackButtonCommandParameterProperty = DependencyProperty.Register(
        nameof(BackButtonCommandParameter),
        typeof(object),
        typeof(TitleBar),
        new PropertyMetadata(null));
    //new PropertyMetadata(null, OnIsBackButtonVisiblePropertyChanged)

    /// <summary>
    /// Gets or sets the visibility of the back button.
    /// </summary>
    /// <returns>
    /// A value of the enumeration. The default is **Collapsed**.
    /// </returns>
    public Visibility IsBackButtonVisible
    {
        get { return (Visibility)GetValue(IsBackButtonVisibleProperty); }
        set { SetValue(IsBackButtonVisibleProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="IsBackButtonVisible"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsBackButtonVisibleProperty = DependencyProperty.Register(
        nameof(IsBackButtonVisible),
        typeof(Visibility),
        typeof(TitleBar),
        new PropertyMetadata(Visibility.Collapsed));
    //new PropertyMetadata(null, OnIsBackButtonVisiblePropertyChanged)

    /// <summary>
    /// Gets or sets a value indicating whether the user can interact with the back button.
    /// </summary>
    /// <returns>
    /// **true** if the user can interact with the back button otherwise **false**. The default is **true**.
    /// </returns>
    public bool IsBackButtonEnabled
    {
        get { return (bool)GetValue(IsBackButtonEnabledProperty); }
        set { SetValue(IsBackButtonEnabledProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="IsBackButtonEnabled"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsBackButtonEnabledProperty = DependencyProperty.Register(
        nameof(IsBackButtonEnabled),
        typeof(bool),
        typeof(TitleBar),
        new PropertyMetadata(true));
    //new PropertyMetadata(null, OnIsBackButtonEnabledPropertyChanged)
    #endregion Back Button

    #region Navigation Button
    /// <summary>
    /// Gets or sets the command to invoke when this navigation button is pressed.
    /// </summary>
    /// <returns>
    /// The command to invoke when this back navigation is pressed. The default is null.
    /// </returns>
    public ICommand NavigationButtonCommand
    {
        get { return (ICommand)GetValue(NavigationButtonCommandProperty); }
        set { SetValue(NavigationButtonCommandProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="NavigationButtonCommand"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty NavigationButtonCommandProperty = DependencyProperty.Register(
        nameof(NavigationButtonCommand),
        typeof(ICommand),
        typeof(TitleBar),
        new PropertyMetadata(null));
    //new PropertyMetadata(null, OnIsNavigationButtonVisiblePropertyChanged)

    /// <summary>
    /// Gets or sets the parameter to pass to the <see cref="NavigationkButtonCommand"/> property.
    /// </summary>
    /// <returns>
    /// The parameter to pass to the <see cref="NavigationButtonCommand"/> property. The default is null.
    /// </returns>
    public object NavigationButtonCommandParameter
    {
        get { return (object)GetValue(NavigationButtonCommandParameterProperty); }
        set { SetValue(NavigationButtonCommandParameterProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="NavigationButtonCommandParameter"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty NavigationButtonCommandParameterProperty = DependencyProperty.Register(
        nameof(NavigationButtonCommandParameter),
        typeof(object),
        typeof(TitleBar),
        new PropertyMetadata(null));
    //new PropertyMetadata(null, OnIsNavigationButtonVisiblePropertyChanged)

    /// <summary>
    /// Gets or sets the visibility of the navigation button.
    /// </summary>
    /// <returns>
    /// A value of the enumeration. The default is **Collapsed**.
    /// </returns>
    public Visibility IsNavigationButtonVisible
    {
        get { return (Visibility)GetValue(IsNavigationButtonVisibleProperty); }
        set { SetValue(IsNavigationButtonVisibleProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="IsNavigationButtonVisible"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsNavigationButtonVisibleProperty = DependencyProperty.Register(
        nameof(IsNavigationButtonVisible),
        typeof(Visibility),
        typeof(TitleBar),
        new PropertyMetadata(Visibility.Collapsed));
    //new PropertyMetadata(null, OnIsNavigationButtonVisiblePropertyChanged)

    /// <summary>
    /// Gets or sets a value indicating whether the user can interact with the navigation button.
    /// </summary>
    /// <returns>
    /// **true** if the user can interact with the navigation button otherwise **false**. The default is **true**.
    /// </returns>
    public bool IsNavigationButtonEnabled
    {
        get { return (bool)GetValue(IsNavigationButtonEnabledProperty); }
        set { SetValue(IsNavigationButtonEnabledProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="IsNavigationButtonEnabled"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsNavigationButtonEnabledProperty = DependencyProperty.Register(
        nameof(IsNavigationButtonEnabled),
        typeof(bool),
        typeof(TitleBar),
        new PropertyMetadata(true));
    //new PropertyMetadata(null, OnIsNavigationButtonEnabledPropertyChanged)
    #endregion Navigation Button

    #region Search Control
    /// <summary>
    /// Gets or sets an AutoSuggestBox to be displayed in the TitleBar.
    /// </summary>
    /// <returns>
    /// An AutoSuggestBox to be displayed in the TitleBar.
    /// </returns>
    public AutoSuggestBox Search
    {
        get { return (AutoSuggestBox)GetValue(SearchProperty); }
        set { SetValue(SearchProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="Search"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SearchProperty = DependencyProperty.Register(
        nameof(Search),
        typeof(AutoSuggestBox),
        typeof(TitleBar),
        new PropertyMetadata(null));
    //new PropertyMetadata(null, OnSearchPropertyChanged)
    #endregion Search Control

    #region PanelLeft
    /// <summary>
    /// Gets or sets a UI element that is shown in the TitleBar pane.
    /// </summary>
    /// <returns>
    /// The element that is shown in the TitleBar pane.
    /// </returns>
    public UIElement PanelLeft
    {
        get { return (UIElement)GetValue(PanelLeftProperty); }
        set { SetValue(PanelLeftProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="PanelRight"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty PanelLeftProperty = DependencyProperty.Register(
        nameof(PanelLeft),
        typeof(UIElement),
        typeof(TitleBar),
        new PropertyMetadata(null));
    //new PropertyMetadata(null, OnPaneCustomContentPropertyChanged)
    #endregion PanelLeft

    #region PanelRight
    /// <summary>
    /// Gets or sets a UI element that is shown in the TitleBar pane.
    /// </summary>
    /// <returns>
    /// The element that is shown in the TitleBar pane.
    /// </returns>
    public UIElement PanelRight
    {
        get { return (UIElement)GetValue(PanelRightProperty); }
        set { SetValue(PanelRightProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="PanelRight"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty PanelRightProperty = DependencyProperty.Register(
        nameof(PanelRight),
        typeof(UIElement),
        typeof(TitleBar),
        new PropertyMetadata(null));
    //new PropertyMetadata(null, OnPaneCustomContentPropertyChanged)
    #endregion PaneCustomContent

    #region Body
    /// <summary>
    /// Gets or sets the content to display under the TitleBar
    /// </summary>
    /// <returns>
    /// An object that contains the control's content. The default is **null**.
    /// </returns>
    public UIElement Body
    {
        get { return (UIElement)GetValue(BodyProperty); }
        set { SetValue(BodyProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="Body"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty BodyProperty = DependencyProperty.Register(
        nameof(Body),
        typeof(UIElement),
        typeof(TitleBar),
        new PropertyMetadata(null));
    //new PropertyMetadata(null, OnBodyPropertyChanged)
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="TitleBar"/> class.
    /// </summary>
    /// <exception cref="System.Exception">
    /// TitleBar is already initialized
    /// </exception>
    public TitleBar()
    {
        if (_isInitialized)
            throw new System.Exception("TitleBar is already initialized");
        else
        {
            this.InitializeComponent();
            _isInitialized = true;
            InitializeTitleBar();
        }
    }
    #endregion Constructor

    #region private method
    private void InitializeTitleBar()
    {
        CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
        coreTitleBar.ExtendViewIntoTitleBar = true;
        Window.Current.SetTitleBar(AppTitleBar);
        coreTitleBar.LayoutMetricsChanged += (s, e) =>
        {
            RightTitleBarMarginColumn.Width = new GridLength(coreTitleBar.SystemOverlayRightInset);
            RightITitleBarMarginColumn.Width = new GridLength(coreTitleBar.SystemOverlayRightInset);
        };
        Window.Current.Activated += (s, e) =>
        {
            AppTitleBar.Opacity = e.WindowActivationState != CoreWindowActivationState.Deactivated ? 1 : 0.5;
            InterativeAppTitleBar.Opacity = e.WindowActivationState != CoreWindowActivationState.Deactivated ? 1 : 0.5;
        };
        // Set the theme of the TitleBar
        TitleBarTheme.Color(this.ActualTheme, titleBar);
        ActualThemeChanged += (s, e) =>
        {
            TitleBarTheme.Color(this.ActualTheme, titleBar);
        };
    }
    #endregion private method
}

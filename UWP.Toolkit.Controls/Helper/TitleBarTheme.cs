using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI;

namespace UWP.Toolkit.Controls.Helper;

/// <summary>
/// Sets the <see cref="ApplicationViewTitleBar"/> colors according to the theme provided.
/// <example>
/// Recommended to use in the <see cref="FrameworkElement.ActualThemeChanged"/> event of the control.
/// <code>
/// ActualThemeChanged += (sender, args) =>
/// TitleBarTheme.Color(this.ActualTheme, ApplicationView.GetForCurrentView().TitleBar);
/// </code>
/// </example>
/// </summary>
public static class TitleBarTheme
{
    /// <summary>
    /// Sets the <see cref="ApplicationViewTitleBar"/> colors according to the theme provided.
    /// </summary>
    /// <param name="theme"></param>
    /// <param name="titleBar"></param>
    public static void Color(ElementTheme theme, ApplicationViewTitleBar titleBar)
    {
        var isLightTheme = theme == ElementTheme.Light;
        // Foreground
        titleBar.ForegroundColor = isLightTheme ? TitleBarLight.ForegroundColor : TitleBarDark.ForegroundColor;
        titleBar.ButtonForegroundColor = isLightTheme ? TitleBarLight.ForegroundColor : TitleBarDark.ForegroundColor;
        titleBar.ButtonHoverForegroundColor = isLightTheme ? TitleBarLight.HoverForegroundColor : TitleBarDark.HoverForegroundColor;
        titleBar.ButtonPressedForegroundColor = isLightTheme ? TitleBarLight.PressedForegroundColor : TitleBarDark.PressedForegroundColor;
        titleBar.ButtonInactiveForegroundColor = isLightTheme ? TitleBarLight.InactiveForegroundColor : TitleBarDark.InactiveForegroundColor;
        titleBar.InactiveForegroundColor = isLightTheme ? TitleBarLight.InactiveForegroundColor : TitleBarDark.InactiveForegroundColor;

        // Background
        titleBar.BackgroundColor = Colors.Transparent;
        titleBar.ButtonBackgroundColor = Colors.Transparent;
        titleBar.InactiveBackgroundColor = Colors.Transparent;
        titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        titleBar.ButtonHoverBackgroundColor = isLightTheme ? TitleBarDark.HoverBackgroundColor : TitleBarDark.HoverBackgroundColor;
        titleBar.ButtonPressedBackgroundColor = isLightTheme ? TitleBarDark.PressedBackgroundColor : TitleBarDark.PressedBackgroundColor;
    }
}

/// <summary>
/// Sets or Gets the Colors according to the Light Theme.
/// </summary>
public static class TitleBarLight
{
    /// <summary>
    /// Sets or Gets the color of the foreground. Hex: #1A1A1A, ARGB: 255, 26, 26, 26
    /// </summary>
    public static Color ForegroundColor = Color.FromArgb(255, 26, 26, 26);
    /// <summary>
    /// Sets or Gets the color of the foreground when the pointer is over. Hex: #191919, ARGB: 255, 25, 25, 25
    /// </summary>
    public static Color HoverForegroundColor = Color.FromArgb(255, 25, 25, 25);
    /// <summary>
    /// Sets or Gets the color of the foreground when the button is pressed. Hex: #606060, ARGB: 255, 96, 96, 96
    /// </summary>
    public static Color PressedForegroundColor = Color.FromArgb(255, 96, 96, 96);
    /// <summary>
    /// Sets or Gets the color of the foreground when the window is inactive. Hex: #A0A0A0, ARGB: 255, 160, 160, 160
    /// </summary>
    public static Color InactiveForegroundColor = Color.FromArgb(255, 160, 160, 160);
    /// <summary>
    /// Sets or Gets the color of the background when the pointer is over. Hex: #DDDDDD, ARGB: 255, 221, 221, 221
    /// </summary>
    public static Color HoverBackgroundColor = Color.FromArgb(255, 221, 221, 221);
    /// <summary>
    /// Sets or Gets the color of the background when the button is pressed. Hex: #F4F4F4, ARGB: 255, 224, 224, 224
    /// </summary>
    public static Color PressedBackgroundColor = Color.FromArgb(255, 224, 224, 224);

    //public static void 
}

/// <summary>
/// Sets or Gets the Colors according to the Dark Theme.
/// </summary>
public static class TitleBarDark
{
    /// <summary>
    /// Sets or Gets the color of the foreground. Hex: #FFFFFF, ARGB: 255, 255, 255, 255
    /// </summary>
    public static Color ForegroundColor = Color.FromArgb(255, 255, 255, 255);
    /// <summary>
    /// Sets or Gets the color of the foreground when the pointer is over. Hex: #FFFFFF, ARGB: 255, 255, 255, 255
    /// </summary>
    public static Color HoverForegroundColor = Color.FromArgb(255, 255, 255, 255);
    /// <summary>
    /// Sets or Gets the color of the foreground when the button is pressed. Hex: #D0D0D0, ARGB: 255, 208, 208, 208
    /// </summary>
    public static Color PressedForegroundColor = Color.FromArgb(255, 208, 208, 208);
    /// <summary>
    /// Sets or Gets the color of the foreground when the window is inactive. Hex: #6F6F6F, ARGB: 255, 111, 111, 111
    /// </summary>
    public static Color InactiveForegroundColor = Color.FromArgb(255, 111, 111, 111);
    /// <summary>
    /// Sets or Gets the color of the background when the pointer is over. Hex: #292929, ARGB: 255, 41, 41, 41
    /// </summary>
    public static Color HoverBackgroundColor = Color.FromArgb(255, 41, 41, 41);
    /// <summary>
    /// Sets or Gets the color of the background when the button is pressed. Hex: #383838, ARGB: 255, 56, 56, 56
    /// </summary>
    public static Color PressedBackgroundColor = Color.FromArgb(255, 56, 56, 56);
}

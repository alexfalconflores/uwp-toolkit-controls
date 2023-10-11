using Microsoft.UI.Xaml.Controls;
using System;
using UWP.Markup;
using UWP.Toolkit.Controls.Interfaces;
using UWP.Toolkit.Controls.Struct;
using UWP_Toolkit.Extensions;
using Windows.System.Threading;

namespace UWP.Toolkit.Controls;

/// <summary>
/// Represents a toast item on a toast control. Not intended for general use.
/// </summary>
public sealed class ToastItem : IToastItem
{
    /// <summary>
    /// Get constant for default close after seconds.
    /// </summary>
    public const double DEFAULT_CLOSE_AFTER_SECONDS = 5;
    /// <summary>
    /// Get constant for minimum close after seconds.
    /// </summary>
    public const double MIN_CLOSE_AFTER_SECONDS = 1;
    /// <summary>
    /// Get constant for default max width.
    /// </summary>
    public const double DEFAULT_MAX_WIDTH = 400;
    /// <summary>
    /// Get constant for default Severity.
    /// </summary>
    public const InfoBarSeverity DEFAULT_SEVERITY = InfoBarSeverity.Informational;
    /// <summary>
    /// Gets or sets the close after seconds. Default is 5 seconds.
    /// </summary>
    public double CloseAfterSeconds { get; set; } = DEFAULT_CLOSE_AFTER_SECONDS;
    private readonly ThreadPoolTimer timer;
    private readonly InfoBar infoBar;

    /// <summary>
    /// Occurs after the ToastItem is closed.
    /// </summary>
    public event EventHandler Closed;

    /// <summary>
    /// Creates a new instance of the <see cref="ToastItem"/> class.
    /// </summary>
    /// <param name="parameters"></param>
    public ToastItem(ToastItemParameters parameters)
    {
        CloseAfterSeconds = CloseAfterSeconds < MIN_CLOSE_AFTER_SECONDS ? MIN_CLOSE_AFTER_SECONDS : parameters.CloseAfterSeconds;
        infoBar = new InfoBar()
                .IsOpen(true)
                .Title(parameters.Title)
                .Message(parameters.Message)
                .IsIconVisible(parameters.IsIconVisible)
                .IsClosable(parameters.IsClosable)
                .Severity(parameters.Severity)
                .IconSource(parameters.IconSource)
                .MaxWidth(parameters.MaxWidth);
        infoBar.CloseButtonClick += (sender, args) =>
        {
            infoBar.IsOpen = false;
            timer.Cancel();
            Closed?.Invoke(this, EventArgs.Empty);
        };
        if (infoBar.Severity is DEFAULT_SEVERITY)
        {
            infoBar.Background = "SystemFillColorSolidNeutralBackgroundBrush".GetSolidColorBrush();
            infoBar.ActualThemeChanged += (sender, args) =>
            {
                infoBar.Background = "SystemFillColorSolidNeutralBackgroundBrush".GetSolidColorBrush();
            };
        }
        timer = ThreadPoolTimer.CreateTimer(async (timer) =>
        {
            await infoBar.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                infoBar.IsOpen = false;
                Closed?.Invoke(this, EventArgs.Empty);
            });
        },
            TimeSpan.FromSeconds(CloseAfterSeconds));

    }

    /// <summary>
    /// Shows the toast item.
    /// </summary>
    /// <returns></returns>
    public InfoBar Show() => infoBar;
}

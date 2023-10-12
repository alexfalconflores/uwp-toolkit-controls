using Microsoft.UI.Xaml.Controls;
using UWP.Toolkit.Controls.Interfaces;

namespace UWP.Toolkit.Controls.Struct;

/// <summary>
/// Struct to hold parameters for a ToastItem
/// </summary>
public struct ToastItemParameters : IToastItemParameters
{
    /// <summary>
    /// Gets or sets the title of the toast item
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Gets or sets the message of the toast item
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// Gets or sets the severity of the toast item. Default is <see cref="InfoBarSeverity.Informational"/>.
    /// </summary>
    public InfoBarSeverity Severity { get; set; } = ToastItem.DEFAULT_SEVERITY;
    /// <summary>
    /// Gets or sets the toast item closable. Default is true.
    /// </summary>
    public bool IsClosable { get; set; } = true;
    /// <summary>
    /// Gets or sets the close after seconds. Default is 5 seconds.
    /// </summary>
    public double CloseAfterSeconds { get; set; } = ToastItem.DEFAULT_CLOSE_AFTER_SECONDS;
    /// <summary>
    /// Gets or sets the icon of the toast item. Default is true.
    /// </summary>
    public bool IsIconVisible { get; set; } = true;
    /// <summary>
    /// Gets or sets the max width of the toast item. Default is 400.
    /// </summary>
    public double MaxWidth { get; set; } = ToastItem.DEFAULT_MAX_WIDTH;
    /// <summary>
    /// Gets or Set the graphic content to appear alongsied the title and message in the toast item.
    /// </summary>
    public IconSource IconSource { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ToastItemParameters"/> struct.
    /// </summary>
    public ToastItemParameters()
    {
    }
}


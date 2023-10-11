using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP.Toolkit.Controls;

/// <summary>
/// Represents a Script that can be copied to the Clipboard.
/// </summary>
public sealed partial class Script : UserControl
{
    /// <summary>
    /// Gets or sets the text of the Symbol.
    /// </summary>
    /// <returns>
    /// A string that specifies the text of the Symbol. The default is ** $ **
    /// </returns>
    public string Symbol
    {
        get { return (string)GetValue(SymbolProperty); }
        set { SetValue(SymbolProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="Symbol"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SymbolProperty = DependencyProperty.Register(
        nameof(Symbol),
        typeof(string),
        typeof(Script),
        new PropertyMetadata("$"));

    /// <summary>
    /// Gets or sets the text of the Script.
    /// </summary>
    /// <returns>
    /// A string that specifies the text of the Script. The default is an empty string.
    /// </returns>
    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="Text"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(Script),
        new PropertyMetadata(string.Empty));

    /// <summary>
    /// Gets or sets the text of the Copy button.
    /// </summary>
    /// <returns>
    /// A string that specifies the text of the Copy button. The default is an empty string.
    /// </returns>
    public string ButtonToolTip
    {
        get { return (string)GetValue(ButtonToolTipProperty); }
        set { SetValue(ButtonToolTipProperty, value); }
    }

    /// <summary>
    /// Identifies the <see cref="ButtonToolTip"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty ButtonToolTipProperty = DependencyProperty.Register(
        nameof(ButtonToolTip),
        typeof(string),
        typeof(Script),
        new PropertyMetadata(string.Empty));

    /// <summary>
    /// Creates a new instance of the <see cref="Script"/> class.
    /// </summary>
    public Script()
    {
        this.InitializeComponent();
    }

    private void ButtonScript_Click(object sender, RoutedEventArgs e)
    {
        DataPackage package = new();
        package.SetText(Text);
        Clipboard.SetContent(package);
    }
}

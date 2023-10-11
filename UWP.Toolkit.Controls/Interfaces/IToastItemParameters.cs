using Microsoft.UI.Xaml.Controls;
using UWP.Toolkit.Controls.Struct;
using Windows.Foundation.Metadata;

namespace UWP.Toolkit.Controls.Interfaces;

[ExclusiveTo(typeof(ToastItemParameters))]
internal interface IToastItemParameters
{
    string Title { get; set; }
    string Message { get; set; }
    InfoBarSeverity Severity { get; set; }
    bool IsClosable { get; set; }
    double CloseAfterSeconds { get; set; }
    bool IsIconVisible { get; set; }
    double MaxWidth { get; set; }
    IconSource IconSource { get; set; }
}

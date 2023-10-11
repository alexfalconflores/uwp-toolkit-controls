using UWP.Toolkit.Controls.Enum;
using UWP.Toolkit.Controls.Struct;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;

namespace UWP.Toolkit.Controls.Interfaces;

[ExclusiveTo(typeof(Toast))]
internal interface IToast
{
    void Show(ToastItemParameters toastItemParameters);
    void SetAlignment(ToastAlignment toastAlignment);
    void SetTitleBarHeight(TitleBarSize titleBarSize);
    void SetPadding(Thickness padding);
    void SetPadding(double padding);
    void SetPadding(double left, double top, double right, double bottom);
    int Count();
}

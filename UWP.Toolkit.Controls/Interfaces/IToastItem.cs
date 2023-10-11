using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Foundation.Metadata;

namespace UWP.Toolkit.Controls.Interfaces;

[ExclusiveTo(typeof(ToastItem))]
internal interface IToastItem
{
    public double CloseAfterSeconds { get; set; }
    public event EventHandler Closed;
    InfoBar Show();
}

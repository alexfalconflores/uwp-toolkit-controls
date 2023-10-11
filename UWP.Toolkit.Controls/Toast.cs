using System;
using UWP.Toolkit.Controls.Enum;
using UWP.Toolkit.Controls.Interfaces;
using UWP.Toolkit.Controls.Struct;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;

using UWP.Markup;
using UWP.Markup.Transition;
using UWP_Toolkit.Extensions;

namespace UWP.Toolkit.Controls;

/// <summary>
/// Represents a Toast that can be shown.
/// </summary>
public sealed class Toast : IToast
{
    private static readonly Lazy<Toast> lazy = new(() => new Toast());
    /// <summary>
    /// Gets the instance of the Toast.
    /// </summary>
    public static Toast Instance => lazy.Value;
    private readonly Popup popup;
    private readonly Grid overlay;
    private readonly StackPanel toastContainer;
    private static bool isAlignmentChanged = false;
    private static bool isTitleBarHeightChanged = false;
    private static double titleBarHeight = TitleBarSize.Short.ToDouble();
    private static bool isPaddingChanged = false;

    private Toast()
    {
        TransitionCollection popupTransitionCollection = new TransitionCollection()
            .AddTransition(new PopupThemeTransition());
        popup = new Popup()
          .IsLightDismissEnabled(false)
          .ShouldConstrainToRootBounds(true)
          .VerticalOffset(titleBarHeight)
          .ChildTransitions(popupTransitionCollection);
        overlay = new Grid()
            .Padding(10);
        overlay.EffectiveViewportChanged += Overlay_EffectiveViewportChanged;
        popup.Child = overlay;
        TransitionCollection toastContainerTransitionCollection = new TransitionCollection()
           .AddTransition(new EntranceThemeTransition().IsStaggeringEnabled(true));
        toastContainer = new StackPanel()
        .ChildrenTransitions(toastContainerTransitionCollection)
        .Alignment(VerticalAlignment.Bottom, HorizontalAlignment.Right);
        overlay.AddChild(toastContainer);
        popup.IsOpen(true);
    }

    private void Overlay_EffectiveViewportChanged(FrameworkElement sender, EffectiveViewportChangedEventArgs args)
    {
        overlay.Width = args.EffectiveViewport.Width;
        overlay.Height = args.EffectiveViewport.Height - titleBarHeight;
    }

    private (VerticalAlignment, HorizontalAlignment) GetAlignment(ToastAlignment toastAlignment) => toastAlignment switch
    {
        ToastAlignment.TopLeft => (VerticalAlignment.Top, HorizontalAlignment.Left),
        ToastAlignment.TopCenter => (VerticalAlignment.Top, HorizontalAlignment.Center),
        ToastAlignment.TopRight => (VerticalAlignment.Top, HorizontalAlignment.Right),
        ToastAlignment.BottomLeft => (VerticalAlignment.Bottom, HorizontalAlignment.Left),
        ToastAlignment.BottomCenter => (VerticalAlignment.Bottom, HorizontalAlignment.Center),
        ToastAlignment.BottomRight => (VerticalAlignment.Bottom, HorizontalAlignment.Right),
        _ => (VerticalAlignment.Bottom, HorizontalAlignment.Right),
    };

    /// <summary>
    /// Gets the number of Toasts in the ToastContainer.
    /// </summary>
    /// <returns></returns>
    public int Count() => toastContainer.Children.Count;

    /// <summary>
    /// Sets the alignment of the ToastContainer. This method can be called only once.
    /// </summary>
    /// <param name="toastAlignment"></param>
    public void SetAlignment(ToastAlignment toastAlignment)
    {
        if (isAlignmentChanged is false)
        {
            isAlignmentChanged = true;
            toastContainer.Alignment(GetAlignment(toastAlignment));
        }
    }

    /// <summary>
    /// Sets the padding of the ToastContainer. This method can be called only once.
    /// </summary>
    /// <param name="padding"></param>
    public void SetPadding(Thickness padding)
    {
        if (isPaddingChanged is false)
        {
            isPaddingChanged = true;
            overlay.Padding(padding);
        }
    }

    /// <summary>
    /// Sets the padding of the ToastContainer. This method can be called only once.
    /// </summary>
    /// <param name="padding"></param>
    public void SetPadding(double padding)
    {
        if (isPaddingChanged is false)
        {
            isPaddingChanged = true;
            overlay.Padding(padding);
        }
    }

    /// <summary>
    /// Sets the padding of the ToastContainer. This method can be called only once.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="top"></param>
    /// <param name="right"></param>
    /// <param name="bottom"></param>
    public void SetPadding(double left, double top, double right, double bottom)
    {
        if (isPaddingChanged is false)
        {
            isPaddingChanged = true;
            overlay.Padding(left, top, right, bottom);
        }
    }

    /// <summary>
    /// Sets the TitleBar height, so that the ToastContainer does not overlap with the TitleBar. This method can be called only once.
    /// </summary>
    /// <param name="titleBarSize"></param>
    public void SetTitleBarHeight(TitleBarSize titleBarSize)
    {
        if (isTitleBarHeightChanged is false)
        {
            isTitleBarHeightChanged = true;
            titleBarHeight = titleBarSize.ToDouble();
            popup.VerticalOffset(titleBarHeight);
            overlay.EffectiveViewportChanged -= Overlay_EffectiveViewportChanged;
            overlay.EffectiveViewportChanged += Overlay_EffectiveViewportChanged;
        }
    }

    /// <summary>
    /// Shows a Toast. This method can be called multiple times.
    /// </summary>
    /// <param name="toastItemParameters"></param>
    public void Show(ToastItemParameters toastItemParameters)
    {
        if (popup.IsOpen is false) popup.IsOpen(true);
        ToastItem toastItem = new(toastItemParameters);
        toastItem.Closed += (sender, args) =>
        {
            toastContainer.Children.Remove(toastItem.Show());
            popup.IsOpen(toastContainer.Children.Count > 0);
        };
        toastContainer.AddChild(toastItem.Show());
    }
}

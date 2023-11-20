using System;
using UWP.Markup;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace UWP.Toolkit.Controls;
public static class PreviewPopupMarkup
{
    public static PreviewPopup IsLightDismissEnabled(this PreviewPopup element, bool isEnabled)
    {
        element.IsLightDismissEnabled = isEnabled;
        return element;
    }

    public static PreviewPopup OverlayStyle(this PreviewPopup element, Style style)
    {
        element.OverlayStyle = style;
        return element;
    }

    public static PreviewPopup Padding(this PreviewPopup element, Thickness padding)
    {
        element.Padding = padding;
        return element;
    }

    public static PreviewPopup Padding(this PreviewPopup element, double uniformLength)
    {
        element.Padding = new Thickness(uniformLength);
        return element;
    }

    public static PreviewPopup Padding(this PreviewPopup element, double horizontalLength, double verticalLength)
    {
        element.Padding = new Thickness(horizontalLength, verticalLength, horizontalLength, verticalLength);
        return element;
    }

    public static PreviewPopup Padding(this PreviewPopup element, double left, double top, double right, double bottom)
    {
        element.Padding = new Thickness(left, top, right, bottom);
        return element;
    }

    public static PreviewPopup Background(this PreviewPopup element, Brush brush)
    {
        element.Background = brush;
        return element;
    }

    public static PreviewPopup Background(this PreviewPopup element, Color color)
    {
        element.Background = new SolidColorBrush(color);
        return element;
    }

    public static PreviewPopup CloseButtonStyle(this PreviewPopup element, Style style)
    {
        element.CloseButtonStyle = style;
        return element;
    }

    public static PreviewPopup CloseButtonToolTip(this PreviewPopup element, string tooltip)
    {
        element.CloseButtonToolTip = tooltip;
        return element;
    }

    public static PreviewPopup IsCloseButtonVisible(this PreviewPopup element, Visibility visibility)
    {
        element.IsCloseButtonVisible = visibility;
        return element;
    }

    public static PreviewPopup Content(this PreviewPopup element, UIElement content)
    {
        element.Content = content;
        return element;
    }

    public static PreviewPopup ContentStyle(this PreviewPopup element, Style style)
    {
        element.ContentStyle = style;
        return element;
    }

    public static PreviewPopup ContentCornerRadius(this PreviewPopup element, CornerRadius cornerRadius)
    {
        element.ContentCornerRadius = cornerRadius;
        return element;
    }

    public static PreviewPopup ContentCornerRadius(this PreviewPopup element, double uniformRadius)
    {
        element.ContentCornerRadius = new CornerRadius(uniformRadius);
        return element;
    }

    public static PreviewPopup ContentCornerRadius(this PreviewPopup element, double topLeftRight, double bottomLeftRight)
    {
        element.ContentCornerRadius = new CornerRadius(topLeftRight, topLeftRight, bottomLeftRight, bottomLeftRight);
        return element;
    }

    public static PreviewPopup ContentCornerRadius(this PreviewPopup element, double topLeft, double topRight, double bottomRight, double bottomLeft)
    {
        element.ContentCornerRadius = new CornerRadius(topLeft, topRight, bottomRight, bottomLeft);
        return element;
    }

    public static PreviewPopup ContentPadding(this PreviewPopup element, Thickness padding)
    {
        element.ContentPadding = padding;
        return element;
    }

    public static PreviewPopup ContentPadding(this PreviewPopup element, double uniformLength)
    {
        element.ContentPadding = new Thickness(uniformLength);
        return element;
    }

    public static PreviewPopup ContentPadding(this PreviewPopup element, double horizontalLength, double verticalLength)
    {
        element.ContentPadding = new Thickness(horizontalLength, verticalLength, horizontalLength, verticalLength);
        return element;
    }

    public static PreviewPopup ContentPadding(this PreviewPopup element, double left, double top, double right, double bottom)
    {
        element.ContentPadding = new Thickness(left, top, right, bottom);
        return element;
    }

    public static PreviewPopup ContentBackground(this PreviewPopup element, Brush brush)
    {
        element.ContentBackground = brush;
        return element;
    }

    public static PreviewPopup ContentBorderThickness(this PreviewPopup element, Thickness thickness)
    {
        element.ContentBorderThickness = thickness;
        return element;
    }

    public static PreviewPopup ContentBorderThickness(this PreviewPopup element, double uniformLength)
    {
        element.ContentBorderThickness = new Thickness(uniformLength);
        return element;
    }

    public static PreviewPopup ContentBorderBrush(this PreviewPopup element, Brush brush)
    {
        element.ContentBorderBrush = brush;
        return element;
    }

    public static PreviewPopup ContentBorderBrush(this PreviewPopup element, Color color)
    {
        element.ContentBorderBrush = new SolidColorBrush(color);
        return element;
    }


    // GRID ------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Check if the property of the class is null, if it is null, nothing is done.
    /// <code>
    /// public class CustomControl {
    ///     public Brush CustomControlBackground { get; set; }
    ///     ...
    ///     public void Show(){
    ///         var grid = new Grid().BackgroundProperty(CustomControlBackground);
    ///         ....
    ///     }
    /// }
    /// </code>
    /// </summary>
    /// <param name="element"></param>
    /// <param name="property"></param>
    /// <returns>
    /// The <see cref="Grid"/> with the property set if the property is not null, otherwise the <see cref="Grid"/> without the property set.
    /// </returns>
    public static Grid BackgroundProperty(this Grid element, Brush property)
    {
        if (property is not null) element.Background = property;
        return element;
    }

    /// <summary>
    /// Check if the property of the class is null, if it is null, nothing is done.
    /// <code>
    /// public class CustomControl {
    ///     public Thickness? CustomControlPadding { get; set; }
    ///     ...
    ///     public void Show(){
    ///         var grid = new Grid().PaddingProperty(CustomControlPadding);
    ///         ...
    ///     }
    /// }
    /// </code>
    /// </summary>
    /// <param name="element"></param>
    /// <param name="property"></param>
    /// <returns>
    /// The <see cref="Grid"/> with the property set if the property is not null, otherwise the <see cref="Grid"/> without the property set.
    /// </returns>
    public static Grid PaddingProperty(this Grid element, Thickness? property)
    {
        if (property is not null) element.Padding = (Thickness)property;
        return element;
    }

    /// <summary>
    /// Check if the property of the class is null, if it is null, nothing is done.
    /// <code>
    /// public class CustomControl {
    ///     public Thickness? CustomControlBorderThickness { get; set; }
    ///     ...
    ///     public void Show(){
    ///         var grid = new Grid().BorderThicknessProperty(CustomControlPadding);
    ///         ...
    ///     }
    /// }
    /// </code>
    /// </summary>
    /// <param name="element"></param>
    /// <param name="property"></param>
    /// <returns>
    /// The <see cref="Grid"/> with the property set if the property is not null, otherwise the <see cref="Grid"/> without the property set.
    /// </returns>
    public static Grid BorderThicknessProperty(this Grid element, Thickness? property)
    {
        if (property is not null) element.BorderThickness = (Thickness)property;
        return element;
    }

    /// <summary>
    /// Check if the property of the class is null, if it is null, nothing is done.
    /// <code>
    /// public class CustomControl {
    ///     public Brush CustomControlBorderBrush { get; set; }
    ///     ...
    ///     public void Show(){
    ///         var grid = new Grid().BorderBrushProperty(CustomControlBorderBrush);
    ///         ...
    ///     }
    /// }
    /// </code>
    /// </summary>
    /// <param name="element"></param>
    /// <param name="property"></param>
    /// <returns>
    /// The <see cref="Grid"/> with the property set if the property is not null, otherwise the <see cref="Grid"/> without the property set.
    /// </returns>
    public static Grid BorderBrushProperty(this Grid element, Brush property)
    {
        if (property is not null) element.BorderBrush = property;
        return element;
    }

    /// <summary>
    /// Check if the property of the class is null, if it is null, nothing is done.
    /// <code>
    /// public class CustomControl {
    ///     public CornerRadius? CustomControlCornerRadius { get; set; }
    ///     ...
    ///     public void Show(){
    ///         var grid = new Grid().CornerRadiusProperty(CustomControlCornerRadius);
    ///         ...
    ///     }
    /// }
    /// </code>
    /// </summary>
    /// <param name="element"></param>
    /// <param name="property"></param>
    /// <returns>
    /// The <see cref="Grid"/> with the property set if the property is not null, otherwise the <see cref="Grid"/> without the property set.
    /// </returns>
    public static Grid CornerRadiusProperty(this Grid element, CornerRadius? property)
    {
        if (property is not null) element.CornerRadius = (CornerRadius)property;
        return element;
    }

    /// <summary>
    /// Defines the full width of the <see cref="Grid"/> when called in a <see cref="Popup"/> subtracting the offset.
    /// The offset is 0 by default.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static Grid WidthEffectiveViewport(this Grid element, double offset = 0)
    {
        element.EffectiveViewportChanged += (sender, args) =>
            element.Width = args.EffectiveViewport.Width - offset;
        return element;
    }

    /// <summary>
    /// Defines the full height of the <see cref="Grid"/> when called in a <see cref="Popup"/> subtracting the offset.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static Grid HeightEffectiveViewport(this Grid element, double offset = 0)
    {
        element.EffectiveViewportChanged += (sender, args) =>
            element.Height = args.EffectiveViewport.Height - offset;
        return element;
    }

    /// <summary>
    /// Defines the full size of the <see cref="Grid"/> when called in a <see cref="Popup"/> subtracting the offset.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="verticalOffset"></param>
    /// <param name="horizontalOffset"></param>
    /// <returns></returns>
    public static Grid EffectiveViewport(this Grid element, double verticalOffset = 0, double horizontalOffset = 0)
    {
        element.EffectiveViewportChanged += (sender, args) =>
        {
            element.Width = args.EffectiveViewport.Width - horizontalOffset;
            element.Height = args.EffectiveViewport.Height - verticalOffset;
        };
        return element;
    }

    // BUTTONBASE

    /// <summary>
    /// Occurs when a button control is clicked.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="element"></param>
    /// <param name="parent"></param>
    /// <returns>The <see cref="ButtonBase"/> instance for method chaining.</returns>
    public static T OnClick<T>(this T element, Action<object, RoutedEventArgs> handler) where T : ButtonBase
    {
        element.Click += (sender, args) => handler(sender, args);
        return element;
    }

    /// <summary>
    /// Occurs when a button control is clicked.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="element"></param>
    /// <param name="parent"></param>
    /// <returns>The <see cref="ButtonBase"/> instance for method chaining.</returns>
    public static T OnClick<T>(this T element, Action handler) where T : ButtonBase
    {
        element.Click += (sender, args) => handler();
        return element;
    }

    // UIELEMENT -------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Assign which parent the control will belong to.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="element"></param>
    /// <param name="parent"></param>
    /// <returns>The <see cref="UIElement"/> instance for method chaining.</returns>
    public static T Parent<T>(this T element, Panel parent) where T : UIElement
    {
        parent.AddChild(element);
        return element;
    }

    /// <summary>
    /// Assign which parent the control will belong to.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="element"></param>
    /// <param name="parent"></param>
    /// <returns>The <see cref="UIElement"/> instance for method chaining.</returns>
    public static T Parent<T>(this T element, Popup parent) where T : UIElement
    {
        parent.Child = element;
        return element;
    }

    /// <summary>
    /// Occurs when the pointer device initiates a **Press** action within this element.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="element"></param>
    /// <param name="handler"></param>
    /// <returns>The <see cref="UIElement"/> instance for method chaining.</returns>
    public static T OnPointerPressed<T>(this T element, Action<object, PointerRoutedEventArgs> handler) where T : UIElement
    {
        element.PointerPressed += (sender, args) => handler(sender, args);
        return element;
    }

    /// <summary>
    /// Occurs when the pointer device initiates a **Press** action within this element.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="element"></param>
    /// <param name="handler"></param>
    /// <returns>The <see cref="UIElement"/> instance for method chaining.</returns>
    public static T OnPointerPressed<T>(this T element, Action handler) where T : UIElement
    {
        element.PointerPressed += (sender, args) => handler();
        return element;
    }
}

# ContentOverlayPopup
Represents a `full-screen popup` with content overlay functionality, typically used for displaying content that should cover the entire screen while respecting the `TitleBar height`.
> use:
> ```csharp
> using UWP.Toolkit.Controls;
> ContentOverlayPopup contentOverlayPopup = new ContentOverlayPopup()
>    .TitleBarHeight(TitleBarSize.Tall)
>    .TitleContent(titleContent)
>    .CloseButtonToolTip("Close")
>    .Background("AccentAcrylicBackgroundFillColorDefaultBrush") // example
>    .IsCloseButtonVisible(Visibility.Visible)
>    .IsLightDismissEnabled(false)
>    .BodyContent(bodyContent);
> contentOverlayPopup.Show();
> ```

[Markup](ContentOverlayPopupMarkup.md)

## Properties
### TitleBarHeight
Gets or sets the `height` of the TitleBar in the `overlay`. The default value is `TitleBarSize.Short`.

### TitleContent
Gets or sets the `content` to be displayed in the `overlay's title area`. The default value is `null`.

### CloseButtonToolTip
Gets or sets the `toolTip` to be displayed on the overlay's `close button`. The default value is an `string.Empty`.

### IsCloseButtonVisible
Gets or sets the `visibility` of the overlay's `close button`. The default value is `Visibility.Visible`.

### BodyContent
Gets or sets the `content` to be displayed in the overlay's `body area`. The default value is `null`.

### IsOpen
Gets a value that indicates whether the `ContentOverlayPopup` is open. The default value is `false`.

### IsLightDismissEnabled
Gets or sets a value that indicates whether the `ContentOverlayPopup` can be `dismissed` by clicking in the `light-dismiss region` or by pressing the `ESC key`. The default value is `false`.

### ColumnSpacing
Gets or sets the `spacing` between the `overlay's columns`. If the `close button` is `visible`, the spacing is applied to the right of the title content. The default value is `8`.

### RowSpacing
Gets or sets the `spacing` between the `overlay's rows`. The default value is `8`.

### Padding
Gets or sets the `padding` inside the control. The default value is `40,30,40,20`.

### Background
Gets or sets the background color resources name of the control. The default value is `"AcrylicInAppFillColorDefaultBrush"`.
> Only support `AcrylicBrush` Resource. 

## Methods
### Hide
Hides the `ContentOverlayPopup`.

### Show
Displays the `ContentOverlayPopup`, covering the entire screen while respecting the `TitleBar height`.


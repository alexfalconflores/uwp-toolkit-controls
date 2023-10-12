# TitleBar
![Alt text](on-app.png)

> use:
> ```xaml
> xmlns:utControls="using:UWP_Toolkit.Controls"
> ```

## Properties

### Size
Gets or sets the `size` of the TitleBar.
- Returns: A value of the `enumeration`. The default is `Short`.

### TitleBarBackground
Gets or sets a `brush` that provides the `background` of the TitleBar.
- Returns: The `brush` that provides the `background` of the TitleBar. The default is `Transparent`.

### AppIconSource
Gets or sets the `source` for the App Icon on the TitleBar.
- Returns: An `object` that represents the `image` source file for the drawn image. Typically you set this with a `BitmapImage object`. Constructed with a the `Uniform Resource Identifier (URI)` that describes the path to a valid image source file. Or, you can initialize a `BitmapSource` with a `stream`, perhaps a `stream` from a `storage file`.
  
### IsAppIconVisible
Gets or sets the `visibility` of the App Icon on the TitleBar.
- Returns: A value of the enumeration. The default is `Visible`.
  
### AppName
Gets or sets the `text` of the App Name.
- Returns: A `string` that specifies the text of the App Name. The default is an `empty string`.

### IsAppNameVisible
Gets or sets the `visibility` of the App Name on the TitleBar.
- Returns: A value of the enumeration. The default is `Visible`.

### ReleaseTag
Gets or sets Gets or sets the `text` of the Release Tag.
- Returns: A string that specifies the text  of the Release Tag. The default is an empty string.

### IsReleaseTagVisible
Gets or sets the `visibility` of the Release Tag on the TitleBar.
- Returns: A value of the enumeration. The default is `Visible`.


### BackButtonCommand
Gets or sets the command to invoke when this back button is pressed.
- Returns: The command to invoke when this back button is pressed. The default is `null`.

### BackButtonCommandParameter
Gets or sets the `parameter` to pass to the `BackButtonCommand` property.
-  Returns: The parameter to pass to the `BackButtonCommand` property. The default is `null`.

### IsBackButtonVisible
Gets or sets the visibility of the back button.
- Returns: A value of the `enumeration`. The default is `Collapsed`.

### IsBackButtonEnabled
Gets or sets a value indicating whether the user can interact with the back button.
- Returns: `true` if the user can interact with the back button otherwise `false`. The default is `true`.

### Search
Gets or sets an `AutoSuggestBox` to be displayed in the TitleBar.
- Returns:  An `AutoSuggestBox` to be displayed in the TitleBar.

### PaneCustomContent
Gets or sets a `UI element` that is shown in the TitleBar pane.
- Returns: The `element` that is shown in the TitleBar pane.

### Body
Gets or sets the content to display under the TitleBar.
-  Returns: An `object` that contains the control's content. The default is `null`.
# Toast
Represents a `Toast` that can be shown. This class is a `singleton` class.
![Alt text](<Screenshot 2023-10-12 025109.png>)
> use:
> ```csharp
> using UWP.Toolkit.Controls;
>
> Toast toast = Toast.Instance;
> toast.SetTitleBarHeight(TitleBarSize.Tall);
> toast.SetAlignment(ToastAlignment.TopLeft);
> toast.Show(toastItemParameters);
> ```

## Properties
### Instance
Gets the `instance` of the `Toast`.

## Methods
### Count
Gets the `number` of `Toasts` in the `ToastContainer`.

### SetAlignment (ToastAlignment toastAlignment)
Sets the `alignment` of the `ToastContainer`. This method can be called `only once`. The default value is `ToastAlignment.BottomRight`.

### SetPadding (Thickness padding)
Sets the `padding` of the `ToastContainer`. This method can be called `only once`. The default value is `10`.

### SetPadding (double padding)
Sets the `padding` of the `ToastContainer`. This method can be called `only once`. The default value is `10`.

### SetPadding (double left, double top, double right, double bottom)
Sets the `padding` of the `ToastContainer`. This method can be called `only once`. The default value is `10`.

### SetTitleBarHeight (TitleBarSize titleBarSize)
Sets the `TitleBar height`, so that the `ToastContainer` does not overlap with the `TitleBar`. This method can be called `only once`. The default value is `TitleBarSize.Short`.

### Show (ToastItemParameters toastItemParameters)
`Shows` a `Toast`. This method can be called multiple times.
# Struct
## ToastItemParameters
Struct to hold `parameters` for a `ToastItem`.

> use:
> ```csharp
> using UWP.Toolkit.Controls.Struct;
>ToastItemParameters toastItemParameters1 = new ToastItemParameters
>{
>    Title = "Title 1",
>    .....
>};
> ```

### Properties
#### Title
Gets or sets the title of the toast item.
#### Message
Gets or sets the message of the toast item.
#### Severity
Gets or sets the severity of the toast item. Default is `InfoBarSeverity.Informational`.
#### IsClosable
Gets or sets the toast item closable. Default is `true`.
#### CloseAfterSeconds
Gets or sets the close after seconds. Default is `5 seconds`.
#### IsIconVisible
Gets or sets the icon of the toast item. Default is `true`.
#### MaxWidth
Gets or sets the max width of the toast item. Default is `400`.
#### IconSource
Gets or Set the graphic content to appear alongsied the title and message in the toast item.
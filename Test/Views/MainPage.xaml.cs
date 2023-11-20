using System;

using Test.ViewModels;
using UWP.Markup;
using UWP.Toolkit.Controls;
using UWP_Toolkit.Extensions;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Test.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            TextBlock texto = new TextBlock().Text("PreviewPopup");
            PreviewPopup popup = new PreviewPopup()
                .Content(new TextBlock().Text("Texto dentro del contenido"))
                .ContentPadding(10);

            popup.Show();
        }
    }
}

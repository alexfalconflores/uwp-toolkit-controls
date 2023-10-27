using System;

using Test.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Test.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}

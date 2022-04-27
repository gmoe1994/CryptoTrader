using CommunityToolkit.Mvvm.DependencyInjection;

using CryptoTrader.App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CryptoTrader.App.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; }

        public HomePage()
        {
            ViewModel = Ioc.Default.GetService<HomeViewModel>();
            InitializeComponent();
        }
    }
}

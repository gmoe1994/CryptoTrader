using CommunityToolkit.Mvvm.DependencyInjection;

using CryptoTrader.App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CryptoTrader.App.Views
{
    public sealed partial class MarketPage : Page
    {
        public MarketViewModel ViewModel { get; }

        public MarketPage()
        {
            ViewModel = Ioc.Default.GetService<MarketViewModel>();
            InitializeComponent();
        }


    }
}

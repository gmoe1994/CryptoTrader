using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using CryptoTrader.App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CryptoTrader.App.Views
{
    public sealed partial class PortfolioPage : Page
    {
        public PortfolioViewModel ViewModel { get; }

        public PortfolioPage()
        {
            ViewModel = Ioc.Default.GetService<PortfolioViewModel>();
            InitializeComponent();
        }

        private void OnViewStateChanged(object sender, ListDetailsViewState e)
        {

        }
    }
}

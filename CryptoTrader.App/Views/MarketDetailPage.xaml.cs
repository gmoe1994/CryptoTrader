using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Animations;

using CryptoTrader.App.Contracts.Services;
using CryptoTrader.App.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace CryptoTrader.App.Views
{
    public sealed partial class MarketDetailPage : Page
    {
        public MarketDetailViewModel ViewModel { get; }

        public MarketDetailPage()
        {
            ViewModel = Ioc.Default.GetService<MarketDetailViewModel>();
            InitializeComponent();
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);
        //    //this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
        //}

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                INavigationService navigationService = Ioc.Default.GetService<INavigationService>();
                navigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}

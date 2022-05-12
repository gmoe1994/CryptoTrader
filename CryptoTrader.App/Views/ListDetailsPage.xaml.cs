using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using CryptoTrader.App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CryptoTrader.App.Views
{
    public sealed partial class ListDetailsPage : Page
    {
        public ListDetailsViewModel ViewModel { get; }

        public ListDetailsPage()
        {
            ViewModel = Ioc.Default.GetService<ListDetailsViewModel>();
            InitializeComponent();
        }

        private void OnViewStateChanged(object sender, ListDetailsViewState e)
        {
            
        }
    }
}

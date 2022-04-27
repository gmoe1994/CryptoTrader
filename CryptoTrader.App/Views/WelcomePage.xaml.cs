using CommunityToolkit.Mvvm.DependencyInjection;

using CryptoTrader.App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CryptoTrader.App.Views
{
    public sealed partial class WelcomePage : Page
    {
        public WelcomeViewModel ViewModel { get; }

        public WelcomePage()
        {
            ViewModel = Ioc.Default.GetService<WelcomeViewModel>();
            InitializeComponent();
        }
    }
}

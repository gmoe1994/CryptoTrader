using CommunityToolkit.Mvvm.DependencyInjection;

using CryptoTrader.App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CryptoTrader.App.Views
{
    // TODO WTS: Change the URL for your privacy policy, currently set to https://YourPrivacyUrlGoesHere
    public sealed partial class SettingsPage : Page
    {
        public SettingsViewModel ViewModel { get; }

        public SettingsPage()
        {
            ViewModel = Ioc.Default.GetService<SettingsViewModel>();
            InitializeComponent();
        }
    }
}

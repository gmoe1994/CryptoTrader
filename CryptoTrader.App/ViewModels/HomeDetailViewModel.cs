using System;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using CryptoTrader.App.Contracts.ViewModels;
using CryptoTrader.App.Core.Contracts.Services;
using CryptoTrader.App.Core.Models;

namespace CryptoTrader.App.ViewModels
{
    public class HomeDetailViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IExternalApiService _externalApiService;
        private CryptoDto _item;

        public CryptoDto Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public HomeDetailViewModel(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is string cryptoID)
            {
                var data = await _externalApiService.GetCryptoDtosAsync();
                Item = data.First(i => i.Id == cryptoID);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}

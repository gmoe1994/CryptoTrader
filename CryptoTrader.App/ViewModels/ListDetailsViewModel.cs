using System;
using System.Collections.ObjectModel;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using CryptoTrader.App.Contracts.ViewModels;
using CryptoTrader.App.Core.Contracts.Services;
using CryptoTrader.App.Core.Models;

namespace CryptoTrader.App.ViewModels
{
    public class ListDetailsViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IExternalApiService _externalApiService;
        private ObservableCollection<CryptoDto> _items = new();

        public ObservableCollection<CryptoDto> Items
        {
            get { return _items; }
        }
        private CryptoDto _selected;

        public CryptoDto Selected
        {
            get => _selected;
            set => SetProperty(ref _selected, value);
        }

        public ListDetailsViewModel(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async void OnNavigatedTo(object parameter)
        {

            var data = await _externalApiService.GetCryptoDtosAsync();
            foreach (var item in data)
            {
                Items.Add(item);
            }

        }


        public void OnNavigatedFrom()
        {
        }
    }
}

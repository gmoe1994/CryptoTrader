﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoTrader.App.Contracts.Services;
using CryptoTrader.App.Contracts.ViewModels;
using CryptoTrader.App.Core.Contracts.Services;
using CryptoTrader.App.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CryptoTrader.App.ViewModels
{
    public class MarketViewModel : ObservableRecipient, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly ICryptoService _externalApiService;
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<CryptoDto>(OnItemClick));


        public MarketViewModel(INavigationService navigationService, ICryptoService externalApiService)
        {
            _navigationService = navigationService;
            _externalApiService = externalApiService;
        }


        public ObservableCollection<CryptoDto> Coins { get; set; } = new ObservableCollection<CryptoDto>();

        public async void OnNavigatedTo(object parameter)
        {

            var cryptoDtos = await _externalApiService.GetCryptoDtosAsync();

            foreach (var cryptoDto in cryptoDtos)
            {
                Coins.Add(cryptoDto);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnItemClick(CryptoDto clickedItem)
        {
            if (clickedItem != null)
            {
                _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
                _navigationService.NavigateTo(typeof(MarketDetailViewModel).FullName, clickedItem.Id);
            }
        }
    }
}


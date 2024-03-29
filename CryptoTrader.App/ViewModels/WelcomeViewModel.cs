﻿using CommunityToolkit.Mvvm.ComponentModel;
using CryptoTrader.App.Contracts.ViewModels;
using CryptoTrader.App.Core.Models;
using CryptoTrader.App.Core.Services;
using System.Collections.ObjectModel;

namespace CryptoTrader.App.ViewModels
{
    public class WelcomeViewModel : ObservableRecipient, INavigationAware
    {
        public WelcomeViewModel()
        {

        }

        private readonly CryptoService service = new CryptoService();

        public ObservableCollection<CryptoDto> Coins { get; set; } = new ObservableCollection<CryptoDto>();

        public async void OnNavigatedTo(object parameter)
        {

            var cryptoDtos = await service.GetCryptoDtosAsync();

            foreach (var cryptoDto in cryptoDtos)
            {
                Coins.Add(cryptoDto);
            }

        }

        public void OnNavigatedFrom()
        {
            // throw new NotImplementedException();
        }

    }
}

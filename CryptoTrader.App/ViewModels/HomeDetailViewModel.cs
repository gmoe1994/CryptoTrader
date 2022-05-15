using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ABI.Microsoft.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoTrader.App.Contracts.ViewModels;
using CryptoTrader.App.Core.Contracts.Services;
using CryptoTrader.App.Core.Models;
using CryptoTrader.App.Services;
using Microsoft.UI.Xaml.Controls;
using ContentDialog = Microsoft.UI.Xaml.Controls.ContentDialog;

namespace CryptoTrader.App.ViewModels
{
    public class HomeDetailViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ICryptoService _cryptoService;
        private CryptoDto _item;

        public CryptoDto Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }


        public HomeDetailViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(async () =>
                    {
                        var toBuy = await _cryptoService.GetCryptoAsync(Item.Id);
                        if (toBuy.Id == Item.Id)
                        {
                            toBuy.Quantity++;
                            _cryptoService.UpdateCryptoAsync(toBuy);
                        }
                        else
                        {
                            Item.Quantity = 1;
                            var cryptoDto = await _cryptoService.CreateCryptoAsync(Item);
                        }
                    });
                }
                return _addCommand;
            }
        }

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is string cryptoID)
            {
                var data = await _cryptoService.GetCryptoDtosAsync();

                Item = data.First(i => i.Id == cryptoID);
            }
        }

        public void OnNavigatedFrom()
        {
        }


    }
}

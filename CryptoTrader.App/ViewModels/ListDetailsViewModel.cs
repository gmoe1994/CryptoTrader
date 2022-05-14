using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoTrader.App.Contracts.Services;
using CryptoTrader.App.Contracts.ViewModels;
using CryptoTrader.App.Core.Contracts.Services;
using CryptoTrader.App.Core.Models;
using CryptoTrader.App.Services;
using Microsoft.UI.Xaml.Controls;

namespace CryptoTrader.App.ViewModels
{
    public class ListDetailsViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ICryptoService _cryptoService;
        private readonly INavigationService _navigationService;
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

        public ListDetailsViewModel(ICryptoService cryptoService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _cryptoService = cryptoService;
        }

        public async void OnNavigatedTo(object parameter)
        {

            var data = await _cryptoService.GetCryptosAsync();
            foreach (var item in data)
            {
                Items.Add(item);
            }

        }

        //private ICommand _addCommand;
        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        if (_addCommand == null)
        //        {
        //            _addCommand = new RelayCommand(async () =>
        //            {
        //                Selected.Quantity = 1;
        //                var cryptoDto = await _cryptoService.CreateCryptoAsync(Selected);
        //            });
        //        }
        //        return _addCommand;
        //    }
        //}

        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(() =>
                    {
                        Selected.Quantity += 1;
                        _cryptoService.UpdateCryptoAsync(Selected);
                    });
                }
                return _updateCommand;
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand<CryptoDto>(async param =>
                    {
                        if (await _cryptoService.DeleteCryptoAsync(param))
                        {
                            _ = Items.Remove(param);
                        }
                    }, param => param != null);
                }

                return _deleteCommand;
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}

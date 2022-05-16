using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        public bool IsCryptoSelected => Selected != null;

        public ListDetailsViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            var data = await _cryptoService.GetCryptosAsync();
            foreach (var item in data)
            {
                item.Value = item.Quantity * item.Price;
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

        private ICommand _buyCommand;
        public ICommand BuyCommand
        {
            get
            {
                if (_buyCommand == null)
                {
                    _buyCommand = new RelayCommand<CryptoDto>(param =>
                    {
                        CryptoDto updating = new();
                        Selected.Quantity ++;
                        updating = Selected;
                        _cryptoService.UpdateCryptoAsync(updating);
                        updating.Value = updating.Price * updating.Quantity;
                        Items.Remove(Selected);
                        Items.Add(updating);
                        Selected = Items.First();
                        Selected = updating;
                    }, param => param != null);
                }
                return _buyCommand;
            }
        }

        private ICommand _sellCommand;
        public ICommand SellCommand
        {
            get
            {
                if (_sellCommand == null)
                {
                    _sellCommand = new RelayCommand<CryptoDto>(async param =>
                    {
                        CryptoDto updating = new();
                        Selected.Quantity--;
                        if(Selected.Quantity == 0)
                        {
                            if (await _cryptoService.DeleteCryptoAsync(param))
                            {
                                _ = Items.Remove(param);
                            }
                        }
                        else
                        {
                            updating = Selected;
                            _cryptoService.UpdateCryptoAsync(updating);
                            updating.Value = updating.Price * updating.Quantity;
                            Items.Remove(Selected);
                            Items.Add(updating);
                            Selected = Items.First();
                            Selected = updating;
                        }
                        
                    }, param => param != null);
                }
                return _sellCommand;
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

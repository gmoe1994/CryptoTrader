using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoTrader.App.Contracts.ViewModels;
using CryptoTrader.App.Core.Contracts.Services;
using CryptoTrader.App.Core.Models;
using System.Linq;
using System.Windows.Input;

namespace CryptoTrader.App.ViewModels
{
    public class MarketDetailViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ICryptoService _cryptoService;
        private CryptoDto _item;

        public CryptoDto Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }


        public MarketDetailViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        private ICommand _addCommand;
        /// <summary>
        /// Gets the add command.
        /// If the item already exists in portfolio/database, the items quantity is increased by 1 and updated. Else it creates a new object in the database and is added to the portfolio.
        /// </summary>
        /// <value>The add command.</value>
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

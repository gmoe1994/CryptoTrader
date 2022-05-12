using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using CryptoTrader.App.Contracts.Services;
using CryptoTrader.App.Contracts.ViewModels;
using CryptoTrader.App.Core.Contracts.Services;
using CryptoTrader.App.Core.Models;
using CryptoTrader.App.Core.Services;

namespace CryptoTrader.App.ViewModels
{
    public class HomeViewModel : ObservableRecipient, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IExternalApiService _externalApiService;
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<CryptoDto>(OnItemClick));


        public HomeViewModel(INavigationService navigationService, IExternalApiService externalApiService)
        {
            _navigationService = navigationService;
            _externalApiService = externalApiService;
        }

        //private readonly ExternalApiService service = new ExternalApiService();

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
                _navigationService.NavigateTo(typeof(HomeDetailViewModel).FullName, clickedItem.Id);
            }
        }
    }
}

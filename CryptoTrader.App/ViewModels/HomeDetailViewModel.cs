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
        private readonly ISampleDataService _sampleDataService;
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public HomeDetailViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is long orderID)
            {
                var data = await _sampleDataService.GetContentGridDataAsync();
                Item = data.First(i => i.OrderID == orderID);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoTrader.App.Contracts.ViewModels;
using CryptoTrader.App.Core.Contracts.Services;
using CryptoTrader.App.Core.Models;

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

        public ListDetailsViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public async void OnNavigatedTo(object parameter)
        {

            var data = await _cryptoService.GetCryptoDtosAsync();
            foreach (var item in data)
            {
                Items.Add(item);
            }

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
                        //CharacterViewModel newCharacter = new() { ProfileImage = "Unknown.jpg" };
                        //CharacterPage page = new(newCharacter);

                        //ContentDialog dialog = new()
                        //{
                        //    Title = "Add new character",
                        //    Content = page,
                        //    PrimaryButtonText = "Add",
                        //    IsPrimaryButtonEnabled = false,
                        //    CloseButtonText = "Cancel",
                        //    DefaultButton = ContentDialogButton.Primary,
                        //    XamlRoot = _navigationService.Frame.XamlRoot
                        //};

                        //newCharacter.PropertyChanged += (sender, e) => dialog.IsPrimaryButtonEnabled = !newCharacter.HasErrors;

                        //ContentDialogResult result = await dialog.ShowAsync();

                        //if (result == ContentDialogResult.Primary)
                        //{
                        //    var characterDto = await _characterService.CreateCharacterAsync((CharacterDto)newCharacter);
                        //    CharacterViewModel character = new(characterDto);

                        //    Characters.Add(character);
                        //    Selected = character;
                        //}
                        Selected.Quantity = 1;
                        var cryptoDto = await _cryptoService.CreateCryptoAsync(Selected);


                    });
                }

                return _addCommand;
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}

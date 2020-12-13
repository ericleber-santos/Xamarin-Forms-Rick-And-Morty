using RickAndMorty.Models.Json;
using RickAndMorty.Services.Rest;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RickAndMorty.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
        private string _emptyMessage;
        public string EmptyMessage
        {
            get => _emptyMessage;
            set => SetProperty(ref _emptyMessage, value);
        }

        private string _emptyImage;
        public string EmptyImage
        {
            get => _emptyImage;
            set => SetProperty(ref _emptyImage, value);
        }

        public ObservableCollection<CharacterResult> CharactersCollection { get; set; }
        public ICommand ItemSelectionChangedCommand => new Command(async () => await ItemSelectionChanged());

        private CharacterResult selectedCharacter;

        public CharacterResult SelectedCharacter
        {
            get
            {
                return selectedCharacter;
            }
            set
            {
                SetProperty(ref selectedCharacter, value);
            }
        }

        public ICommand RefreshCommand { get; }

        private readonly ICharacterService _characterService;

        public CharacterViewModel(ICharacterService characterService)
        {
            _characterService = characterService;
            this.CharactersCollection = new ObservableCollection<CharacterResult>();
        }

        public async Task GetAllCharactersAsync()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            EmptyMessage = "Loading...";
            EmptyImage = "mortydanceloader.json";

            try
            {
                this.CharactersCollection.Clear();
                var characters = await _characterService.GetAll();

                foreach (var character in characters.results)
                {
                    CharactersCollection.Add(character);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

            EmptyMessage = "Oops, character not found!";
            EmptyImage = "";
        }

        async Task ItemSelectionChanged()
        {
            if (selectedCharacter == null)
                return;

            try
            {
                //await Shell.Current.Navigation.PushAsync(new EpisodeDetailPage(selectedEpisode), true);
                //selectedEpisode = null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private async void ExecuteRefreshCommand()
        {
            if (IsRefreshing || IsBusy)
                return;

            IsRefreshing = true;

            await GetAllCharactersAsync();

            IsRefreshing = false;
        }

        public async override Task InitializeAsync()
        {
            if (CharactersCollection.Any())
                return;
            await GetAllCharactersAsync().ConfigureAwait(false);
        }

    }
}



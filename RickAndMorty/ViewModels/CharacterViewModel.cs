using RickAndMorty.Models.Json;
using RickAndMorty.Services.Rest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RickAndMorty.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
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

        public CharacterViewModel()
        {
            this.CharactersCollection = new ObservableCollection<CharacterResult>();
        }

        public async Task GetAllCharacters()
        {

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                this.CharactersCollection.Clear();
                var characters = await CharacterService.GetAll();

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
        }

        async Task ItemSelectionChanged()
        {
            if (selectedCharacter == null)
            {
                return;
            }
            else
            {
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
        }

    }
}



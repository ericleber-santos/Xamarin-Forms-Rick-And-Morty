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
    public class EpisodeViewModel : BaseViewModel
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
                
        public ObservableCollection<EpisodeData> EpisodesCollection { get; set; }
        public ICommand ItemSelectionChangedCommand => new Command(async () => await ItemSelectionChanged());

        private EpisodeData selectedEpisode;

        public EpisodeData SelectedEpisode
        {
            get
            {
                return selectedEpisode;
            }
            set
            {
                SetProperty(ref selectedEpisode, value);
            }
        }

        public ICommand RefreshCommand { get; }

        private readonly IEpisodeService _episodeService;

        public EpisodeViewModel(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
            this.EpisodesCollection = new ObservableCollection<EpisodeData>();
            RefreshCommand = new Command(ExecuteRefreshCommand);
        }

        public async Task GetAllEpisodesAsync()
        {            

            if (IsBusy)
                return;

            IsBusy = true;

            EmptyMessage = "Loading...";
            EmptyImage = "mortydanceloader.json";

            try
            {
                this.EpisodesCollection.Clear();
                var episodios = await _episodeService.GetAll().ConfigureAwait(false); 

                foreach (var episodio in episodios.results)
                {                   
                    EpisodesCollection.Add(episodio);
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

            EmptyMessage = "Oops, episode not found!";
            EmptyImage = "";
        }

        async Task ItemSelectionChanged()
        {
            if (SelectedEpisode == null)
                return;

            try
            {
                //await Shell.Current.Navigation.PushAsync(new EpisodeDetailPage(SelectedEpisode), true);
                //SelectedEpisode = null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private async void ExecuteRefreshCommand()
        {
            await GetAllEpisodesAsync();
        }

        public async override Task InitializeAsync()
        {
            if (EpisodesCollection.Any())
                return;

            await GetAllEpisodesAsync().ConfigureAwait(false);
        }

    }
}



﻿using Refit;
using RickAndMorty.Models.Json;
using RickAndMorty.Services.Rest;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RickAndMorty.ViewModels
{
    public class EpisodeViewModel : BaseViewModel
    {
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

        public EpisodeViewModel()
        {
            this.EpisodesCollection = new ObservableCollection<EpisodeData>();
        }

        public async Task GetAllEpisodes()
        {            

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                this.EpisodesCollection.Clear();
                var episodios = await EpisodeService.GetAll();

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
        }

        async Task ItemSelectionChanged()
        {
            if (selectedEpisode == null)
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



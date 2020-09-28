using RickAndMorty.Services.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.ViewModels
{
    public class EpisodeViewModel : BaseViewModel
    {
        public EpisodeViewModel()
        {            
        }

        public async Task EpisodesDownload()
        {
            var users = await EpisodeService.DownloadEpisodesAsync();
           
        }
    }
}



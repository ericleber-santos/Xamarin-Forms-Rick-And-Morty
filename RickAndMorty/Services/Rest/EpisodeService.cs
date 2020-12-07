using Refit;
using RickAndMorty.Helpers;
using RickAndMorty.Models.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Rest
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeService()
        {
            _episodeService = RestService.For<IEpisodeService>(Constantes.URL_BASE);
        }

        public async Task<EpisodeRoot> GetAll()
        {
            try
            {
                return await _episodeService.GetAll(); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        public async Task<EpisodeData> GetById(int id)
        {
            try
            {
                return await _episodeService.GetById(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }
    }
}

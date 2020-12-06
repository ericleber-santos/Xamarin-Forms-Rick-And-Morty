using Refit;
using RickAndMorty.Helpers;
using RickAndMorty.Models.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Rest
{
    public static class EpisodeService 
    {
        private static IEpisodeService _episodeService = RestService.For<IEpisodeService>(Constantes.URL_BASE);

        public static async Task<EpisodeRoot> GetAll()
        {
            try
            {
                var usuariosRetorno = await _episodeService.GetAll();


                return usuariosRetorno;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        public static async Task<EpisodeData> GetById(int id)
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

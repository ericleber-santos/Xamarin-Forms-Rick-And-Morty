using Newtonsoft.Json;
using RickAndMorty.Helpers;
using RickAndMorty.Models;
using RickAndMorty.Models.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Http
{
    public static class EpisodeService
    {
        public static async Task<List<Episode>> DownloadEpisodesAsync()
        {
            List<Episode> _episodes = new List<Episode>();

            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.Timeout = TimeSpan.FromSeconds(20);

                    HttpResponseMessage response = null;
                    try
                    {
                        response = await cliente.GetAsync($"{Constantes.URL_BASE}episode");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        var episodes = JsonConvert.DeserializeObject<EpisodeRoot>(result);

                        foreach (var episode in episodes.results)
                        {
                            _episodes.Add(new Episode
                            {
                                id = episode.id,
                                name = episode.name,
                                air_date = episode.air_date,
                                episode = episode.episode,
                                characters = episode.characters,
                                url = episode.url,
                                created = episode.created

                            });
                        }

                        return _episodes;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

    }
}

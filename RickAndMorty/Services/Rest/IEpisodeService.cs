using Refit;
using RickAndMorty.Models.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Rest
{
    public interface IEpisodeService
    {
        [Get("/episode")]
        Task<EpisodeRoot> GetAll();

        [Get("/episode/{id}")]
        Task<EpisodeData> GetById(int id);
    }
}

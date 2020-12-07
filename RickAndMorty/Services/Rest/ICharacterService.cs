using Refit;
using RickAndMorty.Models.Json;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Rest
{
    public interface ICharacterService
    {
        [Get("/character")]
        Task<CharacterRoot> GetAll();

        [Get("/character/{id}")]
        Task<CharacterRoot> GetById(int id);
    }
}

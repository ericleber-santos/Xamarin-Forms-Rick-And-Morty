using Refit;
using RickAndMorty.Helpers;
using RickAndMorty.Models.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Rest
{
    public  class CharacterService : ICharacterService
    {
        private  readonly ICharacterService _CharacterService;

        public CharacterService()
        {
            _CharacterService = RestService.For<ICharacterService>(Constantes.URL_BASE);
        }

        public async Task<CharacterRoot> GetAll()
        {
            try
            {
                await Task.Delay(3000);
                return await _CharacterService.GetAll(); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        public async Task<CharacterRoot> GetById(int id)
        {
            try
            {
                return await _CharacterService.GetById(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }      
    }
}

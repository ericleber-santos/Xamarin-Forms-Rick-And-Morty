using Refit;
using RickAndMorty.Helpers;
using RickAndMorty.Models.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Rest
{
    public  class CharacterService
    {
        private static ICharacterService _characterService = RestService.For<ICharacterService>(Constantes.URL_BASE);

        public static async Task<CharacterRoot> GetAll()
        {
            try
            {
                var usuariosRetorno = await _characterService.GetAllCharacters();


                return usuariosRetorno;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        public static async Task<CharacterRoot> GetById(int id)
        {
            try
            {
                return await _characterService.GetById(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }
    }
}

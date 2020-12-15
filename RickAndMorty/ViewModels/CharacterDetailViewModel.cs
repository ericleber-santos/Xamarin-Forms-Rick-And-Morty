using RickAndMorty.Models.Json;

namespace RickAndMorty.ViewModels
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        private CharacterResult _characterResult;

        public CharacterDetailViewModel(CharacterResult characterResult)
        {
            _characterResult = characterResult;
            Title = characterResult.name;
        }
    }
}

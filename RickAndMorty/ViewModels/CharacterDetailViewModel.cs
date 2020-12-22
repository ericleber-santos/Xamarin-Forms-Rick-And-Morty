using RickAndMorty.Models.Json;

namespace RickAndMorty.ViewModels
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        public CharacterResult Character { get; set; } 

        public CharacterDetailViewModel(CharacterResult character)
        {
            Character = character;
            Title = character.name;
        }
    }
}

using RickAndMorty.Models.Json;
using RickAndMorty.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickAndMorty.Views
{  
    public partial class CharactersDetailPage : ContentPage
    {
        private readonly CharacterResult _character;
        readonly CharacterDetailViewModel _viewModel;

        public CharactersDetailPage(CharacterResult character)
        {
            InitializeComponent();
            _character = character;
            BindingContext = _viewModel = new CharacterDetailViewModel(_character);           
        }
    }
}
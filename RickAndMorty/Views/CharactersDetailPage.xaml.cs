using RickAndMorty.Models.Json;
using RickAndMorty.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickAndMorty.Views
{  
    public partial class CharactersDetailPage : ContentPage
    {       
        readonly CharacterDetailViewModel _viewModel;

        public CharactersDetailPage(CharacterResult character)
        {
            InitializeComponent();
            BindingContext = _viewModel = new CharacterDetailViewModel(character);           
        }

    }
}
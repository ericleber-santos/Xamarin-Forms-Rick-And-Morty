using RickAndMorty.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickAndMorty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersPage : ContentPage
    {
        readonly CharacterViewModel _viewModel;

        public CharactersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CharacterViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.GetAllCharacters();
        }
    }
}
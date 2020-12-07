using RickAndMorty.Services;
using RickAndMorty.Services.Rest;
using RickAndMorty.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickAndMorty.Views
{
    public partial class CharactersPage : ContentPage
    {
        readonly CharacterViewModel _viewModel;

        public CharactersPage()
        {
            InitializeComponent();
            var characterService = DependencyService.Get<ICharacterService>();
            BindingContext = _viewModel = new CharacterViewModel(characterService);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await OnAppearingAsync();
        }

        async Task OnAppearingAsync()
        {
            if (BindingContext is IInitialize _viewModel)
                await _viewModel.InitializeAsync().ConfigureAwait(false);
        }
    }
}
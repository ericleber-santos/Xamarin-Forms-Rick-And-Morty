using RickAndMorty.Services;
using RickAndMorty.Services.Rest;
using RickAndMorty.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RickAndMorty.Views
{
    public partial class EpisodesPage : ContentPage
    {
        readonly EpisodeViewModel _viewModel;

        public EpisodesPage()
        {
            InitializeComponent();
            var episodeService = DependencyService.Get<IEpisodeService>();
            BindingContext = _viewModel = new EpisodeViewModel(episodeService);
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
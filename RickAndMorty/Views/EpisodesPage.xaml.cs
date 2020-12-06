using RickAndMorty.ViewModels;
using Xamarin.Forms;

namespace RickAndMorty.Views
{
    public partial class EpisodesPage : ContentPage
    {
        readonly EpisodeViewModel _viewModel;

        public EpisodesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EpisodeViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.GetAllEpisodes();
        }
    }
}
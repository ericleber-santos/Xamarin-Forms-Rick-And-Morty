using RickAndMorty.Services.Rest;
using Xamarin.Forms;

namespace RickAndMorty
{
    public partial class App : Application
    {

        public App()
        {            
            InitializeComponent();
            DependencyRegister();
            Device.SetFlags(new[] { "Shapes_Experimental" });
            MainPage = new AppShell();
        }

        void DependencyRegister()
        {
            DependencyService.RegisterSingleton<ICharacterService>(new CharacterService());
            DependencyService.RegisterSingleton<IEpisodeService>(new EpisodeService());
        }
        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

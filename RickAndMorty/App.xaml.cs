using Xamarin.Forms;

namespace RickAndMorty
{
    public partial class App : Application
    {

        public App()
        {            
            InitializeComponent();
            Device.SetFlags(new[] { "Shapes_Experimental" });
            MainPage = new AppShell();
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

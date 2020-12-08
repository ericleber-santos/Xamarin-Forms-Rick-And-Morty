using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Com.Airbnb.Lottie;

namespace RickAndMorty.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity, Animator.IAnimatorListener
    { 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivitySplashScreen);

            LottieAnimationView animationView = FindViewById<LottieAnimationView>(Resource.Id.animation_view);

            animationView.AddAnimatorListener(this);
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }
            

        public void OnAnimationCancel(Animator animation){ }

        public void OnAnimationEnd(Animator animation)
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public void OnAnimationRepeat(Animator animation){ }

        public void OnAnimationStart(Animator animation){ }
    }
}
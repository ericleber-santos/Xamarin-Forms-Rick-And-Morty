using Android.OS;
using RickAndMorty.Droid.Providers;
using RickAndMorty.Services;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDBPathProvider))]
namespace RickAndMorty.Droid.Providers
{
    public class AndroidDBPathProvider : ISQLAndroidPathProvider
    {
        public string GetDBPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "rickandmortydb.db3");
        }
    }
}
using RickAndMorty.Models;
using RickAndMorty.Services;
using SQLite;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RickAndMorty.Helpers
{
    public static class DBHelper
    {
        private static SQLiteAsyncConnection _dbConnection;
       
        public static SQLiteAsyncConnection DBConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    _dbConnection = new SQLiteAsyncConnection(DependencyService.Get<ISQLAndroidPathProvider>().GetDBPath());
                }
                return _dbConnection;
            }
        }

        public static async Task CriateTablesAsync()
        {
            await DBConnection.CreateTableAsync<Episode>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Assignment2.Models;

namespace Assignment2
{
    public class DatabaseManager
    {
        SQLiteAsyncConnection _connection;

        public DatabaseManager()
        {
            _connection = DependencyService.Get<SQLiteDBInterface>().createSQLiteDB();
        }

        public async Task<ObservableCollection<Movie>> CreateTabel()
        {
            await _connection.CreateTableAsync<Movie>(); 
            var moviesFromDB = await _connection.Table<Movie>().ToListAsync();
            var allMovies = new ObservableCollection<Movie>(moviesFromDB);
            return allMovies;
        }

        public async void InsertNewTodo(Movie newMovie)
        {
            await _connection.InsertAsync(newMovie);
        }

        public async void DeleteMovie(Movie toDelete)
        {
            await _connection.DeleteAsync(toDelete);
        }

    }
}

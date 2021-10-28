using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage : ContentPage
    {
        NetworkingManager manager = new NetworkingManager();
        Movie movie;
        ObservableCollection<Movie> mList;
        DatabaseManager databaseManager;

        public MoviePage()
        {
            InitializeComponent();
        }

        public MoviePage(string i, DatabaseManager dbm , ObservableCollection<Movie> movieList)
        {
            InitializeComponent();
            loadMovie(i);
            databaseManager = dbm;
            mList = movieList;  
        }

        public async void loadMovie(string i)
        {
           
            var temp = await manager.getMovie(i);
            
            movie = new Movie(temp.Title, temp.Year,  temp.Rated, temp.Genre, temp.Director, temp.Writer, temp.Actors, temp.Plot, temp.Poster, i);
           
            title.Text = movie.Title.ToString();
            poster.Source = movie.Poster.ToString();
            year.Text = movie.Year.ToString();
            rated.Text = movie.Rated.ToString();
            genre.Text = movie.Genre.ToString();
            director.Text = "Director: " + movie.Director.ToString().Trim();
            writer.Text =  "Written By: " + movie.Writer.ToString().Trim();
            actors.Text = "Starring: " + movie.Actors.ToString().Trim();
            plot.Text = movie.Plot.ToString().Trim();

            if (mList.Where(x => x.ID == i).Count() == 1)
            {
                removeButton.IsVisible = true;
                addButton.IsVisible = false;
            }
            else
            {
                removeButton.IsVisible = false;
                addButton.IsVisible = true;
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
            
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            databaseManager.InsertNewTodo(movie);
            
            Navigation.PopModalAsync();
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            databaseManager.DeleteMovie(movie);
            Navigation.PopModalAsync();
        }
    }
}
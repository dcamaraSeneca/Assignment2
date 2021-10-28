using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Assignment2.Views;
using Assignment2.Models;
using System.Collections.ObjectModel;

namespace Assignment2
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Movie> movieList = new ObservableCollection<Movie>();
        DatabaseManager dbManger = new DatabaseManager();

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            movieList = await dbManger.CreateTabel();
            myMovieList.ItemsSource = movieList;
            base.OnAppearing();
            if (movieList.Count == 0)
            {
                myMovieList.IsVisible = false;
                myLabel.IsVisible = true;
            }
            else
            {
                myMovieList.IsVisible = true;
                myLabel.IsVisible = false;
            }

        }

        private void addMovieClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync( new AddMovie(dbManger, movieList));
        }

        private void myMovieList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new MoviePage((e.SelectedItem as Movie).ID, dbManger, movieList));
        }
    }
}

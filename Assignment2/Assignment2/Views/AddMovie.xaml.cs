using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMovie : ContentPage
    {
        NetworkingManager manager = new NetworkingManager();
        ObservableCollection<ShortMovie> movies;
        DatabaseManager dbManger;
        ObservableCollection<Movie> mList;
        private int index;

      
        public AddMovie(DatabaseManager dbm, ObservableCollection<Movie> ml)
        {
            InitializeComponent();
            index = 0;
            dbManger = dbm;
            mList = ml;
        }

   

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var listFromAPI = await manager.getMovies(query.Text);
            movies = new ObservableCollection<ShortMovie>();

            if (listFromAPI.Response != "True")
            {
                myLabel.IsVisible = true;
                movieList.IsVisible = false;
                /*movies.Add(new ShortMovie("", "No Search Results", "", "", ""));*/
            }
            else
            {
                myLabel.IsVisible = false;
                movieList.IsVisible = true;
                foreach (ShortMovie i in listFromAPI.movies)
                {
                    index = 1;

                    movies.Add(new ShortMovie(i.imdbID, i.Title, i.Poster, i.Year, i.Type.ToUpper()));

                    int pages = Int32.Parse(listFromAPI.totalResults) / 10;
                    if ( pages> 1)
                    {
                        page.IsVisible = true;
                        page.Text = "Page " + index.ToString();
                        if(index -1 != 0)
                        {
                            lt.IsVisible = true;
                        }
                        else
                        {
                            lt.IsVisible = false;
                        }

                        if( index + 1 <= pages)
                        {
                            gt.IsVisible = true;
                        }
                        else
                        {
                            gt.IsVisible = false;
                        }
                    }
                    else
                    {
                        lt.IsVisible = false;
                        gt.IsVisible = false;
                        page.IsVisible = false;
                    }
                }

                
            }
            movieList.ItemsSource = movies;
            
        }

        private void movieList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new MoviePage((e.SelectedItem as ShortMovie).imdbID, dbManger, mList));
        }

        private async void lt_Clicked(object sender, EventArgs e)
        {
            index--;
            var listFromAPI = await manager.getMovies(query.Text, index);
            movies = new ObservableCollection<ShortMovie>();

            if (listFromAPI.Response != "True")
            {
                myLabel.IsVisible = true;
                movieList.IsVisible = false;
            }
            else
            {
                myLabel.IsVisible = false;
                movieList.IsVisible = true;
                foreach (ShortMovie i in listFromAPI.movies)
                {
                

                    movies.Add(new ShortMovie(i.imdbID, i.Title, i.Poster, i.Year, i.Type.ToUpper()));

                    int pages = Int32.Parse(listFromAPI.totalResults) / 10;
                    if (pages > 1)
                    {
                        page.IsVisible = true;
                        page.Text = "Page " + index.ToString();
                        if (index - 1 != 0)
                        {
                            lt.IsVisible = true;
                        }
                        else
                        {
                            lt.IsVisible = false;
                        }

                        if (index + 1 <= pages)
                        {
                            gt.IsVisible = true;
                        }
                        else
                        {
                            gt.IsVisible = false;
                        }
                    }
                    else
                    {
                        lt.IsVisible = false;
                        gt.IsVisible = false;
                        page.IsVisible = false;
                    }
                }


            }
            movieList.ItemsSource = movies;
           
        }

        private async void gt_Clicked(object sender, EventArgs e)
        {
            index++;
            var listFromAPI = await manager.getMovies(query.Text, index);
            movies = new ObservableCollection<ShortMovie>();

            if (listFromAPI.Response != "True")
            {
                myLabel.IsVisible = true;
                movieList.IsVisible = false;
            }
            else
            {
                myLabel.IsVisible = false;
                movieList.IsVisible = true;
                foreach (ShortMovie i in listFromAPI.movies)
                {
                   

                    movies.Add(new ShortMovie(i.imdbID, i.Title, i.Poster, i.Year, i.Type.ToUpper()));

                    int pages = Int32.Parse(listFromAPI.totalResults) / 10;
                    if (pages > 1)
                    {
                        page.IsVisible = true;
                        page.Text = "Page " + index.ToString();
                        if (index - 1 != 0)
                        {
                            lt.IsVisible = true;
                        }
                        else
                        {
                            lt.IsVisible = false;
                        }

                        if (index + 1 <= pages)
                        {
                            gt.IsVisible = true;
                        }
                        else
                        {
                            gt.IsVisible = false;
                        }
                    }
                    else
                    {
                        lt.IsVisible = false;
                        gt.IsVisible = false;
                        page.IsVisible = false;
                    }
                }


            }
            movieList.ItemsSource = movies;
            
        }
    }
}
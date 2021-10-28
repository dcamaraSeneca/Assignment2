using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace Assignment2.Models
{
    public class Movie : INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }

        private string _poster;
        public string Poster
        {
            get { return _poster; }
            set
            {
                _poster = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Poster"));
            }
        }

        private string _year;
        public string Year
        {
            get { return _year; }
            set
            {
                _year = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Year"));
            }
        }

        private string _plot;
        public string Plot
        {
            get { return _plot; }
            set
            {
                _plot = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Plot"));
            }
        }

        private string _rated;
        public string Rated
        {
            get { return _rated; }
            set
            {
                _rated = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Rated"));
            }
        }

        private string _genre;
        public string Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Genre"));
            }
        }

        private string _director;
        public string Director
        {
            get { return _director; }
            set
            {
                _director = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Director"));
            }
        }

        private string _writer;
        public string Writer
        {
            get { return _writer; }
            set
            {
                _writer = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Writer"));
            }
        }

        private string _actors;
        public string Actors
        {
            get { return _actors; }
            set
            {
                _actors = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Actors"));
            }
        }

        private string _id;
        [PrimaryKey]
        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ID"));
            }
        }

        public Movie() { 
        }
        
        public Movie(string t,  string y,  string r, string g, string d, string w, string a, string pt, string p, string i)
        {
            Title = t;     
            Year = y;
            Rated = r;
            Genre = g;
            Director = d;
            Writer = w;
            Actors = a;
            Plot = pt; 
            Poster = p;
            ID = i;
            
        }    
            
    }
}

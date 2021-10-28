using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Assignment2.Models
{
    class ShortMovie : INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged = delegate { };


        private string _imdbID;
        public string imdbID
        {
            get { return _imdbID; }
            set
            {
                _imdbID = value;
                PropertyChanged(this, new PropertyChangedEventArgs("imdbID"));
            }
        }

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

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Type"));
            }
        }

        public ShortMovie()
        {
        }

        public ShortMovie(string i, string t, string p, string y, string tp)
        {
            imdbID = i;
            Title = t;
            Poster = p;
            Year = y;
            Type = tp;
         
        }
    }
}
